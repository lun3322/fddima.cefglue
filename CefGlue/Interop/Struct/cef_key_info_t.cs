namespace CefGlue.Interop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;

    ///
    // Structure representing key information.
    ///
    [StructLayout(LayoutKind.Sequential, Pack = NativeMethods.CefStructPack)]
    internal unsafe partial struct cef_key_info_t
    {
        public int key;
        public bool_t sysChar;
        public bool_t imeChar;
    }
}
