namespace CefGlue.Core
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    /// <summary>
    /// CEF string list.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = libcef.StructPack)]
    internal unsafe struct cef_string_list_t
    {
        public static cef_string_list_t Create()
        {
            return libcef.string_list_alloc();
        }

        public static cef_string_list_t Create(IEnumerable<string> collection)
        {
            var list = libcef.string_list_alloc();
            foreach (var value in collection)
            {
                fixed (char* str = value)
                {
                    cef_string_t n_value = new cef_string_t(str, value != null ? value.Length : 0);
                    libcef.string_list_append(list, &n_value);
                }
            }
            return list;
        }

        private IntPtr handle;

        public bool IsAllocated { get { return this.handle != IntPtr.Zero; } }

        public void Free()
        {
            if (IsAllocated)
            {
                libcef.string_list_free(this);
                handle = IntPtr.Zero;
            }
        }

        public int Count
        {
            get
            {
                return libcef.string_list_size(this);
            }
        }

        public bool Value(int index, out string value)
        {
            cef_string_t n_value = new cef_string_t();
            var result = libcef.string_list_value(this, index, ref n_value) != 0 ? true : false;
            value = result ? cef_string_t.ToString(&n_value) : null;
            cef_string_t.Clear(&n_value);
            return result;
        }

        public void Append(string value)
        {
            fixed (char* str = value)
            {
                cef_string_t n_value = new cef_string_t(str, value != null ? value.Length : 0);
                libcef.string_list_append(this, &n_value);
            }
        }

        public void Clear()
        {
            libcef.string_list_clear(this);
        }

        public cef_string_list_t Copy()
        {
            return libcef.string_list_copy(this);
        }

        public List<string> ToList()
        {
            var list = new List<string>();

            var count = this.Count;
            for (var i = 0; i < count; i++)
            {
                string value;
                if (Value(i, out value))
                {
                    list.Add(value);
                }
                else throw new InvalidOperationException();
            }

            return list;
        }
    }

    internal static unsafe partial class libcef
    {
        /// <summary>
        /// Allocate a new string list.
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
