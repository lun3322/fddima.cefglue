namespace CefGlue.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack = libcef.StructPack)]
    internal struct cef_window_handle_t
    {
        private IntPtr handle;

        private cef_window_handle_t(IntPtr handle)
        {
            this.handle = handle;
        }

        public static implicit operator IntPtr(cef_window_handle_t value)
        {
            return value.handle;
        }

        public static implicit operator cef_window_handle_t(IntPtr value)
        {
            return new cef_window_handle_t(value);
        }
    }
}
