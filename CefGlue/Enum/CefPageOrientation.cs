namespace CefGlue
{
    using System;
    using Core;

    /// <summary>
    /// Page orientation for printing.
    /// </summary>
    public enum CefPageOrientation
    {
        Portrait = cef_page_orientation.PORTRAIT,
        Landscape = cef_page_orientation.LANDSCAPE,
    }
}
