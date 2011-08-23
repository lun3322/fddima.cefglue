namespace CefGlue
{
    using System;
    using System.Collections.Generic;
    using Core;
    using Diagnostics;

    unsafe partial class CefBrowser
    {
        /// <summary>
        /// Create a new browser window using the window parameters specified by |windowInfo|.
        /// All values will be copied internally and the actual window will be created on the UI thread.
        /// This method call will not block.
        /// </summary>
        public static void Create(CefWindowInfo windowInfo, CefClient client, string url, CefBrowserSettings settings)
        {
            fixed (char* url_str = url)
            {
                cef_string_t n_url = new cef_string_t(url_str, url != null ? url.Length : 0);

                var result = libcef.browser_create(
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
            fixed (char* url_str = url)
            {
                cef_string_t n_url = new cef_string_t(url_str, url != null ? url.Length : 0);

                var browser = libcef.browser_create_sync(
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
            this.close_browser(this.ptr);
        }

        /// <summary>
        /// Returns true if the browser can navigate backwards.
        /// </summary>
        public bool CanGoBack
        {
            get
            {
                return this.can_go_back(this.ptr) != 0;
            }
        }

        /// <summary>
        /// Navigate backwards.
        /// </summary>
        public void GoBack()
        {
            this.go_back(this.ptr);
        }

        /// <summary>
        /// Returns true if the browser can navigate forwards.
        /// </summary>
        public bool CanGoForward
        {
            get
            {
                return this.can_go_forward(this.ptr) != 0;
            }
        }

        /// <summary>
        /// Navigate forwards.
        /// </summary>
        public void GoForward()
        {
            this.go_forward(this.ptr);
        }

        /// <summary>
        /// Reload the current page.
        /// </summary>
        public void Reload()
        {
            this.reload(this.ptr);
        }

        /// <summary>
        /// Reload the current page ignoring any cached data.
        /// </summary>
        public void ReloadIgnoreCache()
        {
            this.reload_ignore_cache(this.ptr);
        }

        /// <summary>
        /// Stop loading the page.
        /// </summary>
        public void StopLoad()
        {
            this.stop_load(this.ptr);
        }

        /// <summary>
        /// Set focus for the browser window.
        /// If |enable| is true focus will be set to the window.
        /// Otherwise, focus will be removed.
        /// </summary>
        public void SetFocus(bool enable)
        {
            this.set_focus(this.ptr, enable ? 1 : 0);
        }

        /// <summary>
        /// Retrieve the window handle for this browser.
        /// </summary>
        public IntPtr WindowHandle
        {
            get
            {
                return this.get_window_handle(this.ptr);
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
                return this.get_opener_window_handle(this.ptr);
            }
        }

        /// <summary>
        /// Returns true if the window is a popup window.
        /// </summary>
        public bool IsPopup
        {
            get
            {
                return this.is_popup(this.ptr) != 0;
            }
        }

        /// <summary>
        /// Returns the client for this browser.
        /// </summary>
        public CefClient GetClient()
        {
            return CefClient.From(
                this.get_client(this.ptr)
                );
        }

        /// <summary>
        /// Returns the main (top-level) frame for the browser window.
        /// </summary>
        public CefFrame GetMainFrame()
        {
            return CefFrame.From(
                this.get_main_frame(this.ptr)
                );
        }

        /// <summary>
        /// Returns the focused frame for the browser window.
        /// This method should only be called on the UI thread.
        /// </summary>
        public CefFrame GetFocusedFrame()
        {
            return CefFrame.From(
                this.get_focused_frame(this.ptr)
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
                    this.get_frame(this.ptr, &n_name)
                    );
            }
        }

        /// <summary>
        /// Returns the names of all existing frames.
        /// This method should only be called on the UI thread.
        /// </summary>
        public CefStringList GetFrameNames()
        {
            var list = new CefStringList();
            this.get_frame_names(this.ptr, list.GetNativeHandle());
            return list;
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
                this.find(this.ptr, identifier, &n_searchText, forward ? 1 : 0, matchCase ? 1 : 0, findNext ? 1 : 0);
            }
        }

        /// <summary>
        /// Cancel all searches that are currently going on.
        /// </summary>
        public void StopFinding(bool clearSelection)
        {
            this.stop_finding(this.ptr, clearSelection ? 1 : 0);
        }

        /// <summary>
        /// Get or sets the zoom level.
        /// </summary>
        public double ZoomLevel
        {
            get
            {
                return this.get_zoom_level(this.ptr);
            }
            set
            {
                this.set_zoom_level(this.ptr, value);
            }
        }

        /// <summary>
        /// Open developer tools in its own window.
        /// </summary>
        public void ShowDevTools()
        {
            this.show_dev_tools(this.ptr);
        }

        /// <summary>
        /// Explicitly close the developer tools window if one exists for this
        /// browser instance.
        /// </summary>
        public void CloseDevTools()
        {
            this.close_dev_tools(this.ptr);
        }

        /// <summary>
        /// Returns true if window rendering is disabled.
        /// </summary>
        public bool IsWindowRenderingDisabled
        {
            get
            {
                return this.is_window_rendering_disabled(this.ptr) != 0;
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

            var result = this.get_size(this.ptr, (cef_paint_element_type_t)type, &m_width, &m_height);

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
            this.set_size(this.ptr, (cef_paint_element_type_t)type, width, height);
        }

        /// <summary>
        /// Returns true if a popup is currently visible.
        /// This method should only be called on the UI thread.
        /// </summary>
        public bool IsPopupVisible
        {
            get
            {
                return this.is_popup_visible(this.ptr) != 0;
            }
        }

        /// <summary>
        /// Hide the currently visible popup, if any.
        /// </summary>
        public void HidePopup()
        {
            this.hide_popup(this.ptr);
        }

        /// <summary>
        /// Invalidate the |dirtyRect| region of the view.
        /// This method is only used when window rendering is disabled and will result in a call to HandlePaint().
        /// </summary>
        public void Invalidate(CefRect dirtyRect)
        {
            cef_rect_t n_dirtyRect;
            dirtyRect.To(&n_dirtyRect);

            this.invalidate(this.ptr, &n_dirtyRect);
        }

        /// <summary>
        /// Get the raw image data contained in the specified element without performing validation.
        /// The specified |width| and |height| dimensions must match the current element size.
        /// On Windows |buffer| must be width*height*4 bytes in size and represents a BGRA image with an upper-left origin.
        /// This method should only be called on the UI thread.
        /// </summary>
        public bool GetImage(CefPaintElementType type, int width, int height, IntPtr buffer)
        {
            return this.get_image(this.ptr, (cef_paint_element_type_t)type, width, height, (void*)buffer) != 0;
        }

        /// <summary>
        /// Send a key event to the browser.
        /// </summary>
        public void SendKeyEvent(CefKeyType type, int key, CefHandlerKeyEventModifiers modifiers, bool sysChar, bool imeChar)
        {
            this.send_key_event(this.ptr, (cef_key_type_t)type, key, (int)modifiers, sysChar ? 1 : 0, imeChar ? 1 : 0);
        }

        /// <summary>
        /// Send a mouse click event to the browser.
        /// The |x| and |y| coordinates are relative to the upper-left corner of the view.
        /// </summary>
        public void SendMouseClickEvent(int x, int y, CefMouseButtonType type, bool mouseUp, int clickCount)
        {
            this.send_mouse_click_event(this.ptr, x, y, (cef_mouse_button_type_t)type, mouseUp ? 1 : 0, clickCount);
        }

        /// <summary>
        /// Send a mouse move event to the browser.
        /// The |x| and |y| coordinates are relative to the upper-left corner of the view.
        /// </summary>
        public void SendMouseMoveEvent(int x, int y, bool mouseLeave)
        {
            this.send_mouse_move_event(this.ptr, x, y, mouseLeave ? 1 : 0);
        }

        /// <summary>
        /// Send a mouse wheel event to the browser.
        /// The |x| and |y| coordinates are relative to the upper-left corner of the view.
        /// </summary>
        public void SendMouseWheelEvent(int x, int y, int delta)
        {
            this.send_mouse_wheel_event(this.ptr, x, y, delta);
        }

        /// <summary>
        /// Send a focus event to the browser.
        /// </summary>
        public void SendFocusEvent(bool setFocus)
        {
            this.send_focus_event(this.ptr, setFocus ? 1 : 0);
        }

        /// <summary>
        /// Send a capture lost event to the browser.
        /// </summary>
        public void SendCaptureLostEvent()
        {
            this.send_capture_lost_event(this.ptr);
        }
    }
}
