namespace CefGlue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CefGlue.Interop;

    public sealed unsafe class CefStringList
    {
        internal static cef_string_list* CreateHandle()
        {
            return NativeMethods.cef_string_list_alloc();
        }

        internal static cef_string_list* CreateHandle(IEnumerable<string> collection)
        {
            var handle = CreateHandle();
            foreach (var value in collection)
            {
                fixed (char* str = value)
                {
                    cef_string_t nValue = new cef_string_t(str, value != null ? value.Length : 0);
                    NativeMethods.cef_string_list_append(handle, &nValue);
                }
            }
            return handle;
        }

        internal static void DestroyHandle(cef_string_list* handle)
        {
            NativeMethods.cef_string_list_free(handle);
        }

        private cef_string_list* handle;

        /// <summary>
        /// Create new empty string list.
        /// </summary>
        public CefStringList()
        {
            this.handle = CreateHandle();
        }

        public CefStringList(IEnumerable<string> collection)
        {
            throw new NotImplementedException();
            // this.list = cef_string_list_t.Create(collection);
        }

        internal CefStringList(cef_string_list* list)
        {
            // TODO: make static FromHandle method, and use private ctor
            this.handle = list;
        }

        ~CefStringList()
        {
            this.Dispose(false);
        }

        internal void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (this.handle != null)
            {
                DestroyHandle(this.handle);
                this.handle = null;
            }
        }

        internal cef_string_list* Handle
        {
            get
            {
                return this.handle;
            }
        }

        public int Count
        {
            get
            {
                // TODO: debug checks
                return NativeMethods.cef_string_list_size(this.handle);
            }
        }

        public bool TryGetValue(int index, out string value)
        {
            cef_string_t nValue = new cef_string_t();
            var result = NativeMethods.cef_string_list_value(this.handle, index, ref nValue) != 0;
            value = result ? cef_string_t.ToString(&nValue) : null;
            cef_string_t.Clear(&nValue);
            return result;
        }

        public string this[int index]
        {
            get
            {
                string value;
                if (this.TryGetValue(index, out value))
                {
                    return value;
                }
                else
                {
                    throw new KeyNotFoundException();
                }
            }
        }

        public void Add(string value)
        {
            // TODO: debug checks
            fixed (char* str = value)
            {
                cef_string_t nValue = new cef_string_t(str, value != null ? value.Length : 0);
                NativeMethods.cef_string_list_append(this.handle, &nValue);
            }
        }

        public void Clear()
        {
            NativeMethods.cef_string_list_clear(this.handle);
        }

        public CefStringList Clone()
        {
            return new CefStringList(
                NativeMethods.cef_string_list_copy(this.handle)
                );
        }

        private static IEnumerable<string> emptySequence = new List<string>();

        public IEnumerable<string> AsEnumerable()
        {
            // TODO: CefStringList must be IEnumerable<string>

            var count = this.Count;
            if (count == 0)
            {
                return emptySequence;
            }
            else return AsEnumerableCore(count);
        }

        private IEnumerable<string> AsEnumerableCore(int count)
        {
            for (var i = 0; i < count; i++)
            {
                yield return this[i];
            }
        }
    }
}
