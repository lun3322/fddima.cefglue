namespace CefGlue
{
    using System;
    using Core;

    /// <summary>
    /// Post data elements may represent either bytes or files.
    /// </summary>
    public enum CefPostDataElementType
    {
        Empty = cef_postdataelement_type_t.PDE_TYPE_EMPTY,
        Bytes = cef_postdataelement_type_t.PDE_TYPE_BYTES,
        File = cef_postdataelement_type_t.PDE_TYPE_FILE,
    }
}
