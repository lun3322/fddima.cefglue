namespace CefGlue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Core;
    using Diagnostics;

    public static unsafe class Cef
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
            if (IsInitialized) throw new CefGlueException("CEF already initialized.");
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

            if (!initialized) throw new CefGlueException("CEF failed to initialize.");

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
            return libcef.currently_on((cef_thread_id_t)threadId) != 0 ? true : false;
        }

        /// <summary>
        /// Post a task for execution on the specified thread.
        /// This function may be called on any thread.
        /// </summary>
        /// <remarks>
        /// Same as CefTask.Post.
        /// </remarks>
        public static void PostTask(CefThreadId threadId, CefTask task)
        {
            CefTask.Post(threadId, task);
        }


        private static void ThrowIfNotInitialized()
        {
            if (!IsInitialized) throw new CefGlueException("CEF is not initialized.");
        }
    }
}
