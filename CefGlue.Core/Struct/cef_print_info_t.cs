namespace CefGlue.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

    ///
    // Class representing print context information.
    ///
    [StructLayout(LayoutKind.Sequential, Pack = libcef.StructPack)]
    internal unsafe partial struct cef_print_info_t
    {
        // HDC m_hDC;
        IntPtr m_hDC;
        //RECT m_Rect;
        RECT m_Rect;
        double m_Scale;
    }
}
