namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefFocusHandler
    {
        /// <summary>
        /// Called when the browser component is about to loose focus. For
        /// instance, if focus was on the last HTML element and the user pressed
        /// the TAB key. |next| will be true if the browser is giving focus to
        /// the next component and false if the browser is giving focus to the
        /// previous component.
        /// </summary>
        private void on_take_focus(cef_focus_handler_t* self, cef_browser_t* browser, int next)
        {
            ThrowIfObjectDisposed();

            var m_browser = CefBrowser.From(browser);

            this.OnTakeFocus(m_browser, next != 0);
        }

        /// <summary>
        /// Called when the browser component is about to loose focus.
        /// For instance, if focus was on the last HTML element and the user pressed the TAB key.
        /// |next| will be true if the browser is giving focus to the next component and false if the browser is giving focus to the previous component.
        /// </summary>
        protected virtual void OnTakeFocus(CefBrowser browser, bool next)
        {
        }


        /// <summary>
        /// Called when the browser component is requesting focus. |source| indicates
        /// where the focus request is originating from. Return false to allow the
        /// focus to be set or true to cancel setting the focus.
        /// </summary>
        private int on_set_focus(cef_focus_handler_t* self, cef_browser_t* browser, cef_handler_focus_source_t source)
        {
            ThrowIfObjectDisposed();

            var mBrowser = CefBrowser.From(browser);
            var handled = this.OnSetFocus(mBrowser, (CefHandlerFocusSource)source);

            return handled ? 1 : 0;
        }

        /// <summary>
        /// Called when the browser component is requesting focus.
        /// |source| indicates where the focus request is originating from.
        /// Return false to allow the focus to be set or true to cancel setting the focus.
        /// </summary>
        protected virtual bool OnSetFocus(CefBrowser browser, CefHandlerFocusSource source)
        {
            return false;
        }

    }
}
