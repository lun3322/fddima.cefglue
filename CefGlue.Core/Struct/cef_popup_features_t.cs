namespace CefGlue.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Popup window features.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = libcef.StructPack)]
    internal unsafe partial struct cef_popup_features_t
    {
        int x;
        bool_t xSet;
        int y;
        bool_t ySet;
        int width;
        bool_t widthSet;
        int height;
        bool_t heightSet;

        bool_t menuBarVisible;
        bool_t statusBarVisible;
        bool_t toolBarVisible;
        bool_t locationBarVisible;
        bool_t scrollbarsVisible;
        bool_t resizable;

        bool_t fullscreen;
        bool_t dialog;

        cef_string_list_t additionalFeatures;
    }
}
