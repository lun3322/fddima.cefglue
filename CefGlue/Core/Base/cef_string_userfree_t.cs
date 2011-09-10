namespace CefGlue.Core
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
    [StructLayout(LayoutKind.Sequential, Pack = libcef.StructPack)]
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
                libcef.string_userfree_free(this);
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
                libcef.string_userfree_free(this);
                str = null;
                return result;
            }
            else
            {
                return null;
            }
        }
    }

    unsafe partial class libcef
    {
        /// <summary>
        /// These functions allocate a new string structure.
        /// They must be freed by calling the associated free function.
        /// </summary>
        /// <remarks>
        /// CEF_EXPORT cef_string_userfree_utf16_t cef_string_userfree_utf16_alloc();
        /// </remarks>
        [DllImport(libcef.DllName, EntryPoint = "cef_string_userfree_utf16_alloc", CallingConvention = libcef.Call)]
        public static extern cef_string_userfree_t string_userfree_alloc();

        /// <summary>
        /// These functions free the string structure allocated by the associated alloc function.
        /// Any string contents will first be cleared.
        /// </summary>
        /// <remarks>
        /// CEF_EXPORT void cef_string_userfree_utf16_free(cef_string_userfree_utf16_t str);
        /// </remarks>
        [DllImport(libcef.DllName, EntryPoint = "cef_string_userfree_utf16_free", CallingConvention = libcef.Call)]
        public static extern void string_userfree_free(cef_string_userfree_t str);
    }
}
