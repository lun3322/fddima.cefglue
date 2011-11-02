namespace CefGlue.Interop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack = libcef.StructPack)]
    internal struct cef_cursor_handle_t
    {
        private IntPtr handle;

        private cef_cursor_handle_t(IntPtr handle)
        {
            this.handle = handle;
        }

        public static implicit operator IntPtr(cef_cursor_handle_t value)
        {
            return value.handle;
        }

        public static implicit operator cef_cursor_handle_t(IntPtr value)
        {
            return new cef_cursor_handle_t(value);
        }
    }
}
