namespace CefGlue
{
    using System;
    using System.Collections.Generic;
    using CefGlue.Interop;
    using Diagnostics;
    using System.Runtime.InteropServices;

    unsafe partial class CefBrowser
    {
        /// <summary>
        /// Create a new browser window using the window parameters specified by |windowInfo|.
        /// All values will be copied internally and the actual window will be created on the UI thread.
        /// This method call will not block.
        /// </summary>
        public static void Create(CefWindowInfo windowInfo, CefClient client, string url, CefBrowserSettings settings)
        {
            if (windowInfo == null) throw new ArgumentNullException("windowInfo");
            if (client == null) throw new ArgumentNullException("client");
            if (settings == null) throw new ArgumentNullException("settings");

            fixed (char* url_str = url)
            {
                cef_string_t n_url = new cef_string_t(url_str, url != null ? url.Length : 0);

                var result = NativeMethods.cef_browser_create(
                    windowInfo.NativePointer,
                    client.GetNativePointerAndAddRef(),
                    &n_url,
                    settings.NativePointer
                    );

                if (result == 0) throw new InvalidOperationException("CefBrowser.Create error.");
            }
        }

        /// <summary>
        /// Create a new browser window using the window parameters specified by |windowInfo|.
        /// This method should only be called on the UI thread.
        /// </summary>
        public static CefBrowser CreateSync(CefWindowInfo windowInfo, CefClient client, string url, CefBrowserSettings settings)
        {
            if (windowInfo == null) throw new ArgumentNullException("windowInfo");
            if (client == null) throw new ArgumentNullException("client");
            if (settings == null) throw new ArgumentNullException("settings");

            fixed (char* url_str = url)
            {
                cef_string_t n_url = new cef_string_t(url_str, url != null ? url.Length : 0);

                var browser = NativeMethods.cef_browser_create_sync(
                    windowInfo.NativePointer,
                    client.GetNativePointerAndAddRef(),
                    &n_url,
                    settings.NativePointer
                    );

                if (browser == null) throw new InvalidOperationException("CefBrowser.CreateSync error.");

                return CefBrowser.From(browser);
            }
        }

        /// <summary>
        /// Closes this browser window.
        /// </summary>
        public void Close()
        {
            cef_browser_t.invoke_close_browser(this.ptr);
        }

        /// <summary>
        /// Returns true if the browser can navigate backwards.
        /// </summary>
        public bool CanGoBack
        {
            get
            {
                return cef_browser_t.invoke_can_go_back(this.ptr) != 0;
            }
        }

        /// <summary>
        /// Navigate backwards.
        /// </summary>
        public void GoBack()
        {
            cef_browser_t.invoke_go_back(this.ptr);
        }

        /// <summary>
        /// Returns true if the browser can navigate forwards.
        /// </summary>
        public bool CanGoForward
        {
            get
            {
                return cef_browser_t.invoke_can_go_forward(this.ptr) != 0;
            }
        }

        /// <summary>
        /// Navigate forwards.
        /// </summary>
        public void GoForward()
        {
            cef_browser_t.invoke_go_forward(this.ptr);
        }

        /// <summary>
        /// Reload the current page.
        /// </summary>
        public void Reload()
        {
            cef_browser_t.invoke_reload(this.ptr);
        }

        /// <summary>
        /// Reload the current page ignoring any cached data.
        /// </summary>
        public void ReloadIgnoreCache()
        {
            cef_browser_t.invoke_reload_ignore_cache(this.ptr);
        }

        /// <summary>
        /// Stop loading the page.
        /// </summary>
        public void StopLoad()
        {
            cef_browser_t.invoke_stop_load(this.ptr);
        }

        /// <summary>
        /// Set focus for the browser window.
        /// If |enable| is true focus will be set to the window.
        /// Otherwise, focus will be removed.
        /// </summary>
        public void SetFocus(bool enable)
        {
            cef_browser_t.invoke_set_focus(this.ptr, enable ? 1 : 0);
        }

        /// <summary>
        /// Retrieve the window handle for this browser.
        /// </summary>
        public IntPtr WindowHandle
        {
            get
            {
                return (IntPtr)cef_browser_t.invoke_get_window_handle(this.ptr);
            }
        }

        /// <summary>
        /// Retrieve the window handle of the browser that opened this browser.
        /// Will return NULL for non-popup windows.
        /// This method can be used in combination with custom handling of modal windows.
        /// </summary>
        public IntPtr OpenerWindowHandle
        {
            get
            {
                return (IntPtr)cef_browser_t.invoke_get_opener_window_handle(this.ptr);
            }
        }

        /// <summary>
        /// Returns true if the window is a popup window.
        /// </summary>
        public bool IsPopup
        {
            get
            {
                return cef_browser_t.invoke_is_popup(this.ptr) != 0;
            }
        }

        /// <summary>
        /// Returns true if a document has been loaded in the browser.
        /// </summary>
        public bool HasDocument
        {
            get
            {
                return cef_browser_t.invoke_has_document(this.ptr) != 0;
            }
        }

        /// <summary>
        /// Returns the client for this browser.
        /// </summary>
        public CefClient GetClient()
        {
            return CefClient.From(
                cef_browser_t.invoke_get_client(this.ptr)
                );
        }

        /// <summary>
        /// Returns the main (top-level) frame for the browser window.
        /// </summary>
        public CefFrame GetMainFrame()
        {
            return CefFrame.From(
                cef_browser_t.invoke_get_main_frame(this.ptr)
                );
        }

        /// <summary>
        /// Returns the focused frame for the browser window.
        /// This method should only be called on the UI thread.
        /// </summary>
        public CefFrame GetFocusedFrame()
        {
            return CefFrame.From(
                cef_browser_t.invoke_get_focused_frame(this.ptr)
                );
        }

        /// <summary>
        /// Returns the frame with the specified name, or NULL if not found.
        /// This method should only be called on the UI thread.
        /// </summary>
        public CefFrame GetFrame(string name)
        {
            fixed (char* str = name)
            {
                var n_name = new cef_string_t(str, name != null ? name.Length : 0);
                return CefFrame.FromOrDefault(
                    cef_browser_t.invoke_get_frame(this.ptr, &n_name)
                    );
            }
        }

        /// <summary>
        /// Returns the names of all existing frames.
        /// This method should only be called on the UI thread.
        /// </summary>
        public CefStringList GetFrameNames()
        {
            var result = new CefStringList();
            cef_browser_t.invoke_get_frame_names(this.ptr, result.Handle);
            return result;
        }

        /// <summary>
        /// Search for |searchText|.
        /// |identifier| can be used to have multiple searches running simultaniously.
        /// |forward| indicates whether to search forward or backward within the page.
        /// |matchCase| indicates whether the search should be case-sensitive.
        /// |findNext| indicates whether this is the first request or a follow-up.
        /// </summary>
        public void Find(int identifier, string searchText, bool forward, bool matchCase, bool findNext)
        {
            fixed (char* str = searchText)
            {
                var n_searchText = new cef_string_t(str, searchText != null ? searchText.Length : 0);
                cef_browser_t.invoke_find(this.ptr, identifier, &n_searchText, forward ? 1 : 0, matchCase ? 1 : 0, findNext ? 1 : 0);
            }
        }

        /// <summary>
        /// Cancel all searches that are currently going on.
        /// </summary>
        public void StopFinding(bool clearSelection)
        {
            cef_browser_t.invoke_stop_finding(this.ptr, clearSelection ? 1 : 0);
        }

        /// <summary>
        /// Get or sets the zoom level.
        /// </summary>
        public double ZoomLevel
        {
            get
            {
                return cef_browser_t.invoke_get_zoom_level(this.ptr);
            }
            set
            {
                cef_browser_t.invoke_set_zoom_level(this.ptr, value);
            }
        }

        /// <summary>
        /// Clear the back/forward browsing history.
        /// </summary>
        public void ClearHistory()
        {
            cef_browser_t.invoke_clear_history(this.ptr);
        }

        /// <summary>
        /// Open developer tools in its own window.
        /// </summary>
        public void ShowDevTools()
        {
            cef_browser_t.invoke_show_dev_tools(this.ptr);
        }

        /// <summary>
        /// Explicitly close the developer tools window if one exists for this
        /// browser instance.
        /// </summary>
        public void CloseDevTools()
        {
            cef_browser_t.invoke_close_dev_tools(this.ptr);
        }

        /// <summary>
        /// Returns true if window rendering is disabled.
        /// </summary>
        public bool IsWindowRenderingDisabled
        {
            get
            {
                return cef_browser_t.invoke_is_window_rendering_disabled(this.ptr) != 0;
            }
        }

        /// <summary>
        /// Get the size of the specified element.
        /// This method should only be called on the UI thread.
        /// </summary>
        public bool GetSize(CefPaintElementType type, out int width, out int height)
        {
            int m_width;
            int m_height;

            var result = cef_browser_t.invoke_get_size(this.ptr, (cef_paint_element_type_t)type, &m_width, &m_height);

            width = m_width;
            height = m_height;

            return result != 0;
        }

        /// <summary>
        /// Set the size of the specified element.
        /// This method is only used when window rendering is disabled.
        /// </summary>
        public void SetSize(CefPaintElementType type, int width, int height)
        {
            cef_browser_t.invoke_set_size(this.ptr, (cef_paint_element_type_t)type, width, height);
        }

        /// <summary>
        /// Returns true if a popup is currently visible.
        /// This method should only be called on the UI thread.
        /// </summary>
        public bool IsPopupVisible
        {
            get
            {
                return cef_browser_t.invoke_is_popup_visible(this.ptr) != 0;
            }
        }

        /// <summary>
        /// Hide the currently visible popup, if any.
        /// </summary>
        public void HidePopup()
        {
            cef_browser_t.invoke_hide_popup(this.ptr);
        }

        /// <summary>
        /// Invalidate the |dirtyRect| region of the view.
        /// This method is only used when window rendering is disabled and will result in a call to HandlePaint().
        /// </summary>
        public void Invalidate(CefRect dirtyRect)
        {
            cef_rect_t n_dirtyRect;
            dirtyRect.To(&n_dirtyRect);

            cef_browser_t.invoke_invalidate(this.ptr, &n_dirtyRect);
        }

        /// <summary>
        /// Get the raw image data contained in the specified element without performing validation.
        /// The specified |width| and |height| dimensions must match the current element size.
        /// On Windows |buffer| must be width*height*4 bytes in size and represents a BGRA image with an upper-left origin.
        /// This method should only be called on the UI thread.
        /// </summary>
        public bool GetImage(CefPaintElementType type, int width, int height, IntPtr buffer)
        {
            return cef_browser_t.invoke_get_image(this.ptr, (cef_paint_element_type_t)type, width, height, (void*)buffer) != 0;
        }

        /// <summary>
        /// Send a key event to the browser.
        /// </summary>
        public void SendKeyEvent(CefKeyType type, CefKeyInfo keyInfo, CefHandlerKeyEventModifiers modifiers)
        {
            cef_key_info_t n_keyInfo;
            keyInfo.To(&n_keyInfo);
#if WINDOWS
            // Windows implementation assumes that n_keyInfo.key = WPARAM and n_modifiers = LPARAM
            var n_modifiers = ToLParam(type, keyInfo, modifiers);
#else
            var n_modifiers = (int)modifiers;
#endif
            cef_browser_t.invoke_send_key_event(this.ptr, (cef_key_type_t)type, &n_keyInfo, n_modifiers);
        }

#if WINDOWS
        private static int ToLParam(CefKeyType type, CefKeyInfo keyInfo, CefHandlerKeyEventModifiers modifiers)
        {
            unchecked
            {
                var scanCode = MapVirtualKey((uint)keyInfo.Key, 0);
                var lparam = 0x00000001 | (scanCode << 16); // Scan code, repeat=1
                if (IsExtendedVirtualKey(keyInfo.Key))
                    lparam |= (1u << 24); // Extended code if required

                switch (type)
                {
                    case CefKeyType.KeyUp:
                        lparam |= (1u << 30); // The previous key state. The value is always 1 for a WM_KEYUP message.
                        lparam |= (1u << 31); // The transition state. The value is always 1 for a WM_KEYUP message.
                        break;
                    case CefKeyType.KeyDown:
                        break;
                    case CefKeyType.Char:
                        if (keyInfo.Key > 0 && (modifiers & CefHandlerKeyEventModifiers.Alt) > 0)
                            lparam |= (1u << 29); // The context code. The value is 1 if the ALT key is held down while the key is pressed; otherwise, the value is 0.
                        break;
                    default:
                        throw new NotImplementedException();
                }

                return (int)lparam;
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);

        private static bool IsExtendedVirtualKey(int vk)
        {
            switch (vk)
            {
                case 33: // Page Up
                case 34: // Page down
                case 35: // End
                case 36: // Home
                case 37: // Left
                case 38: // Up
                case 39: // Right
                case 40: // Down
                case 45: // Insert
                case 46: // Delete
                case 163: // Right Ctrl
                case 165: // Right Alt
                    return true;
                default:
                    return false;
            }
        }
#endif

        /// <summary>
        /// Send a mouse click event to the browser.
        /// The |x| and |y| coordinates are relative to the upper-left corner of the view.
        /// </summary>
        public void SendMouseClickEvent(int x, int y, CefMouseButtonType type, bool mouseUp, int clickCount)
        {
            cef_browser_t.invoke_send_mouse_click_event(this.ptr, x, y, (cef_mouse_button_type_t)type, mouseUp ? 1 : 0, clickCount);
        }

        /// <summary>
        /// Send a mouse move event to the browser.
        /// The |x| and |y| coordinates are relative to the upper-left corner of the view.
        /// </summary>
        public void SendMouseMoveEvent(int x, int y, bool mouseLeave)
        {
            cef_browser_t.invoke_send_mouse_move_event(this.ptr, x, y, mouseLeave ? 1 : 0);
        }

        /// <summary>
        /// Send a mouse wheel event to the browser.
        /// The |x| and |y| coordinates are relative to the upper-left corner of the view.
        /// </summary>
        public void SendMouseWheelEvent(int x, int y, int deltaX, int deltaY)
        {
            cef_browser_t.invoke_send_mouse_wheel_event(this.ptr, x, y, deltaX, deltaY);
        }

        /// <summary>
        /// Send a focus event to the browser.
        /// </summary>
        public void SendFocusEvent(bool setFocus)
        {
            cef_browser_t.invoke_send_focus_event(this.ptr, setFocus ? 1 : 0);
        }

        /// <summary>
        /// Send a capture lost event to the browser.
        /// </summary>
        public void SendCaptureLostEvent()
        {
            cef_browser_t.invoke_send_capture_lost_event(this.ptr);
        }

        /// <summary>
        /// Returns the globally unique identifier for this browser.
        /// </summary>
        public int Identifier
        {
            get
            {
                return cef_browser_t.invoke_get_identifier(this.ptr);
            }
        }
    }
}
