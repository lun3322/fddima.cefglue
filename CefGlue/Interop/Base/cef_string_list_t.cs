namespace CefGlue.Interop
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// CEF string list.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeMethods.CefStructPack)]
    internal unsafe struct cef_string_list_t
    {
        public static cef_string_list_t Create()
        {
            return NativeMethods.cef_string_list_alloc();
        }

        public static cef_string_list_t Create(IEnumerable<string> collection)
        {
            var list = NativeMethods.cef_string_list_alloc();
            foreach (var value in collection)
            {
                fixed (char* str = value)
                {
                    cef_string_t n_value = new cef_string_t(str, value != null ? value.Length : 0);
                    NativeMethods.cef_string_list_append(list, &n_value);
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
                NativeMethods.cef_string_list_free(this);
                handle = IntPtr.Zero;
            }
        }

        public int Count
        {
            get
            {
                return NativeMethods.cef_string_list_size(this);
            }
        }

        public bool Value(int index, out string value)
        {
            cef_string_t n_value = new cef_string_t();
            var result = NativeMethods.cef_string_list_value(this, index, ref n_value) != 0 ? true : false;
            value = result ? cef_string_t.ToString(&n_value) : null;
            cef_string_t.Clear(&n_value);
            return result;
        }

        public void Append(string value)
        {
            fixed (char* str = value)
            {
                cef_string_t n_value = new cef_string_t(str, value != null ? value.Length : 0);
                NativeMethods.cef_string_list_append(this, &n_value);
            }
        }

        public void Clear()
        {
            NativeMethods.cef_string_list_clear(this);
        }

        public cef_string_list_t Copy()
        {
            return NativeMethods.cef_string_list_copy(this);
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
}
