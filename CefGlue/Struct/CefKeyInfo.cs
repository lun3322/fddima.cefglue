namespace CefGlue
{
    using System;
    using CefGlue.Interop;

    public struct CefKeyInfo
    {
        private int key;
        private bool sysChar;
        private bool imeChar;

        internal unsafe static CefKeyInfo From(cef_key_info_t* ptr)
        {
            return new CefKeyInfo(ptr);
        }

        internal unsafe CefKeyInfo(cef_key_info_t* ptr)
        {
            this.key = ptr->key;
            this.sysChar = ptr->sysChar;
            this.imeChar = ptr->imeChar;
        }

        public CefKeyInfo(int key, bool sysChar, bool imeChar)
        {
            this.key = key;
            this.sysChar = sysChar;
            this.imeChar = imeChar;
        }

        public int Key
        {
            get { return this.key; }
            set { this.key = value; }
        }

        public bool SysChar
        {
            get { return this.sysChar; }
            set { this.sysChar = value; }
        }

        public bool ImeChar
        {
            get { return this.imeChar; }
            set { this.imeChar = value; }
        }

        internal unsafe void To(cef_key_info_t* ptr)
        {
            ptr->key = this.key;
            ptr->sysChar = this.sysChar;
            ptr->imeChar = this.imeChar;
        }
    }
}
