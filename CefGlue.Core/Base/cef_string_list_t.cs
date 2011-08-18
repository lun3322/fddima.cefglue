namespace CefGlue.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;

    /// <summary>
    /// CEF string list.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = libcef.StructPack)]
    internal unsafe struct cef_string_list_t
    {
        private IntPtr _handle;

        public static cef_string_list_t CreateFrom(IEnumerable<string> collection)
        {
            var list = libcef.string_list_alloc();
            cef_string_t str = new cef_string_t();
            foreach (var path in collection)
            {
                cef_string_t.Set(path, &str, false);
                libcef.string_list_append(list, &str);
            }
            return list;
        }

        public bool IsAllocated { get { return _handle != IntPtr.Zero; } }

        public void Free()
        {
            if (IsAllocated)
            {
                libcef.string_list_free(this);
                _handle = IntPtr.Zero;
            }
        }

        public int Count
        {
            get
            {
                return libcef.string_list_size(this);
            }
        }
    }

    internal static unsafe partial class libcef
    {
        /// <summary>
        /// Allocate a new string map.
        /// </summary>
        /// <returns></returns>
        // CEF_EXPORT cef_string_list_t cef_string_list_alloc();
        [DllImport(DllName, EntryPoint = "cef_string_list_alloc", CallingConvention = Call)]
        public static extern cef_string_list_t string_list_alloc();

        /// <summary>
        /// Return the number of elements in the string list.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        // CEF_EXPORT int cef_string_list_size(cef_string_list_t list);
        [DllImport(DllName, EntryPoint = "cef_string_list_size", CallingConvention = Call)]
        public static extern int string_list_size(cef_string_list_t list);

        /// <summary>
        /// Retrieve the value at the specified zero-based string list index.
        /// Returns true (1) if the value was successfully retrieved.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks>This method return string by value (via cef_string_copy).</remarks>
        // CEF_EXPORT int cef_string_list_value(cef_string_list_t list,
        //                                      int index, cef_string_t* value);
        [DllImport(DllName, EntryPoint = "cef_string_list_value", CallingConvention = Call)]
        public static extern int string_list_value(cef_string_list_t list, int index, ref cef_string_t value);

        /// <summary>
        /// Append a new value at the end of the string list.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        // CEF_EXPORT void cef_string_list_append(cef_string_list_t list,
        //                                       const cef_string_t* value);
        [DllImport(DllName, EntryPoint = "cef_string_list_append", CallingConvention = Call)]
        public static extern void string_list_append(cef_string_list_t list, cef_string_t* value);

        /// <summary>
        /// Clear the string list.
        /// </summary>
        /// <param name="list"></param>
        // CEF_EXPORT void cef_string_list_clear(cef_string_list_t list);
        [DllImport(DllName, EntryPoint = "cef_string_list_clear", CallingConvention = Call)]
        public static extern void string_list_clear(cef_string_list_t list);

        /// <summary>
        /// Free the string list.
        /// </summary>
        /// <param name="list"></param>
        /// <remarks>Method doen't allow NULLs.</remarks>
        // CEF_EXPORT void cef_string_list_free(cef_string_list_t list);
        [DllImport(DllName, EntryPoint = "cef_string_list_free", CallingConvention = Call)]
        public static extern void string_list_free(cef_string_list_t list);

        /// <summary>
        /// Creates a copy of an existing string list.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        // CEF_EXPORT cef_string_list_t cef_string_list_copy(cef_string_list_t list);
        [DllImport(DllName, EntryPoint = "cef_string_list_copy", CallingConvention = Call)]
        public static extern cef_string_list_t string_list_copy(cef_string_list_t list);
    }
}
