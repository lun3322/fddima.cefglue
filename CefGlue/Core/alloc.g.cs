namespace CefGlue.Core
{
    using System;
    using System.Runtime.InteropServices;

    internal unsafe partial struct cef_settings_t
    {
        private static int s_size;

        static cef_settings_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_settings_t));
        }

        internal static cef_settings_t* Alloc()
        {
            var ptr = (cef_settings_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_settings_t();
            ptr->size = s_size;
            return ptr;
        }

        internal static void Free(cef_settings_t* ptr)
        {
            Clear(ptr);
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_window_info_t
    {
        private static int s_size;

        static cef_window_info_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_window_info_t));
        }

        internal static cef_window_info_t* Alloc()
        {
            var ptr = (cef_window_info_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_window_info_t();
            return ptr;
        }

        internal static void Free(cef_window_info_t* ptr)
        {
            Clear(ptr);
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_browser_settings_t
    {
        private static int s_size;

        static cef_browser_settings_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_browser_settings_t));
        }

        internal static cef_browser_settings_t* Alloc()
        {
            var ptr = (cef_browser_settings_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_browser_settings_t();
            ptr->size = s_size;
            return ptr;
        }

        internal static void Free(cef_browser_settings_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_popup_features_t
    {
        private static int s_size;

        static cef_popup_features_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_popup_features_t));
        }

        internal static cef_popup_features_t* Alloc()
        {
            var ptr = (cef_popup_features_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_popup_features_t();
            return ptr;
        }

        internal static void Free(cef_popup_features_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_cookie_t
    {
        private static int s_size;

        static cef_cookie_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_cookie_t));
        }

        internal static cef_cookie_t* Alloc()
        {
            var ptr = (cef_cookie_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_cookie_t();
            return ptr;
        }

        internal static void Free(cef_cookie_t* ptr)
        {
            Clear(ptr);
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_client_t
    {
        private static int s_size;

        static cef_client_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_client_t));
        }

        internal static cef_client_t* Alloc()
        {
            var ptr = (cef_client_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_client_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_client_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_life_span_handler_t
    {
        private static int s_size;

        static cef_life_span_handler_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_life_span_handler_t));
        }

        internal static cef_life_span_handler_t* Alloc()
        {
            var ptr = (cef_life_span_handler_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_life_span_handler_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_life_span_handler_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_load_handler_t
    {
        private static int s_size;

        static cef_load_handler_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_load_handler_t));
        }

        internal static cef_load_handler_t* Alloc()
        {
            var ptr = (cef_load_handler_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_load_handler_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_load_handler_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_request_handler_t
    {
        private static int s_size;

        static cef_request_handler_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_request_handler_t));
        }

        internal static cef_request_handler_t* Alloc()
        {
            var ptr = (cef_request_handler_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_request_handler_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_request_handler_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_display_handler_t
    {
        private static int s_size;

        static cef_display_handler_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_display_handler_t));
        }

        internal static cef_display_handler_t* Alloc()
        {
            var ptr = (cef_display_handler_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_display_handler_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_display_handler_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_focus_handler_t
    {
        private static int s_size;

        static cef_focus_handler_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_focus_handler_t));
        }

        internal static cef_focus_handler_t* Alloc()
        {
            var ptr = (cef_focus_handler_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_focus_handler_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_focus_handler_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_keyboard_handler_t
    {
        private static int s_size;

        static cef_keyboard_handler_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_keyboard_handler_t));
        }

        internal static cef_keyboard_handler_t* Alloc()
        {
            var ptr = (cef_keyboard_handler_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_keyboard_handler_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_keyboard_handler_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_menu_handler_t
    {
        private static int s_size;

        static cef_menu_handler_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_menu_handler_t));
        }

        internal static cef_menu_handler_t* Alloc()
        {
            var ptr = (cef_menu_handler_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_menu_handler_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_menu_handler_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_print_handler_t
    {
        private static int s_size;

        static cef_print_handler_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_print_handler_t));
        }

        internal static cef_print_handler_t* Alloc()
        {
            var ptr = (cef_print_handler_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_print_handler_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_print_handler_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_find_handler_t
    {
        private static int s_size;

        static cef_find_handler_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_find_handler_t));
        }

        internal static cef_find_handler_t* Alloc()
        {
            var ptr = (cef_find_handler_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_find_handler_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_find_handler_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_jsdialog_handler_t
    {
        private static int s_size;

        static cef_jsdialog_handler_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_jsdialog_handler_t));
        }

        internal static cef_jsdialog_handler_t* Alloc()
        {
            var ptr = (cef_jsdialog_handler_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_jsdialog_handler_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_jsdialog_handler_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_jsbinding_handler_t
    {
        private static int s_size;

        static cef_jsbinding_handler_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_jsbinding_handler_t));
        }

        internal static cef_jsbinding_handler_t* Alloc()
        {
            var ptr = (cef_jsbinding_handler_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_jsbinding_handler_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_jsbinding_handler_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_render_handler_t
    {
        private static int s_size;

        static cef_render_handler_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_render_handler_t));
        }

        internal static cef_render_handler_t* Alloc()
        {
            var ptr = (cef_render_handler_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_render_handler_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_render_handler_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_drag_handler_t
    {
        private static int s_size;

        static cef_drag_handler_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_drag_handler_t));
        }

        internal static cef_drag_handler_t* Alloc()
        {
            var ptr = (cef_drag_handler_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_drag_handler_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_drag_handler_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_download_handler_t
    {
        private static int s_size;

        static cef_download_handler_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_download_handler_t));
        }

        internal static cef_download_handler_t* Alloc()
        {
            var ptr = (cef_download_handler_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_download_handler_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_download_handler_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_scheme_handler_factory_t
    {
        private static int s_size;

        static cef_scheme_handler_factory_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_scheme_handler_factory_t));
        }

        internal static cef_scheme_handler_factory_t* Alloc()
        {
            var ptr = (cef_scheme_handler_factory_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_scheme_handler_factory_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_scheme_handler_factory_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_scheme_handler_t
    {
        private static int s_size;

        static cef_scheme_handler_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_scheme_handler_t));
        }

        internal static cef_scheme_handler_t* Alloc()
        {
            var ptr = (cef_scheme_handler_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_scheme_handler_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_scheme_handler_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_content_filter_t
    {
        private static int s_size;

        static cef_content_filter_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_content_filter_t));
        }

        internal static cef_content_filter_t* Alloc()
        {
            var ptr = (cef_content_filter_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_content_filter_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_content_filter_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_task_t
    {
        private static int s_size;

        static cef_task_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_task_t));
        }

        internal static cef_task_t* Alloc()
        {
            var ptr = (cef_task_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_task_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_task_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_cookie_visitor_t
    {
        private static int s_size;

        static cef_cookie_visitor_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_cookie_visitor_t));
        }

        internal static cef_cookie_visitor_t* Alloc()
        {
            var ptr = (cef_cookie_visitor_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_cookie_visitor_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_cookie_visitor_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_v8handler_t
    {
        private static int s_size;

        static cef_v8handler_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_v8handler_t));
        }

        internal static cef_v8handler_t* Alloc()
        {
            var ptr = (cef_v8handler_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_v8handler_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_v8handler_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_v8accessor_t
    {
        private static int s_size;

        static cef_v8accessor_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_v8accessor_t));
        }

        internal static cef_v8accessor_t* Alloc()
        {
            var ptr = (cef_v8accessor_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_v8accessor_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_v8accessor_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_domvisitor_t
    {
        private static int s_size;

        static cef_domvisitor_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_domvisitor_t));
        }

        internal static cef_domvisitor_t* Alloc()
        {
            var ptr = (cef_domvisitor_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_domvisitor_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_domvisitor_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_domevent_listener_t
    {
        private static int s_size;

        static cef_domevent_listener_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_domevent_listener_t));
        }

        internal static cef_domevent_listener_t* Alloc()
        {
            var ptr = (cef_domevent_listener_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_domevent_listener_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_domevent_listener_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_read_handler_t
    {
        private static int s_size;

        static cef_read_handler_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_read_handler_t));
        }

        internal static cef_read_handler_t* Alloc()
        {
            var ptr = (cef_read_handler_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_read_handler_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_read_handler_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_write_handler_t
    {
        private static int s_size;

        static cef_write_handler_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_write_handler_t));
        }

        internal static cef_write_handler_t* Alloc()
        {
            var ptr = (cef_write_handler_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_write_handler_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_write_handler_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cef_web_urlrequest_client_t
    {
        private static int s_size;

        static cef_web_urlrequest_client_t()
        {
            s_size = Marshal.SizeOf(typeof(cef_web_urlrequest_client_t));
        }

        internal static cef_web_urlrequest_client_t* Alloc()
        {
            var ptr = (cef_web_urlrequest_client_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cef_web_urlrequest_client_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cef_web_urlrequest_client_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

    internal unsafe partial struct cefglue_userdata_t
    {
        private static int s_size;

        static cefglue_userdata_t()
        {
            s_size = Marshal.SizeOf(typeof(cefglue_userdata_t));
        }

        internal static cefglue_userdata_t* Alloc()
        {
            var ptr = (cefglue_userdata_t*)Marshal.AllocHGlobal(s_size);
            *ptr = new cefglue_userdata_t();
            ptr->@base.size = s_size;
            return ptr;
        }

        internal static void Free(cefglue_userdata_t* ptr)
        {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
    }

}
