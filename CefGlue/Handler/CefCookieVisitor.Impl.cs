namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefCookieVisitor
    {
        /// <summary>
        /// Method that will be called once for each cookie. |count| is the
        /// 0-based index for the current cookie. |total| is the total number of
        /// cookies. Set |deleteCookie| to true to delete the cookie currently
        /// being visited. Return false to stop visiting cookies. This method may
        /// never be called if no cookies are found.
        /// </summary>
        private int visit(cef_cookie_visitor_t* self, /*const*/ cef_cookie_t* cookie, int count, int total, int* deleteCookie)
        {
            ThrowIfObjectDisposed();
            // TODO: CefCookieVisitor.visit
            throw new NotImplementedException();
        }


    }
}
