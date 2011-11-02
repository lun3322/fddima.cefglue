﻿namespace CefGlue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CefGlue.Interop;

    /// <summary>
    /// String multimap.
    /// </summary>
    public sealed unsafe class CefStringMultiMap
    {
        private cef_string_multimap_t map;

        /// <summary>
        /// Allocate a new string multimap.
        /// </summary>
        public CefStringMultiMap()
        {
            this.map = libcef.cef_string_multimap_alloc();
        }

        ~CefStringMultiMap()
        {
            this.Dispose();
        }

        /// <summary>
        /// Dispose the string multimap.
        /// </summary>
        public void Dispose()
        {
            if (this.map != cef_string_multimap_t.Null)
            {
                libcef.cef_string_multimap_free(this.map);
                this.map = cef_string_multimap_t.Null;
            }
            GC.SuppressFinalize(this);
        }

        internal cef_string_multimap_t GetNativeHandle()
        {
            return this.map;
        }

        /// <summary>
        /// Return the number of elements in the string multimap.
        /// </summary>
        public int Count
        {
            get { return libcef.cef_string_multimap_size(this.map); }
        }

        /// <summary>
        /// Return the number of values with the specified key.
        /// </summary>
        public int FindCount(string key)
        {
            fixed (char* key_str = key)
            {
                var n_key = new cef_string_t(key_str, key != null ? key.Length : 0);

                return libcef.cef_string_multimap_find_count(this.map, &n_key);
            }
        }

        /// <summary>
        /// Return the value_index-th value with the specified key.
        /// </summary>
        public string GetValue(string key, int valueIndex)
        {
            cef_string_t n_value = new cef_string_t();
            fixed (char* key_str = key)
            {
                var n_key = new cef_string_t(key_str, key != null ? key.Length : 0);

                var success = libcef.cef_string_multimap_enumerate(this.map, &n_key, valueIndex, &n_value) != 0;
                var result = success ? cef_string_t.ToString(&n_value) : null;
                cef_string_t.Clear(&n_value);
                // TODO: throw if failed
                return result;
            }
        }

        /// <summary>
        /// Return the key at the specified zero-based string multimap index.
        /// </summary>
        public string GetKey(int index)
        {
            cef_string_t n_key = new cef_string_t();
            var success = libcef.cef_string_multimap_key(this.map, index, &n_key) != 0;
            var result = success ? cef_string_t.ToString(&n_key) : null;
            cef_string_t.Clear(&n_key);
            // TODO: throw if failed
            return result;
        }

        /// <summary>
        /// Return the value at the specified zero-based string multimap index.
        /// </summary>
        public string GetValue(int index)
        {
            cef_string_t n_value = new cef_string_t();
            var success = libcef.cef_string_multimap_value(this.map, index, &n_value) != 0;
            var result = success ? cef_string_t.ToString(&n_value) : null;
            cef_string_t.Clear(&n_value);
            // TODO: throw if failed
            return result;
        }

        /// <summary>
        /// Append a new key/value pair at the end of the string multimap.
        /// </summary>
        public void Append(string key, string value)
        {
            fixed (char* key_str = key)
            fixed (char* value_str = value)
            {
                var n_key = new cef_string_t(key_str, key != null ? key.Length : 0);
                var n_value = new cef_string_t(value_str, value != null ? value.Length : 0);

                var result = libcef.cef_string_multimap_append(this.map, &n_key, &n_value);

                if (result == 0) throw new InvalidOperationException("CefStringMultiMap.Append failed.");
            }
        }

        /// <summary>
        /// Clear the string multimap.
        /// </summary>
        public void Clear()
        {
            libcef.cef_string_multimap_clear(this.map);
        }
    }
}
