namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefKeyboardHandler
    {
        /// <summary>
        /// Called when the browser component receives a keyboard event. |type|
        /// is the type of keyboard event, |code| is the windows scan-code for
        /// the event, |modifiers| is a set of bit-flags describing any pressed
        /// modifier keys and |isSystemKey| is true if Windows considers this a
        /// 'system key' message (see http://msdn.microsoft.com/en-
        /// us/library/ms646286(VS.85).aspx). Return true if the keyboard event
        /// was handled or false to allow the browser component to handle the
        /// event.
        /// </summary>
        private int on_key_event(cef_keyboard_handler_t* self, cef_browser_t* browser, cef_handler_keyevent_type_t type, int code, int modifiers, int isSystemKey)
        {
            ThrowIfObjectDisposed();
            // TODO: CefKeyboardHandler.on_key_event
            throw new NotImplementedException();
        }


    }
}
