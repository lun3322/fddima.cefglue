namespace CefGlue.Interop
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// CEF string multimap.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = libcef.StructPack)]
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

    internal static unsafe partial class libcef
    {
        /// <summary>
        /// Allocate a new string multimap.
        /// </summary>
        // CEF_EXPORT cef_string_multimap_t cef_string_multimap_alloc();
        [DllImport(DllName, CallingConvention = Call)]
        public static extern cef_string_multimap_t cef_string_multimap_alloc();

        /// <summary>
        /// Return the number of elements in the string multimap.
        /// </summary>
        // CEF_EXPORT int cef_string_multimap_size(cef_string_multimap_t map);
        [DllImport(DllName, CallingConvention = Call)]
        public static extern int cef_string_multimap_size(cef_string_multimap_t map);

        /// <summary>
        /// Return the number of values with the specified key.
        /// </summary>
        // CEF_EXPORT int cef_string_multimap_find_count(cef_string_multimap_t map,
        //                                               const cef_string_t* key);
        [DllImport(DllName, CallingConvention = Call)]
        public static extern int cef_string_multimap_find_count(cef_string_multimap_t map, /* const */ cef_string_t* key);

        /// <summary>
        /// Return the value_index-th value with the specified key.
        /// </summary>
        // CEF_EXPORT int cef_string_multimap_enumerate(cef_string_multimap_t map,
        //                                              const cef_string_t* key,
        //                                              int value_index,
        //                                              cef_string_t* value);
        [DllImport(DllName, CallingConvention = Call)]
        public static extern int cef_string_multimap_enumerate(cef_string_multimap_t map, /* const */ cef_string_t* key, int value_index, cef_string_t* value);

        /// <summary>
        /// Return the key at the specified zero-based string multimap index.
        /// </summary>
        // CEF_EXPORT int cef_string_multimap_key(cef_string_multimap_t map, int index,
        //                                        cef_string_t* key);
        [DllImport(DllName, CallingConvention = Call)]
        public static extern int cef_string_multimap_key(cef_string_multimap_t map, int index, cef_string_t* key);

        /// <summary>
        /// Return the value at the specified zero-based string multimap index.
        /// </summary>
        // CEF_EXPORT int cef_string_multimap_value(cef_string_multimap_t map, int index,
        //                                          cef_string_t* value);
        [DllImport(DllName, CallingConvention = Call)]
        public static extern int cef_string_multimap_value(cef_string_multimap_t map, int index, cef_string_t* value);

        /// <summary>
        /// Append a new key/value pair at the end of the string multimap.
        /// </summary>
        // CEF_EXPORT int cef_string_multimap_append(cef_string_multimap_t map,
        //                                           const cef_string_t* key,
        //                                           const cef_string_t* value);
        [DllImport(DllName, CallingConvention = Call)]
        public static extern int cef_string_multimap_append(cef_string_multimap_t map, /* const */ cef_string_t* key, /* const */ cef_string_t* value);

        /// <summary>
        /// Clear the string multimap.
        /// </summary>
        // CEF_EXPORT void cef_string_multimap_clear(cef_string_multimap_t map);
        [DllImport(DllName, CallingConvention = Call)]
        public static extern void cef_string_multimap_clear(cef_string_multimap_t map);

        /// <summary>
        /// Free the string multimap.
        /// </summary>
        // CEF_EXPORT void cef_string_multimap_free(cef_string_multimap_t map);
        [DllImport(DllName, CallingConvention = Call)]
        public static extern void cef_string_multimap_free(cef_string_multimap_t map);
    }
}
