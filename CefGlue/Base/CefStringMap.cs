namespace CefGlue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core;

    public sealed class CefStringMap
    {
        private cef_string_map_t map;

        public CefStringMap()
        {
            this.map = cef_string_map_t.Create();
        }

        ~CefStringMap()
        {
            this.map.Free();
        }

        internal cef_string_map_t GetNativeHandle()
        {
            return this.map;
        }

        public int Count { get { return this.map.Count; } }

        public bool TryGetValue(string key, out string value)
        {
            return this.map.Find(key, out value);
        }

        public string GetValue(string key)
        {
            string value;
            if (this.TryGetValue(key, out value))
            {
                return value;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public string this[string key] { get { return GetValue(key); } }

        public bool TryGetKey(int index, out string key)
        {
            return this.map.Key(index, out key);
        }

        public bool TryGetValue(int index, out string value)
        {
            return this.map.Value(index, out value);
        }

        public bool Append(string key, string value)
        {
            return this.map.Append(key, value);
        }

        public void Clear()
        {
            this.map.Clear();
        }

    }
}
