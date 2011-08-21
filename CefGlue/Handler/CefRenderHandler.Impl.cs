namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefRenderHandler
    {
        /// <summary>
        /// Called to retrieve the view rectangle which is relative to screen
        /// coordinates. Return true if the rectangle was provided.
        /// </summary>
        private int get_view_rect(cef_render_handler_t* self, cef_browser_t* browser, cef_rect_t* rect)
        {
            ThrowIfObjectDisposed();
            // TODO: CefRenderHandler.get_view_rect
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called to retrieve the simulated screen rectangle. Return true if the
        /// rectangle was provided.
        /// </summary>
        private int get_screen_rect(cef_render_handler_t* self, cef_browser_t* browser, cef_rect_t* rect)
        {
            ThrowIfObjectDisposed();
            // TODO: CefRenderHandler.get_screen_rect
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called to retrieve the translation from view coordinates to actual
        /// screen coordinates. Return true if the screen coordinates were
        /// provided.
        /// </summary>
        private int get_screen_point(cef_render_handler_t* self, cef_browser_t* browser, int viewX, int viewY, int* screenX, int* screenY)
        {
            ThrowIfObjectDisposed();
            // TODO: CefRenderHandler.get_screen_point
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when the browser wants to show or hide the popup widget. The
        /// popup should be shown if |show| is true and hidden if |show| is
        /// false.
        /// </summary>
        private void on_popup_show(cef_render_handler_t* self, cef_browser_t* browser, int show)
        {
            ThrowIfObjectDisposed();
            // TODO: CefRenderHandler.on_popup_show
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when the browser wants to move or resize the popup widget.
        /// |rect| contains the new location and size.
        /// </summary>
        private void on_popup_size(cef_render_handler_t* self, cef_browser_t* browser, /*const*/ cef_rect_t* rect)
        {
            ThrowIfObjectDisposed();
            // TODO: CefRenderHandler.on_popup_size
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when an element should be painted. |type| indicates whether
        /// the element is the view or the popup widget. |buffer| contains the
        /// pixel data for the whole image. |dirtyRect| indicates the portion of
        /// the image that has been repainted. On Windows |buffer| will be
        /// width*height*4 bytes in size and represents a BGRA image with an
        /// upper-left origin.
        /// </summary>
        private void on_paint(cef_render_handler_t* self, cef_browser_t* browser, cef_paint_element_type_t type, /*const*/ cef_rect_t* dirtyRect, /*const*/ void* buffer)
        {
            ThrowIfObjectDisposed();
            // TODO: CefRenderHandler.on_paint
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when the browser window's cursor has changed.
        /// </summary>
        private void on_cursor_change(cef_render_handler_t* self, cef_browser_t* browser, cef_cursor_handle_t cursor)
        {
            ThrowIfObjectDisposed();
            // TODO: CefRenderHandler.on_cursor_change
            throw new NotImplementedException();
        }


    }
}
