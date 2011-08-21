namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefBrowser
    {
        /// <summary>
        /// Create a new browser window using the window parameters specified by |windowInfo|.
        /// All values will be copied internally and the actual window will be created on the UI thread.
        /// This method call will not block.
        /// </summary>
        public static void Create(CefWindowInfo windowInfo, CefClient client, string url, CefBrowserSettings settings)
        {
            cef_string_t n_url;
            cef_string_t.Copy(url, &n_url);

            var result = libcef.browser_create(
                windowInfo.NativePointer,
                client.GetNativePointerAndAddRef(),
                &n_url,
                settings.NativePointer
                );

            cef_string_t.Clear(&n_url);

            if (result == 0) throw new InvalidOperationException("CefBrowser.Create error.");
        }

        /// <summary>
        /// Create a new browser window using the window parameters specified by |windowInfo|.
        /// This method should only be called on the UI thread.
        /// </summary>
        /* FIXME: CefBrowser.CreateBrowserSync public */
        static cef_browser_t* CreateBrowserSync(cef_window_info_t* windowInfo, cef_client_t* client, /*const*/ cef_string_t* url, /*const*/ cef_browser_settings_t* settings)
        {
            // TODO: CefBrowser.CreateBrowserSync
            throw new NotImplementedException();
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
        /// Returns the frame with the specified name, or NULL if not found. This
        /// method should only be called on the UI thread.
        /// </summary>
        /* FIXME: public */
        cef_frame_t* GetFrame( /*const*/ cef_string_t* name)
        {
            // TODO: CefBrowser.GetFrame
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the names of all existing frames. This method should only be
        /// called on the UI thread.
        /// </summary>
        /* FIXME: public */
        void GetFrameNames(cef_string_list_t names)
        {
            // TODO: CefBrowser.GetFrameNames
            throw new NotImplementedException();
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
            // TODO: check CefBrowser.Find
            cef_string_t n_searchText;
            cef_string_t.Copy(searchText, &n_searchText);

            this.find(this.ptr, identifier, &n_searchText, forward ? 1 : 0, matchCase ? 1 : 0, findNext ? 1 : 0);

            cef_string_t.Clear(&n_searchText);
        }

        /// <summary>
        /// Cancel all searches that are currently going on.
        /// </summary>
        /* FIXME: public */
        void StopFinding(int clearSelection)
        {
            // TODO: CefBrowser.StopFinding
            throw new NotImplementedException();
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
        /* FIXME: public */
        int GetSize(cef_paint_element_type_t type, int* width, int* height)
        {
            // TODO: CefBrowser.GetSize
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the size of the specified element.
        /// This method is only used when window rendering is disabled.
        /// </summary>
        /* FIXME: public */
        void SetSize(cef_paint_element_type_t type, int width, int height)
        {
            // TODO: CefBrowser.SetSize
            throw new NotImplementedException();
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
        /// Invalidate the |dirtyRect| region of the view. This method is only
        /// used when window rendering is disabled and will result in a call to
        /// HandlePaint().
        /// </summary>
        /* FIXME: public */
        void Invalidate( /*const*/ cef_rect_t* dirtyRect)
        {
            // TODO: CefBrowser.Invalidate
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the raw image data contained in the specified element without
        /// performing validation. The specified |width| and |height| dimensions
        /// must match the current element size. On Windows |buffer| must be
        /// width*height*4 bytes in size and represents a BGRA image with an
        /// upper-left origin. This method should only be called on the UI
        /// thread.
        /// </summary>
        /* FIXME: public */
        int GetImage(cef_paint_element_type_t type, int width, int height, void* buffer)
        {
            // TODO: CefBrowser.GetImage
            throw new NotImplementedException();
        }

        /// <summary>
        /// Send a key event to the browser.
        /// </summary>
        /* FIXME: public */
        void SendKeyEvent(cef_key_type_t type, int key, int modifiers, int sysChar, int imeChar)
        {
            // TODO: CefBrowser.SendKeyEvent
            throw new NotImplementedException();
        }

        /// <summary>
        /// Send a mouse click event to the browser. The |x| and |y| coordinates
        /// are relative to the upper-left corner of the view.
        /// </summary>
        /* FIXME: public */
        void SendMouseClickEvent(int x, int y, cef_mouse_button_type_t type, int mouseUp, int clickCount)
        {
            // TODO: CefBrowser.SendMouseClickEvent
            throw new NotImplementedException();
        }

        /// <summary>
        /// Send a mouse move event to the browser. The |x| and |y| coordinates
        /// are relative to the upper-left corner of the view.
        /// </summary>
        /* FIXME: public */
        void SendMouseMoveEvent(int x, int y, int mouseLeave)
        {
            // TODO: CefBrowser.SendMouseMoveEvent
            throw new NotImplementedException();
        }

        /// <summary>
        /// Send a mouse wheel event to the browser. The |x| and |y| coordinates
        /// are relative to the upper-left corner of the view.
        /// </summary>
        /* FIXME: public */
        void SendMouseWheelEvent(int x, int y, int delta)
        {
            // TODO: CefBrowser.SendMouseWheelEvent
            throw new NotImplementedException();
        }

        /// <summary>
        /// Send a focus event to the browser.
        /// </summary>
        /* FIXME: public */
        void SendFocusEvent(int setFocus)
        {
            // TODO: CefBrowser.SendFocusEvent
            throw new NotImplementedException();
        }

        /// <summary>
        /// Send a capture lost event to the browser.
        /// </summary>
        /* FIXME: public */
        void SendCaptureLostEvent()
        {
            // TODO: CefBrowser.SendCaptureLostEvent
            throw new NotImplementedException();
        }
    }
}