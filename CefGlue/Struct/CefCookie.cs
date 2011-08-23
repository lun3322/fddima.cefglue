namespace CefGlue
{
    using System;
    using Core;

    /// <summary>
    /// Cookie information.
    /// </summary>
    public sealed unsafe class CefCookie : IDisposable
    {
        internal static CefCookie From(cef_cookie_t* ptr)
        {
            return new CefCookie(ptr);
        }

        private cef_cookie_t* ptr;

        private CefCookie(cef_cookie_t* ptr)
        {
            this.ptr = ptr;
        }

        ~CefCookie()
        {
            this.ptr = null;
        }

        public void Dispose()
        {
            this.ptr = null;
        }

        // TODO: cef_cookie_t <> CefCookie (read-only)
    }
}
