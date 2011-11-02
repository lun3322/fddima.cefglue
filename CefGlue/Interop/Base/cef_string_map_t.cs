namespace CefGlue.Interop
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// CEF string map.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeMethods.CefStructPack)]
    internal unsafe struct cef_string_map_t
    {
        public static cef_string_map_t Create()
        {
            return NativeMethods.cef_string_map_alloc();
        }

        private IntPtr handle;

        public bool IsAllocated { get { return this.handle != IntPtr.Zero; } }

        public void Free()
        {
            if (IsAllocated)
            {
                NativeMethods.cef_string_map_free(this);
                handle = IntPtr.Zero;
            }
        }

        public int Count { get { return NativeMethods.cef_string_map_size(this); } }

        public bool Find(string key, out string value)
        {
            fixed (char* key_str = key)
            {
                var n_key = new cef_string_t(key_str, key != null ? key.Length : 0);
                cef_string_t n_value = new cef_string_t();

                var result = NativeMethods.cef_string_map_find(this, &n_key, &n_value) != 0;

                value = result ? cef_string_t.ToString(&n_value) : null;

                cef_string_t.Clear(&n_value);
                return result;
            }
        }

        public bool Key(int index, out string key)
        {
            cef_string_t n_key = new cef_string_t();
            var result = NativeMethods.cef_string_map_key(this, index, &n_key) != 0;
            key = result ? cef_string_t.ToString(&n_key) : null;
            cef_string_t.Clear(&n_key);
            return result;
        }

        public bool Value(int index, out string value)
        {
            cef_string_t n_value = new cef_string_t();
            var result = NativeMethods.cef_string_map_value(this, index, &n_value) != 0;
            value = result ? cef_string_t.ToString(&n_value) : null;
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

                return NativeMethods.cef_string_map_append(this, &n_key, &n_value) != 0;
            }
        }

        public void Clear()
        {
            NativeMethods.cef_string_map_clear(this);
        }
    }
}
