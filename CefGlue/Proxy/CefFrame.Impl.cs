namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefFrame
    {
        /// <summary>
        /// Execute undo in this frame.
        /// </summary>
        /* FIXME: CefFrame.Undo public */
        void Undo()
        {
            // TODO: CefFrame.Undo
            throw new NotImplementedException();
        }

        /// <summary>
        /// Execute redo in this frame.
        /// </summary>
        /* FIXME: CefFrame.Redo public */
        void Redo()
        {
            // TODO: CefFrame.Redo
            throw new NotImplementedException();
        }

        /// <summary>
        /// Execute cut in this frame.
        /// </summary>
        /* FIXME: CefFrame.Cut public */
        void Cut()
        {
            // TODO: CefFrame.Cut
            throw new NotImplementedException();
        }

        /// <summary>
        /// Execute copy in this frame.
        /// </summary>
        /* FIXME: CefFrame.Copy public */
        void Copy()
        {
            // TODO: CefFrame.Copy
            throw new NotImplementedException();
        }

        /// <summary>
        /// Execute paste in this frame.
        /// </summary>
        /* FIXME: CefFrame.Paste public */
        void Paste()
        {
            // TODO: CefFrame.Paste
            throw new NotImplementedException();
        }

        /// <summary>
        /// Execute delete in this frame.
        /// </summary>
        /* FIXME: CefFrame.Delete public */
        void Delete()
        {
            // TODO: CefFrame.Delete
            throw new NotImplementedException();
        }

        /// <summary>
        /// Execute select all in this frame.
        /// </summary>
        /* FIXME: CefFrame.SelectAll public */
        void SelectAll()
        {
            // TODO: CefFrame.SelectAll
            throw new NotImplementedException();
        }

        /// <summary>
        /// Execute printing in the this frame.  The user will be prompted with
        /// the print dialog appropriate to the operating system.
        /// </summary>
        /* FIXME: CefFrame.Print public */
        void Print()
        {
            // TODO: CefFrame.Print
            throw new NotImplementedException();
        }

        /// <summary>
        /// Save this frame's HTML source to a temporary file and open it in the
        /// default text viewing application.
        /// </summary>
        /* FIXME: CefFrame.ViewSource public */
        void ViewSource()
        {
            // TODO: CefFrame.ViewSource
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns this frame's HTML source as a string. This method should only
        /// be called on the UI thread.
        /// </summary>
        /* FIXME: CefFrame.GetSource public */
        cef_string_userfree_t GetSource()
        {
            // TODO: CefFrame.GetSource
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns this frame's display text as a string. This method should
        /// only be called on the UI thread.
        /// </summary>
        /* FIXME: CefFrame.GetText public */
        cef_string_userfree_t GetText()
        {
            // TODO: CefFrame.GetText
            throw new NotImplementedException();
        }

        /// <summary>
        /// Load the request represented by the |request| object.
        /// </summary>
        /* FIXME: CefFrame.LoadRequest public */
        void LoadRequest(cef_request_t* request)
        {
            // TODO: CefFrame.LoadRequest
            throw new NotImplementedException();
        }

        /// <summary>
        /// Load the specified |url|.
        /// </summary>
        public void LoadURL(string url)
        {
            cef_string_t n_url;
            cef_string_t.Copy(url, &n_url);

            this.load_url(this.ptr, &n_url);

            cef_string_t.Clear(&n_url);
        }

        /// <summary>
        /// Load the contents of |string| with the optional dummy target |url|.
        /// </summary>
        /* FIXME: CefFrame.LoadString public */
        void LoadString(/*const*/ cef_string_t* @string, /*const*/ cef_string_t* url)
        {
            // TODO: CefFrame.LoadString
            throw new NotImplementedException();
        }

        /// <summary>
        /// Load the contents of |stream| with the optional dummy target |url|.
        /// </summary>
        /* FIXME: CefFrame.LoadStream public */
        void LoadStream(cef_stream_reader_t* stream, /*const*/ cef_string_t* url)
        {
            // TODO: CefFrame.LoadStream
            throw new NotImplementedException();
        }

        /// <summary>
        /// Execute a string of JavaScript code in this frame. The |script_url|
        /// parameter is the URL where the script in question can be found, if
        /// any. The renderer may request this URL to show the developer the
        /// source of the error.  The |start_line| parameter is the base line
        /// number to use for error reporting.
        /// </summary>
        /* FIXME: CefFrame.ExecuteJavaScript public */
        void ExecuteJavaScript(/*const*/ cef_string_t* jsCode, /*const*/ cef_string_t* scriptUrl, int startLine)
        {
            // TODO: CefFrame.ExecuteJavaScript
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if this is the main frame.
        /// </summary>
        public bool IsMain
        {
            get
            {
                return this.is_main(this.ptr) != 0;
            }
        }

        /// <summary>
        /// Returns true if this is the focused frame. This method should only be
        /// called on the UI thread.
        /// </summary>
        public bool IsFocused
        {
            get
            {
                return this.is_focused(this.ptr) != 0;
            }
        }

        /// <summary>
        /// Returns this frame's name.
        /// </summary>
        /* FIXME: CefFrame.GetName public */
        cef_string_userfree_t GetName()
        {
            // TODO: CefFrame.GetName
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the URL currently loaded in this frame.
        /// This method should only be called on the UI thread.
        /// </summary>
        /* FIXME: CefFrame.GetURL public */
        cef_string_userfree_t GetURL()
        {
            // TODO: CefFrame.GetURL
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the browser that this frame belongs to.
        /// </summary>
        /* FIXME: CefFrame.GetBrowser public */
        cef_browser_t* GetBrowser()
        {
            // TODO: CefFrame.GetBrowser
            throw new NotImplementedException();
        }

        /// <summary>
        /// Visit the DOM document.
        /// </summary>
        /* FIXME: CefFrame.VisitDOM public */
        void VisitDOM(cef_domvisitor_t* visitor)
        {
            // TODO: CefFrame.VisitDOM
            throw new NotImplementedException();
        }


    }
}
