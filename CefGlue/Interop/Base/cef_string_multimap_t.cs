namespace CefGlue.Interop
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// CEF string multimap.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeMethods.CefStructPack)]
    internal unsafe struct cef_string_multimap_t
    {
        private IntPtr handle;

        public static readonly cef_string_multimap_t Null = new cef_string_multimap_t();

        public static bool operator ==(cef_string_multimap_t first, cef_string_multimap_t second)
        {
            return first.handle == second.handle;
        }

        public static bool operator !=(cef_string_multimap_t first, cef_string_multimap_t second)
        {
            return first.handle != second.handle;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is cef_string_multimap_t)
            {
                var other = (cef_string_multimap_t)obj;
                return this.handle == other.handle;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (int)this.handle;
        }
    }
}
