namespace CefGlue.Interop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Text;

    /// <summary>
    /// It is sometimes necessary for the system to allocate string structures with
    /// the expectation that the user will free them. The userfree types act as a
    /// hint that the user is responsible for freeing the structure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeMethods.CefStructPack)]
    internal unsafe struct cef_string_userfree_t
    {
        private cef_string_t* str;

        public int Length
        {
            get { return str->length; }
        }

        internal char GetFirstCharOrDefault()
        {
            if (str->length > 0)
            {
                return *(str->str);
            }
            return '\x0';
        }

        public void Free()
        {
            if (str != null)
            {
                NativeMethods.cef_string_userfree_free(this);
                str = null;
            }
        }

        public string GetString()
        {
            if (str != null)
            {
                return cef_string_t.ToString(str);
            }
            else
            {
                return null;
            }
        }

        public string GetStringAndFree()
        {
            if (str != null)
            {
                var result = cef_string_t.ToString(str);
                NativeMethods.cef_string_userfree_free(this);
                str = null;
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
