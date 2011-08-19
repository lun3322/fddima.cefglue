namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefDisplayHandler
    {
        /// <summary>
        /// Called when the navigation state has changed.
        /// </summary>
        private void on_nav_state_change(cef_display_handler_t* self, cef_browser_t* browser, int canGoBack, int canGoForward)
        {
            ThrowIfObjectDisposed();

            var m_browser = CefBrowser.FromPointer(browser);
            this.OnNavStateChange(m_browser, canGoBack != 0, canGoForward != 0);
        }

        /// <summary>
        /// Called when the navigation state has changed.
        /// </summary>
        protected virtual void OnNavStateChange(CefBrowser browser, bool canGoBack, bool canGoForward)
        {
        }

        /// <summary>
        /// Called when a frame's address has changed.
        /// </summary>
        private void on_address_change(cef_display_handler_t* self, cef_browser_t* browser, cef_frame_t* frame, /*const*/ cef_string_t* url)
        {
            ThrowIfObjectDisposed();

            var m_browser = CefBrowser.FromPointer(browser);
            var m_frame = CefFrame.FromPointer(frame);
            var m_url = cef_string_t.ToString(url);
            this.OnAddressChange(m_browser, m_frame, m_url);
        }

        /// <summary>
        /// Called when a frame's address has changed.
        /// </summary>
        protected virtual void OnAddressChange(CefBrowser browser, CefFrame frame, string url)
        {
        }

        /// <summary>
        /// Called when the page title changes.
        /// </summary>
        private void on_title_change(cef_display_handler_t* self, cef_browser_t* browser, /*const*/ cef_string_t* title)
        {
            ThrowIfObjectDisposed();

            var m_browser = CefBrowser.FromPointer(browser);
            var m_title = cef_string_t.ToString(title);
            this.OnTitleChange(m_browser, m_title);
        }

        /// <summary>
        /// Called when the page title changes.
        /// </summary>
        protected virtual void OnTitleChange(CefBrowser browser, string title)
        {
        }

        /// <summary>
        /// Called when the browser is about to display a tooltip. |text|
        /// contains the text that will be displayed in the tooltip. To handle
        /// the display of the tooltip yourself return true. Otherwise, you can
        /// optionally modify |text| and then return false to allow the browser
        /// to display the tooltip.
        /// </summary>
        private int on_tooltip(cef_display_handler_t* self, cef_browser_t* browser, cef_string_t* text)
        {
            ThrowIfObjectDisposed();

            var m_browser = CefBrowser.FromPointer(browser);
            var m_text = cef_string_t.ToString(text);

            var o_text = m_text;
            var result = this.OnTooltip(m_browser, ref m_text);

            if (result == false && (object)m_text != o_text)
            {
                cef_string_t.Copy(m_text, text);
            }

            return result ? 1 : 0;
        }

        /// <summary>
        /// Called when the browser is about to display a tooltip.
        /// |text| contains the text that will be displayed in the tooltip.
        /// To handle the display of the tooltip yourself return true.
        /// Otherwise, you can optionally modify |text| and then return false to allow the browser to display the tooltip.
        /// </summary>
        protected virtual bool OnTooltip(CefBrowser browser, ref string text)
        {
            // FIXME: API must return enum
            return false;
        }

        /// <summary>
        /// Called when the browser receives a status message.
        /// |text| contains the text that will be displayed in the status message and |type| indicates the status message type.
        /// </summary>
        private void on_status_message(cef_display_handler_t* self, cef_browser_t* browser, /*const*/ cef_string_t* value, cef_handler_statustype_t type)
        {
            ThrowIfObjectDisposed();

            // TODO: we can do not expose this event if same message arrived -> no needed creating proxy, but if we do not create proxy we must call releaseref
            // also this optimization can be done if we store state per-browser, not per-handler
            // or we can do it per-handler

            var m_browser = CefBrowser.FromPointer(browser);
            var m_value = cef_string_t.ToString(value);
            var m_type = (CefHandlerStatusType)type;
            this.OnStatusMessage(m_browser, m_value, m_type);
        }

        /// <summary>
        /// Called when the browser receives a status message.
        /// |text| contains the text that will be displayed in the status message and |type| indicates the status message type.
        /// </summary>
        protected virtual void OnStatusMessage(CefBrowser browser, string value, CefHandlerStatusType type)
        {
        }

        /// <summary>
        /// Called to display a console message.
        /// Return true to stop the message from being output to the console.
        /// </summary>
        private int on_console_message(cef_display_handler_t* self, cef_browser_t* browser, /*const*/ cef_string_t* message, /*const*/ cef_string_t* source, int line)
        {
            ThrowIfObjectDisposed();

            var m_browser = CefBrowser.FromPointer(browser);
            var m_message = cef_string_t.ToString(message);
            var m_source = cef_string_t.ToString(source);

            var result = this.OnConsoleMessage(m_browser, m_message, m_source, line);

            return result ? 1 : 0;
        }

        /// <summary>
        /// Called to display a console message.
        /// Return true to stop the message from being output to the console.
        /// </summary>
        protected virtual bool OnConsoleMessage(CefBrowser browser, string message, string source, int line)
        {
            // FIXME: API 
            return false;
        }


    }
}
