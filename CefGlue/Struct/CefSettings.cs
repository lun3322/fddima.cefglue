namespace CefGlue
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Text;
    using CefGlue.Interop;

    /// <summary>
    /// Initialization settings.
    /// Specify <c>null</c> or <c>0</c> to get the recommended default values.
    /// </summary>
    public sealed class CefSettings
    {
        private bool _isReadOnly;

        private bool _multiThreadedMessageLoop;
        private string _cachePath;
        private string _userAgent;
        private string _productVersion;
        private string _locale;
        private IList<string> _extraPluginPaths;
        private string _logFile;
        private CefLogSeverity _logSeverity;
        private CefGraphicsImplementation graphicsImplementation;
        private uint localStorageQuota;
        private uint sessionStorageQuota;
        private string javaScriptFlags;
#if WINDOWS
        private bool autoDetectProxySettingsEnabled;
#endif

        public CefSettings()
        {
            _extraPluginPaths = new List<string>();
        }

        /// <summary>
        /// Set to true to have the message loop run in a separate thread.
        /// If false than the Cef.DoMessageLoopWork() function must be called from your application message loop.
        /// </summary>
        public bool MultiThreadedMessageLoop
        {
            get { return _multiThreadedMessageLoop; }
            set
            {
                ThrowIfReadOnly();
                _multiThreadedMessageLoop = value;
            }
        }

        /// <summary>
        /// The location where cache data will be stored on disk.
        /// If empty an in-memory cache will be used.
        /// HTML5 databases such as localStorage will only persist across sessions if a cache path is specified.
        /// </summary>
        public string CachePath
        {
            get { return _cachePath; }
            set
            {
                ThrowIfReadOnly();
                _cachePath = value;
            }
        }

        /// <summary>
        /// Value that will be returned as the User-Agent HTTP header.
        /// If empty the default User-Agent string will be used.
        /// </summary>
        public string UserAgent
        {
            get { return _userAgent; }
            set
            {
                ThrowIfReadOnly();
                _userAgent = value;
            }
        }

        /// <summary>
        /// Value that will be inserted as the product portion of the default
        /// User-Agent string. If empty the Chromium product version will be used. If
        /// |userAgent| is specified this value will be ignored.
        /// </summary>
        public string ProductVersion
        {
            get { return _productVersion; }
            set
            {
                ThrowIfReadOnly();
                _productVersion = value;
            }
        }

        /// <summary>
        /// The locale string that will be passed to WebKit. If empty the default
        /// locale of "en-US" will be used.
        /// </summary>
        public string Locale
        {
            get { return _locale; }
            set
            {
                ThrowIfReadOnly();
                _locale = value;
            }
        }

        /// <summary>
        /// List of fully qualified paths to plugins (including plugin name) that will
        /// be loaded in addition to any plugins found in the default search paths.
        /// </summary>
        public IList<string> ExtraPluginPaths
        {
            get
            {
                if (!IsReadOnly) { return _extraPluginPaths; }
                else
                {
                    return new ReadOnlyCollection<string>(_extraPluginPaths);
                }
            }
        }

        /// <summary>
        /// The directory and file name to use for the debug log.
        /// If empty, the default name of "debug.log" will be used 
        /// and the file will be written to the application directory.
        /// </summary>
        public string LogFile
        {
            get { return _logFile; }
            set
            {
                ThrowIfReadOnly();
                _logFile = value;
            }
        }

        /// <summary>
        /// The log severity. Only messages of this severity level or higher will be logged.
        /// </summary>
        public CefLogSeverity LogSeverity
        {
            get { return _logSeverity; }
            set
            {
                ThrowIfReadOnly();
                _logSeverity = value;
            }
        }

        /// <summary>
        /// The graphics implementation that CEF will use for rendering GPU accelerated
        /// content like WebGL, accelerated layers and 3D CSS.
        /// </summary>
        public CefGraphicsImplementation GraphicsImplementation
        {
            get { return this.graphicsImplementation; }
            set
            {
                ThrowIfReadOnly();
                this.graphicsImplementation = value;
            }
        }


        /// <summary>
        /// Quota limit for localStorage data across all origins. Default size is 5MB.
        /// </summary>
        [CLSCompliant(false)]
        public uint LocalStorageQuota
        {
            get { return this.localStorageQuota; }
            set
            {
                ThrowIfReadOnly();
                this.localStorageQuota = value;
            }
        }

        /// <summary>
        /// Quota limit for sessionStorage data per namespace. Default size is 5MB.
        /// </summary>
        [CLSCompliant(false)]
        public uint SessionStorageQuota
        {
            get { return this.sessionStorageQuota; }
            set
            {
                ThrowIfReadOnly();
                this.sessionStorageQuota = value;
            }
        }

        /// <summary>
        /// Custom flags that will be used when initializing the V8 JavaScript engine.
        /// The consequences of using custom flags may not be well tested.
        /// </summary>
        public string JavaScriptFlags
        {
            get { return this.javaScriptFlags; }
            set
            {
                ThrowIfReadOnly();
                this.javaScriptFlags = value;
            }
        }

#if WINDOWS
        /// <summary>
        /// Set to true to use the system proxy resolver on Windows when "Automatically detect settings" is checked.
        /// This setting is disabled by default for performance reasons.
        /// </summary>
        public bool AutoDetectProxySettingsEnabled
        {
            get { return this.autoDetectProxySettingsEnabled; }
            set
            {
                ThrowIfReadOnly();
                this.autoDetectProxySettingsEnabled = value;
            }
        }
#endif

        internal bool IsReadOnly
        {
            get { return _isReadOnly; }
            set { _isReadOnly = value; }
        }

        private void ThrowIfReadOnly()
        {
            if (IsReadOnly) throw new InvalidOperationException("CefSettings object is read-only.");
        }


        internal unsafe cef_settings_t* CreateNative()
        {
            var ptr = cef_settings_t.Alloc();

            ptr->multi_threaded_message_loop = this.MultiThreadedMessageLoop;
            cef_string_t.Copy(this.CachePath, &ptr->cache_path);
            cef_string_t.Copy(this.UserAgent, &ptr->user_agent);
            cef_string_t.Copy(this.ProductVersion, &ptr->product_version);
            cef_string_t.Copy(this.Locale, &ptr->locale);
            ptr->extra_plugin_paths = CefStringList.CreateHandle(this.ExtraPluginPaths);
            cef_string_t.Copy(this.LogFile, &ptr->log_file);
            ptr->log_severity = (cef_log_severity_t)this.LogSeverity;
            ptr->graphics_implementation = (cef_graphics_implementation_t)this.GraphicsImplementation;
            ptr->local_storage_quota = this.LocalStorageQuota;
            ptr->session_storage_quota = this.SessionStorageQuota;
            cef_string_t.Copy(this.JavaScriptFlags, &ptr->javascript_flags);

#if WINDOWS
            ptr->auto_detect_proxy_settings_enabled = this.AutoDetectProxySettingsEnabled;
#endif

            return ptr;
        }

    }
}
