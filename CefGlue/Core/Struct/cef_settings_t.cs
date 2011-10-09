namespace CefGlue.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;

    ///
    // Initialization settings. Specify NULL or 0 to get the recommended default
    // values.
    ///
    [StructLayout(LayoutKind.Sequential, Pack = libcef.StructPack)]
    internal unsafe partial struct cef_settings_t
    {
        ///
        // Size of this structure.
        ///
        // size_t size;
        public int size;

        ///
        // Set to true (1) to have the message loop run in a separate thread. If
        // false (0) than the CefDoMessageLoopWork() function must be called from
        // your application message loop.
        ///
        // bool multi_threaded_message_loop;
        public bool_t multi_threaded_message_loop;

        ///
        // The location where cache data will be stored on disk. If empty an
        // in-memory cache will be used. HTML5 databases such as localStorage will
        // only persist across sessions if a cache path is specified.
        ///
        public cef_string_t cache_path;

        ///
        // Value that will be returned as the User-Agent HTTP header. If empty the
        // default User-Agent string will be used.
        ///
        public cef_string_t user_agent;

        ///
        // Value that will be inserted as the product portion of the default
        // User-Agent string. If empty the Chromium product version will be used. If
        // |userAgent| is specified this value will be ignored.
        ///
        public cef_string_t product_version;

        ///
        // The locale string that will be passed to WebKit. If empty the default
        // locale of "en-US" will be used.
        ///
        public cef_string_t locale;

        ///
        // List of fully qualified paths to plugins (including plugin name) that will
        // be loaded in addition to any plugins found in the default search paths.
        ///
        public cef_string_list_t extra_plugin_paths;

        ///
        // The directory and file name to use for the debug log. If empty, the
        // default name of "debug.log" will be used and the file will be written
        // to the application directory.
        ///
        public cef_string_t log_file;

        ///
        // The log severity. Only messages of this severity level or higher will be
        // logged.
        ///
        public cef_log_severity_t log_severity;
        
        ///
        // The graphics implementation that CEF will use for rendering GPU accelerated
        // content like WebGL, accelerated layers and 3D CSS.
        ///
        public cef_graphics_implementation_t graphics_implementation;

        ///
        // Quota limit for localStorage data across all origins. Default size is 5MB.
        ///
        public uint local_storage_quota;
        
        ///
        // Quota limit for sessionStorage data per namespace. Default size is 5MB.
        ///
        public uint session_storage_quota;


        public static void Clear(cef_settings_t* self)
        {
            cef_string_t.Clear(&self->cache_path);
            cef_string_t.Clear(&self->user_agent);
            cef_string_t.Clear(&self->product_version);
            cef_string_t.Clear(&self->locale);
            self->extra_plugin_paths.Free();
            cef_string_t.Clear(&self->log_file);
        }
    }
}
