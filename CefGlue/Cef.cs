namespace CefGlue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Core;
    using Diagnostics;

    // TODO: allow specify libcef.dll location (and other libraries?)
    // TODO: do exception checking in handler impls, and reporting about them

    public static unsafe partial class Cef
    {
        private static CefSettings s_currentSettings;
        private static bool s_multiThreadedMessageLoop;

        public static CefSettings CurrentSettings
        {
            get
            {
                ThrowIfNotInitialized();
                return s_currentSettings;
            }
            private set
            {
                if (s_currentSettings != null)
                {
                    s_currentSettings.IsReadOnly = false;
                    s_currentSettings = null;
                }
                if (value != null)
                {
                    value.IsReadOnly = true;
                    s_multiThreadedMessageLoop = value.MultiThreadedMessageLoop;
                }
                s_currentSettings = value;
            }
        }

        // TODO: rename property
        public static bool IsInitialized { get { return s_currentSettings != null; } }

        internal static bool MultiThreadedMessageLoop { get { return s_multiThreadedMessageLoop; } }

#if DIAGNOSTICS
        [CLSCompliant(false)]
        public static Logger Logger { get { return Logger.Instance; } }
#endif

        /// <summary>
        /// This function should be called on the main application thread to initialize
        /// CEF when the application is started.
        /// </summary>
        /// <param name="settings"></param>
        /// <exception cref="Exception"></exception>
        public static void Initialize(CefSettings settings)
        {
            if (IsInitialized) throw new CefException("CEF already initialized.");
#if DIAGNOSTICS
            cef_string_t.OnCreate = (ptr, str) =>
            {
                if (string.IsNullOrEmpty(str))
                {
                    Cef.Logger.Trace(LogTarget.CefString, IntPtr.Zero, LogOperation.Create, "Empty.");
                }
                else
                {
                    Cef.Logger.Trace(LogTarget.CefString, ptr, LogOperation.Create, "Value=[{0}].",
                        str.Length <= 1024 ? str : (str.Substring(0, 1024) + "...")
                        );
                }
            };
            cef_string_t.OnDispose = (ptr) =>
            {
                Cef.Logger.Trace(LogTarget.CefString, ptr, LogOperation.Dispose);
            };

            Logger.SetAllTargets(true);
            Logger.Trace(LogTarget.Default, "Initialize");
#endif

            var n_settings = settings.CreateNative();
            var initialized = libcef.initialize(n_settings) != 0;
            cef_settings_t.Free(n_settings);

            if (!initialized) throw new CefException("CEF failed to initialize.");

            CurrentSettings = settings;
        }

        /// <summary>
        /// This function should be called on the main application thread to shut down
        /// CEF before the application exits.
        /// </summary>
        public static void Shutdown()
        {
            if (!IsInitialized) return;

            CurrentSettings = null;

            // FIXME: force to be proxies will be collected, this is can be done without CG.Collect in Cef.Shutdown to implicit dispose live proxies and objects

#if DIAGNOSTICS
            ObjectCt.WriteDump();
#endif

            // all proxies must be collected -> then all cef resources will be freed
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

#if DIAGNOSTICS
            ObjectCt.WriteDump();
#endif

            libcef.shutdown();

#if DIAGNOSTICS
            Logger.Close();
#endif
        }

        /// <summary>
        /// Perform a single iteration of CEF message loop processing. This function is
        /// used to integrate the CEF message loop into an existing application message
        /// loop. Care must be taken to balance performance against excessive CPU usage.
        /// This function should only be called on the main application thread and only
        /// if cef_initialize() is called with a CefSettings.multi_threaded_message_loop
        /// value of false (0). This function will not block.
        /// </summary>
        public static void DoMessageLoopWork()
        {
            libcef.do_message_loop_work();
        }

        /// <summary>
        /// Run the CEF message loop. Use this function instead of an application-
        /// provided message loop to get the best balance between performance and CPU
        /// usage. This function should only be called on the main application thread and
        /// only if cef_initialize() is called with a
        /// CefSettings.multi_threaded_message_loop value of false (0). This function
        /// will block until a quit message is received by the system.
        /// </summary>
        public static void RunMessageLoop()
        {
            libcef.run_message_loop();
        }


        /// <summary>
        /// Register a new V8 extension with the specified JavaScript extension
        /// code and handler. Functions implemented by the handler are prototyped
        /// using the keyword 'native'. The calling of a native function is
        /// restricted to the scope in which the prototype of the native function
        /// is defined. This function may be called on any thread.
        ///
        /// Example JavaScript extension code: &lt;pre&gt;
        ///   /// create the 'example' global object if it doesn't already exist.
        ///   if (!example)
        ///     example = {};
        ///   /// create the 'example.test' global object if it doesn't already exist.
        ///   if (!example.test)
        ///     example.test = {};
        ///   (function() {
        ///     /// Define the function 'example.test.myfunction'.
        ///     example.test.myfunction = function() {
        ///       /// Call CefV8Handler::Execute() with the function name 'MyFunction'
        ///       /// and no arguments.
        ///       native function MyFunction();
        ///       return MyFunction();
        ///     };
        ///     /// Define the getter function for parameter 'example.test.myparam'.
        ///     example.test.__defineGetter__('myparam', function() {
        ///       /// Call CefV8Handler::Execute() with the function name 'GetMyParam'
        ///       /// and no arguments.
        ///       native function GetMyParam();
        ///       return GetMyParam();
        ///     });
        ///     /// Define the setter function for parameter 'example.test.myparam'.
        ///     example.test.__defineSetter__('myparam', function(b) {
        ///       /// Call CefV8Handler::Execute() with the function name 'SetMyParam'
        ///       /// and a single argument.
        ///       native function SetMyParam();
        ///       if(b) SetMyParam(b);
        ///     });
        ///
        ///     /// Extension definitions can also contain normal JavaScript variables
        ///     /// and functions.
        ///     var myint = 0;
        ///     example.test.increment = function() {
        ///       myint += 1;
        ///       return myint;
        ///     };
        ///   })();
        /// &lt;/pre&gt; Example usage in the page: &lt;pre&gt;
        ///   /// Call the function.
        ///   example.test.myfunction();
        ///   /// Set the parameter.
        ///   example.test.myparam = value;
        ///   /// Get the parameter.
        ///   value = example.test.myparam;
        ///   /// Call another function.
        ///   example.test.increment();
        /// &lt;/pre&gt;
        /// </summary>
        public static bool RegisterExtension(string extensionName, string javascriptCode, CefV8Handler handler)
        {
            fixed (char* extensionName_str = extensionName)
            fixed (char* javasriptCode_str = javascriptCode)
            {
                var n_extensionName = new cef_string_t(extensionName_str, extensionName.Length);
                var n_javascriptCode = new cef_string_t(javasriptCode_str, javascriptCode.Length);

                return libcef.register_extension(
                    &n_extensionName,
                    &n_javascriptCode,
                    handler.GetNativePointerAndAddRef()
                    ) != 0;
            }
        }

        /// <summary>
        /// Register a custom scheme. This function should not be called for the
        /// built-in HTTP, HTTPS, FILE, FTP, ABOUT and DATA schemes.
        ///
        /// If |is_standard| is true (1) the scheme will be treated as a standard
        /// scheme. Standard schemes are subject to URL canonicalization and
        /// parsing rules as defined in the Common Internet Scheme Syntax RFC
        /// 1738 Section 3.1 available at http://www.ietf.org/rfc/rfc1738.txt
        ///
        /// In particular, the syntax for standard scheme URLs must be of the
        /// form: &lt;pre&gt;
        ///  [scheme]://[username]:[password]@[host]:[port]/[url-path]
        /// &lt;/pre&gt; Standard scheme URLs must have a host component that is a
        /// fully qualified domain name as defined in Section 3.5 of RFC 1034
        /// [13] and Section 2.1 of RFC 1123. These URLs will be canonicalized to
        /// "scheme://host/path" in the simplest case and
        /// "scheme://username:password@host:port/path" in the most explicit
        /// case. For example, "scheme:host/path" and "scheme:///host/path" will
        /// both be canonicalized to "scheme://host/path".
        ///
        /// For non-standard scheme URLs only the "scheme:" component is parsed
        /// and canonicalized. The remainder of the URL will be passed to the
        /// handler as-is. For example, "scheme:///some%20text" will remain the
        /// same. Non-standard scheme URLs cannot be used as a target for form
        /// submission.
        ///
        /// If |is_local| is true (1) the scheme will be treated as local (i.e.,
        /// with the same security rules as those applied to "file" URLs). This
        /// means that normal pages cannot link to or access URLs of this scheme.
        ///
        /// If |is_display_isolated| is true (1) the scheme will be treated as
        /// display- isolated. This means that pages cannot display these URLs
        /// unless they are from the same scheme. For example, pages in another
        /// origin cannot create iframes or hyperlinks to URLs with this scheme.
        ///
        /// This function may be called on any thread. It should only be called
        /// once per unique |scheme_name| value. If |scheme_name| is already
        /// registered or if an error occurs this function will return false (0).
        /// </summary>
        public static bool RegisterCustomScheme(string schemeName, bool isStandard, bool isLocal, bool isDisplayIsolated)
        {
            fixed (char* schemeName_str = schemeName)
            {
                var n_schemeName = new cef_string_t(schemeName_str, schemeName.Length);

                return libcef.register_custom_scheme(
                    &n_schemeName,
                    isStandard ? 1 : 0,
                    isLocal ? 1 : 0,
                    isDisplayIsolated ? 1 : 0
                    ) != 0;
            }
        }

        /// <summary>
        /// Register a scheme handler factory for the specified |scheme_name| and optional |domain_name|.
        /// An NULL |domain_name| value for a standard scheme will cause the factory to match all domain names.
        /// The |domain_name| value will be ignored for non-standard schemes.
        /// If |scheme_name| is a built-in scheme and no handler is returned by |factory| then the built-in scheme handler factory will be called.
        /// If |scheme_name| is a custom scheme the cef_register_custom_scheme() function should be called for that scheme.
        /// This function may be called multiple times to change or remove the factory that matches the specified |scheme_name| and optional |domain_name|.
        /// Returns false (0) if an error occurs.
        /// This function may be called on any thread.
        /// </summary>
        public static bool RegisterSchemeHandlerFactory(string schemeName, string domainName, CefSchemeHandlerFactory factory)
        {
            fixed (char* schemeName_str = schemeName)
            fixed (char* domainName_str = domainName)
            {
                var n_schemeName = new cef_string_t(schemeName_str, schemeName.Length);
                var n_domainName = new cef_string_t(domainName_str, domainName != null ? domainName.Length : 0);

                return libcef.register_scheme_handler_factory(
                    &n_schemeName,
                    &n_domainName,
                    factory.GetNativePointerAndAddRef()
                    ) != 0;
            }
        }

        /// <summary>
        /// Clear all registered scheme handler factories.
        /// Returns false (0) on error.
        /// This function may be called on any thread.
        /// </summary>
        public static bool ClearSchemeHandlerFactories()
        {
            return libcef.clear_scheme_handler_factories() != 0;
        }

        /// <summary>
        /// Add an entry to the cross-origin access whitelist.
        ///
        /// The same-origin policy restricts how scripts hosted from different
        /// origins (scheme + domain) can communicate. By default, scripts can
        /// only access resources with the same origin. Scripts hosted on the
        /// HTTP and HTTPS schemes (but no other schemes) can use the "Access-
        /// Control-Allow-Origin" header to allow cross-origin requests. For
        /// example, https://source.example.com can make XMLHttpRequest requests
        /// on http://target.example.com if the http://target.example.com request
        /// returns an "Access-Control-Allow-Origin: https://source.example.com"
        /// response header.
        ///
        /// Scripts in separate frames or iframes and hosted from the same
        /// protocol and domain suffix can execute cross-origin JavaScript if
        /// both pages set the document.domain value to the same domain suffix.
        /// For example, scheme://foo.example.com and scheme://bar.example.com
        /// can communicate using JavaScript if both domains set
        /// document.domain="example.com".
        ///
        /// This function is used to allow access to origins that would otherwise
        /// violate the same-origin policy. Scripts hosted underneath the fully
        /// qualified |source_origin| URL (like http://www.example.com) will be
        /// allowed access to all resources hosted on the specified
        /// |target_protocol| and |target_domain|. If |allow_target_subdomains|
        /// is true (1) access will also be allowed to all subdomains of the
        /// target domain. This function may be called on any thread. Returns
        /// false (0) if |source_origin| is invalid or the whitelist cannot be
        /// accessed.
        /// </summary>
        public static bool AddCrossOriginWhitelistEntry(string sourceOrigin, string targetProtocol, string targetDomain, bool allowTargetSubdomains)
        {
            fixed (char* sourceOrigin_str = sourceOrigin)
            fixed (char* targetProtocol_str = targetProtocol)
            fixed (char* targetDomain_str = targetDomain)
            {
                var n_sourceOrigin = new cef_string_t(sourceOrigin_str, sourceOrigin.Length);
                var n_targetProtocol = new cef_string_t(targetProtocol_str, targetProtocol.Length);
                var n_targetDomain = new cef_string_t(targetDomain_str, targetDomain.Length);

                return libcef.add_cross_origin_whitelist_entry(
                    &n_sourceOrigin,
                    &n_targetProtocol,
                    &n_targetDomain,
                    allowTargetSubdomains ? 1 : 0
                    ) != 0;
            }
        }

        /// <summary>
        /// Remove an entry from the cross-origin access whitelist.
        /// Returns false (0) if |source_origin| is invalid or the whitelist cannot be accessed.
        /// </summary>
        public static bool RemoveCrossOriginWhitelistEntry(string sourceOrigin, string targetProtocol, string targetDomain, bool allowTargetSubdomains)
        {
            fixed (char* sourceOrigin_str = sourceOrigin)
            fixed (char* targetProtocol_str = targetProtocol)
            fixed (char* targetDomain_str = targetDomain)
            {
                var n_sourceOrigin = new cef_string_t(sourceOrigin_str, sourceOrigin.Length);
                var n_targetProtocol = new cef_string_t(targetProtocol_str, targetProtocol.Length);
                var n_targetDomain = new cef_string_t(targetDomain_str, targetDomain.Length);

                return libcef.remove_cross_origin_whitelist_entry(
                    &n_sourceOrigin,
                    &n_targetProtocol,
                    &n_targetDomain,
                    allowTargetSubdomains ? 1 : 0
                    ) != 0;
            }
        }

        /// <summary>
        /// Remove all entries from the cross-origin access whitelist.
        /// Returns false (0) if the whitelist cannot be accessed.
        /// </summary>
        public static bool ClearCrossOriginWhitelist()
        {
            return libcef.clear_cross_origin_whitelist() != 0;
        }

        /// <summary>
        /// CEF maintains multiple internal threads that are used for handling
        /// different types of tasks.
        /// The UI thread creates the browser window and is used for all interaction with the WebKit rendering engine and V8 JavaScript engine
        /// (The UI thread will be the same as the main application thread if cef_initialize() is called with a CefSettings.multi_threaded_message_loop value of false (0).)
        /// The IO thread is used for handling schema and network requests.
        /// The FILE thread is used for the application cache and other miscellaneous activities.
        /// This function will return true (1) if called on the specified thread.
        /// </summary>
        public static bool CurrentlyOn(CefThreadId threadId)
        {
            return libcef.currently_on((cef_thread_id_t)threadId) != 0;
        }

        /// <summary>
        /// Post a task for execution on the specified thread.
        /// This function may be called on any thread.
        /// </summary>
        public static void PostTask(CefThreadId threadId, CefTask task)
        {
            var result = libcef.post_task((cef_thread_id_t)threadId, task.GetNativePointerAndAddRef()) != 0;
            if (!result) ThrowPostTaskError();
        }

        /// <summary>
        /// Post a task for delayed execution on the specified thread.
        /// This function may be called on any thread.
        /// </summary>
        public static void PostTask(CefThreadId threadId, CefTask task, long delayMs)
        {
            var result = libcef.post_delayed_task((cef_thread_id_t)threadId, task.GetNativePointerAndAddRef(), delayMs) != 0;
            if (!result) ThrowPostTaskError();
        }

        /// <summary>
        /// Parse the specified |url| into its component parts.
        /// Returns false (0) if the URL is NULL or invalid.
        /// </summary>
        // TODO: CEF API
        //public static extern int parse_url(/*const*/ cef_string_t* url, cef_urlparts_t* parts);

        /// <summary>
        /// Creates a URL from the specified |parts|, which must contain a non-
        /// NULL spec or a non-NULL host and path (at a minimum), but not both.
        /// Returns false (0) if |parts| isn't initialized as described.
        /// </summary>
        // TODO: CEF API
        //public static extern int create_url(/*const*/ cef_urlparts_t* parts, cef_string_t* url);

        /// <summary>
        /// Visit all cookies.
        /// The returned cookies are ordered by longest path, then by earliest creation date.
        /// Returns false (0) if cookies cannot be accessed.
        /// </summary>
        public static bool VisitAllCookies(CefCookieVisitor visitor)
        {
            return libcef.visit_all_cookies(visitor.GetNativePointerAndAddRef()) != 0;
        }

        /// <summary>
        /// Visit a subset of cookies.
        /// The results are filtered by the given url scheme, host, domain and path.
        /// If |includeHttpOnly| is true (1) HTTP-only cookies will also be included in the results.
        /// The returned cookies are ordered by longest path, then by earliest creation date.
        /// Returns false (0) if cookies cannot be accessed.
        /// </summary>
        public static bool VisitUrlCookies(string url, bool includeHttpOnly, CefCookieVisitor visitor)
        {
            fixed (char* url_str = url)
            {
                var n_url = new cef_string_t(url_str, url.Length);

                return libcef.visit_url_cookies(
                    &n_url,
                    includeHttpOnly ? 1 : 0,
                    visitor.GetNativePointerAndAddRef()
                    ) != 0;
            }
        }

        /// <summary>
        /// Sets a cookie given a valid URL and explicit user-provided cookie attributes.
        /// This function expects each attribute to be well-formed.
        /// It will check for disallowed characters (e.g. the ';' character is disallowed within the cookie value attribute) 
        /// and will return false (0) without setting the cookie if such characters are found.
        /// This function must be called on the IO thread.
        /// </summary>
        public static bool SetCookie(string url, CefCookie cookie)
        {
            fixed (char* url_str = url)
            {
                var n_url = new cef_string_t(url_str, url.Length);

                return libcef.set_cookie(
                    &n_url,
                    cookie.GetNativeHandle()
                    ) != 0;
            }
        }

        /// <summary>
        /// Delete all cookies that match the specified parameters. If both |url|
        /// and |cookie_name| are specified all host and domain cookies matching
        /// both values will be deleted. If only |url| is specified all host
        /// cookies (but not domain cookies) irrespective of path will be
        /// deleted. If |url| is NULL all cookies for all hosts and domains will
        /// be deleted. Returns false (0) if a non-NULL invalid URL is specified
        /// or if cookies cannot be accessed. This function must be called on the
        /// IO thread.
        /// </summary>
        public static bool DeleteCookies(string url, string cookieName)
        {
            fixed (char* url_str = url)
            fixed (char* cookieName_str = url)
            {
                var n_url = new cef_string_t(url_str, url != null ? url.Length : 0);
                var n_cookieName = new cef_string_t(cookieName_str, cookieName != null ? cookieName.Length : 0);

                return libcef.delete_cookies(&n_url, &n_cookieName) != 0;
            }
        }

        /// <summary>
        /// Visit storage of the specified type.
        /// If |origin| is non-empty only data matching that origin will be visited.
        /// If |key| is non-empty only data matching that key will be visited.
        /// Otherwise, all data for the storage type will be visited.
        /// Returns false if the storage cannot be accessed.
        /// Origin should be of the form scheme://domain.
        /// </summary>
        public static bool VisitStorage(CefStorageType type, string origin, string key, CefStorageVisitor visitor)
        {
            fixed (char* origin_str = origin)
            fixed (char* key_str = key)
            {
                var nOrigin = new cef_string_t(origin_str, origin != null ? origin.Length : 0);
                var nKey = new cef_string_t(key_str, key != null ? key.Length : 0);

                return libcef.visit_storage((cef_storage_type_t)type, &nOrigin, &nKey, visitor.GetNativePointerAndAddRef()) != 0;
            }
        }

        /// <summary>
        /// Sets storage of the specified type, origin, key and value.
        /// Returns false if storage cannot be accessed.
        /// This method must be called on the UI thread.
        /// </summary>
        public static bool SetStorage(CefStorageType type, string origin, string key, string value)
        {
            fixed (char* origin_str = origin)
            fixed (char* key_str = key)
            fixed (char* value_str = value)
            {
                var nOrigin = new cef_string_t(origin_str, origin != null ? origin.Length : 0);
                var nKey = new cef_string_t(key_str, key != null ? key.Length : 0);
                var nValue = new cef_string_t(value_str, value != null ? value.Length : 0);

                return libcef.set_storage((cef_storage_type_t)type, &nOrigin, &nKey, &nValue) != 0;
            }
        }

        /// <summary>
        /// Deletes all storage of the specified type.
        /// If |origin| is non-empty only data matching that origin will be cleared.
        /// If |key| is non-empty only data matching that key will be cleared.
        /// Otherwise, all data for the storage type will be cleared.
        /// Returns false if storage cannot be accessed.
        /// This method must be called on the UI thread.
        /// </summary>
        public static bool DeleteStorage(CefStorageType type, string origin, string key)
        {
            fixed (char* origin_str = origin)
            fixed (char* key_str = key)
            {
                var nOrigin = new cef_string_t(origin_str, origin != null ? origin.Length : 0);
                var nKey = new cef_string_t(key_str, key != null ? key.Length : 0);

                return libcef.delete_storage((cef_storage_type_t)type, &nOrigin, &nKey) != 0;
            }
        }


        private static void ThrowIfNotInitialized()
        {
            if (!IsInitialized) throw new CefException("CEF is not initialized.");
        }

        private static void ThrowPostTaskError()
        {
            throw new CefException("Post task error.");
        }
    }
}
