namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefFindHandler
    {
        /// <summary>
        /// Called to report find results returned by CefBrowser::Find().
        /// |identifer| is the identifier passed to CefBrowser::Find(), |count|
        /// is the number of matches currently identified, |selectionRect| is the
        /// location of where the match was found (in window coordinates),
        /// |activeMatchOrdinal| is the current position in the search results,
        /// and |finalUpdate| is true if this is the last find notification.
        /// </summary>
        private void on_find_result(cef_find_handler_t* self, cef_browser_t* browser, int identifier, int count, /*const*/ cef_rect_t* selectionRect, int activeMatchOrdinal, int finalUpdate)
        {
            // TODO: CefFindHandler.on_find_result
            throw new NotImplementedException();
        }


    }
}
