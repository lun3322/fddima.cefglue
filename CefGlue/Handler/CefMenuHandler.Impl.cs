namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefMenuHandler
    {
        /// <summary>
        /// Called before a context menu is displayed. Return false to display
        /// the default context menu or true to cancel the display.
        /// </summary>
        private int on_before_menu(cef_menu_handler_t* self, cef_browser_t* browser, /*const*/ cef_handler_menuinfo_t* menuInfo)
        {
            ThrowIfObjectDisposed();
            // TODO: CefMenuHandler.on_before_menu
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called to optionally override the default text for a context menu
        /// item. |label| contains the default text and may be modified to
        /// substitute alternate text.
        /// </summary>
        private void get_menu_label(cef_menu_handler_t* self, cef_browser_t* browser, cef_handler_menuid_t menuId, cef_string_t* label)
        {
            ThrowIfObjectDisposed();
            // TODO: CefMenuHandler.get_menu_label
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when an option is selected from the default context menu.
        /// Return false to execute the default action or true to cancel the
        /// action.
        /// </summary>
        private int on_menu_action(cef_menu_handler_t* self, cef_browser_t* browser, cef_handler_menuid_t menuId)
        {
            ThrowIfObjectDisposed();
            // TODO: CefMenuHandler.on_menu_action
            throw new NotImplementedException();
        }


    }
}
