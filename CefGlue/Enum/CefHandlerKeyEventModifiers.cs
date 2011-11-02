namespace CefGlue
{
    using System;
    using CefGlue.Interop;

    /// <summary>
    /// Key event modifiers.
    /// </summary>
    [Flags]
    public enum CefHandlerKeyEventModifiers
    {
        Shift = cef_handler_keyevent_modifiers_t.KEY_SHIFT,
        Ctrl = cef_handler_keyevent_modifiers_t.KEY_CTRL,
        Alt = cef_handler_keyevent_modifiers_t.KEY_ALT,
        Meta = cef_handler_keyevent_modifiers_t.KEY_META,
    }
}
