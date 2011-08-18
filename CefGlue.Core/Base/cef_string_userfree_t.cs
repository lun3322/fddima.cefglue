namespace CefGlue.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;

    /// <summary>
    /// CEF userfree string.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = libcef.StructPack)]
    internal unsafe struct cef_string_userfree_t
    {
        private IntPtr _pointer;
    }

    internal static unsafe partial class libcef
    {
    }
}
