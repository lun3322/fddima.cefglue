namespace CefGlue
{
    using System;
    using Core;

    /// <summary>
    /// Supported menu ID values.
    /// </summary>
    public enum CefHandlerMenuId
    {
        NavBack = cef_handler_menuid_t.MENU_ID_NAV_BACK,
        NavForward = cef_handler_menuid_t.MENU_ID_NAV_FORWARD,
        NavReload = cef_handler_menuid_t.MENU_ID_NAV_RELOAD,
        NavReloadNoCache = cef_handler_menuid_t.MENU_ID_NAV_RELOAD_NOCACHE,
        NavStop = cef_handler_menuid_t.MENU_ID_NAV_STOP,
        Undo = cef_handler_menuid_t.MENU_ID_UNDO,
        Redo = cef_handler_menuid_t.MENU_ID_REDO,
        Cut = cef_handler_menuid_t.MENU_ID_CUT,
        Copy = cef_handler_menuid_t.MENU_ID_COPY,
        Paste = cef_handler_menuid_t.MENU_ID_PASTE,
        Delete = cef_handler_menuid_t.MENU_ID_DELETE,
        SelectAll = cef_handler_menuid_t.MENU_ID_SELECTALL,
        Print = cef_handler_menuid_t.MENU_ID_PRINT,
        ViewSource = cef_handler_menuid_t.MENU_ID_VIEWSOURCE,
    }
}
