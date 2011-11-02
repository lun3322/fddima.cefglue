namespace CefGlue.Interop
{
    using System;
    using System.Runtime.InteropServices;

    internal static unsafe partial class NativeMethods
    {
        /// <summary>
        /// These functions set string values. If |copy| is true (1) the value will be
        /// copied instead of referenced. It is up to the user to properly manage
        /// the lifespan of references.
        /// </summary>
        /// <remarks>
        /// CEF_EXPORT int cef_string_utf16_set(const char16_t* src, size_t src_len,
        ///                                     cef_string_utf16_t* output, int copy);
        /// </remarks>
        [DllImport(CefDllName, EntryPoint = "cef_string_utf16_set", CallingConvention = CefCall)]
        public static extern int cef_string_set(char* src, int src_len, cef_string_t* output, int copy);

        /// <summary>
        /// These functions clear string values. The structure itself is not freed.
        /// </summary>
        /// <param name="str"></param>
        /// <remarks>
        /// CEF_EXPORT void cef_string_utf16_clear(cef_string_utf16_t* str);
        /// </remarks>
        [DllImport(CefDllName, EntryPoint = "cef_string_utf16_clear", CallingConvention = CefCall)]
        public static extern void cef_string_clear(cef_string_t* str);

        /// <summary>
        /// These functions allocate a new string structure.
        /// They must be freed by calling the associated free function.
        /// </summary>
        /// <remarks>
        /// CEF_EXPORT cef_string_userfree_utf16_t cef_string_userfree_utf16_alloc();
        /// </remarks>
        [DllImport(CefDllName, EntryPoint = "cef_string_userfree_utf16_alloc", CallingConvention = CefCall)]
        public static extern cef_string_userfree_t cef_string_userfree_alloc();

        /// <summary>
        /// These functions free the string structure allocated by the associated alloc function.
        /// Any string contents will first be cleared.
        /// </summary>
        /// <remarks>
        /// CEF_EXPORT void cef_string_userfree_utf16_free(cef_string_userfree_utf16_t str);
        /// </remarks>
        [DllImport(CefDllName, EntryPoint = "cef_string_userfree_utf16_free", CallingConvention = CefCall)]
        public static extern void cef_string_userfree_free(cef_string_userfree_t str);
    }
}

