namespace CefGlue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core;

    public sealed class CefStringList
    {
        private cef_string_list_t list;

        /// <summary>
        /// Create new empty string list.
        /// </summary>
        public CefStringList()
        {
            this.list = cef_string_list_t.Create();
        }

        public CefStringList(IEnumerable<string> collection)
        {
            this.list = cef_string_list_t.Create(collection);
        }

        internal CefStringList(cef_string_list_t list)
        {
            this.list = list;
        }

        ~CefStringList()
        {
            this.list.Free();
        }

        internal void Dispose()
        {
            this.list.Free();
            GC.SuppressFinalize(this);
        }

        internal cef_string_list_t GetNativeHandle()
        {
            return this.list;
        }

        public int Count { get { return this.list.Count; } }

        public bool TryGetValue(int index, out string value)
        {
            return this.list.Value(index, out value);
        }

        public string GetValue(int index)
        {
            string value;
            if (TryGetValue(index, out value))
            {
                return value;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public string this[int index]
        {
            get { return GetValue(index); }
        }

        public void Add(string value)
        {
            this.list.Append(value);
        }

        public void Clear()
        {
            this.list.Clear();
        }

        public CefStringList Clone()
        {
            return new CefStringList(this.list.Copy());
        }

        private static IEnumerable<string> emptySequence = new string[0];

        public IEnumerable<string> AsEnumerable()
        {
            // TODO: CefStringList must be IEnumerable<string>
            // TODO: create empty enumerator for empty list

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
