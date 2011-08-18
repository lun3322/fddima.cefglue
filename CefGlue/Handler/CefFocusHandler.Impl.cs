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
            // TODO: CefFocusHandler.on_take_focus
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when the browser component is requesting focus. |isWidget|
        /// will be true if the focus is requested for a child widget of the
        /// browser window. Return false to allow the focus to be set or true to
        /// cancel setting the focus.
        /// </summary>
        private int on_set_focus(cef_focus_handler_t* self, cef_browser_t* browser, int isWidget)
        {
            // TODO: CefFocusHandler.on_set_focus
            throw new NotImplementedException();
        }


    }
}
