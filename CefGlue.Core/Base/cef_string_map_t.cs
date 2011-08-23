namespace CefGlue.Core
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    /// <summary>
    /// CEF string map.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = libcef.StructPack)]
    internal unsafe struct cef_string_map_t
    {
        public static cef_string_map_t Create()
        {
            return libcef.string_map_alloc();
        }

        private IntPtr handle;

        public bool IsAllocated { get { return this.handle != IntPtr.Zero; } }

        public void Free()
        {
            if (IsAllocated)
            {
                libcef.string_map_free(this);
                handle = IntPtr.Zero;
            }
        }

        public int Count { get { return libcef.string_map_size(this); } }

        public bool Find(string key, out string value)
        {
            fixed (char* key_str = key)
            {
                var n_key = new cef_string_t(key_str, key != null ? key.Length : 0);
                cef_string_t n_value = new cef_string_t();

                var result = libcef.string_map_find(this, &n_key, &n_value) != 0;

                value = result ? n_value.ToString() : null;

                cef_string_t.Clear(&n_value);
                return result;
            }
        }

        public bool Key(int index, out string key)
        {
            cef_string_t n_key = new cef_string_t();
            var result = libcef.string_map_key(this, index, &n_key) != 0;
            key = result ? n_key.ToString() : null;
            cef_string_t.Clear(&n_key);
            return result;
        }

        public bool Value(int index, out string value)
        {
            cef_string_t n_value = new cef_string_t();
            var result = libcef.string_map_value(this, index, &n_value) != 0;
            value = result ? n_value.ToString() : null;
            cef_string_t.Clear(&n_value);
            return result;
        }

        public bool Append(string key, string value)
        {
            fixed (char* key_str = key)
            fixed (char* value_str = value)
            {
                var n_key = new cef_string_t(key_str, key != null ? key.Length : 0);
                var n_value = new cef_string_t(value_str, value != null ? value.Length : 0);

                return libcef.string_map_append(this, &n_key, &n_value) != 0;
            }
        }

        public void Clear()
        {
            libcef.string_map_clear(this);
        }
    }

    internal static unsafe partial class libcef
    {
        /// <summary>
        /// Allocate a new string map.
        /// </summary>
        /// <returns></returns>
        // CEF_EXPORT cef_string_map_t cef_string_map_alloc();
        [DllImport(DllName, EntryPoint = "cef_string_map_alloc", CallingConvention = Call)]
        public static extern cef_string_map_t string_map_alloc();

        ///
        /// Return the number of elements in the string map.
        ///
        // CEF_EXPORT int cef_string_map_size(cef_string_map_t map);
        [DllImport(DllName, EntryPoint = "cef_string_map_size", CallingConvention = Call)]
        public static extern int string_map_size(cef_string_map_t map);

        ///
        /// Return the value assigned to the specified key.
        ///
        // CEF_EXPORT int cef_string_map_find(cef_string_map_t map, const cef_string_t* key, cef_string_t* value);
        [DllImport(DllName, EntryPoint = "cef_string_map_find", CallingConvention = Call)]
        public static extern int string_map_find(cef_string_map_t map, /* const */ cef_string_t* key, cef_string_t* value);

        ///
        /// Return the key at the specified zero-based string map index.
        ///
        // CEF_EXPORT int cef_string_map_key(cef_string_map_t map, int index, cef_string_t* key);
        [DllImport(DllName, EntryPoint = "cef_string_map_key", CallingConvention = Call)]
        public static extern int string_map_key(cef_string_map_t map, int index, cef_string_t* key);

        ///
        /// Return the value at the specified zero-based string map index.
        ///
        // CEF_EXPORT int cef_string_map_value(cef_string_map_t map, int index, cef_string_t* value);
        [DllImport(DllName, EntryPoint = "cef_string_map_value", CallingConvention = Call)]
        public static extern int string_map_value(cef_string_map_t map, int index, cef_string_t* value);

        ///
        /// Append a new key/value pair at the end of the string map.
        ///
        // CEF_EXPORT int cef_string_map_append(cef_string_map_t map, const cef_string_t* key, const cef_string_t* value);
        [DllImport(DllName, EntryPoint = "cef_string_map_append", CallingConvention = Call)]
        public static extern int string_map_append(cef_string_map_t map, /* const */ cef_string_t* key, /* const */ cef_string_t* value);

        ///
        /// Clear the string map.
        ///
        // CEF_EXPORT void cef_string_map_clear(cef_string_map_t map);
        [DllImport(DllName, EntryPoint = "cef_string_map_clear", CallingConvention = Call)]
        public static extern void string_map_clear(cef_string_map_t map);

        ///
        /// Free the string map.
        ///
        // CEF_EXPORT void cef_string_map_free(cef_string_map_t map);
        [DllImport(DllName, EntryPoint = "cef_string_map_free", CallingConvention = Call)]
        public static extern void string_map_free(cef_string_map_t map);
    }
}
