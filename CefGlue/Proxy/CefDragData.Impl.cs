namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefDragData
    {
        /// <summary>
        /// Returns true if the drag data is a link.
        /// </summary>
        public bool IsLink
        {
            get
            {
                return cef_drag_data_t.invoke_is_link(this.ptr) != 0;
            }
        }

        /// <summary>
        /// Returns true if the drag data is a text or html fragment.
        /// </summary>
        public bool IsFragment
        {
            get
            {
                return cef_drag_data_t.invoke_is_fragment(this.ptr) != 0;
            }
        }

        /// <summary>
        /// Returns true if the drag data is a file.
        /// </summary>
        public bool IsFile
        {
            get
            {
                return cef_drag_data_t.invoke_is_file(this.ptr) != 0;
            }
        }

        /// <summary>
        /// Return the link URL that is being dragged.
        /// </summary>
        public string GetLinkURL()
        {
            var nResult = cef_drag_data_t.invoke_get_link_url(this.ptr);
            return nResult.GetStringAndFree();
        }

        /// <summary>
        /// Return the title associated with the link being dragged.
        /// </summary>
        public string GetLinkTitle()
        {
            var nResult = cef_drag_data_t.invoke_get_link_title(this.ptr);
            return nResult.GetStringAndFree();
        }

        /// <summary>
        /// Return the metadata, if any, associated with the link being dragged.
        /// </summary>
        public string GetLinkMetadata()
        {
            var nResult = cef_drag_data_t.invoke_get_link_metadata(this.ptr);
            return nResult.GetStringAndFree();
        }

        /// <summary>
        /// Return the plain text fragment that is being dragged.
        /// </summary>
        public string GetFragmentText()
        {
            var nResult = cef_drag_data_t.invoke_get_fragment_text(this.ptr);
            return nResult.GetStringAndFree();
        }

        /// <summary>
        /// Return the text/html fragment that is being dragged.
        /// </summary>
        public string GetFragmentHtml()
        {
            var nResult = cef_drag_data_t.invoke_get_fragment_html(this.ptr);
            return nResult.GetStringAndFree();
        }

        /// <summary>
        /// Return the base URL that the fragment came from. This value is used
        /// for resolving relative URLs and may be empty.
        /// </summary>
        public string GetFragmentBaseURL()
        {
            var nResult = cef_drag_data_t.invoke_get_fragment_base_url(this.ptr);
            return nResult.GetStringAndFree();
        }

        /// <summary>
        /// Return the extension of the file being dragged out of the browser window.
        /// </summary>
        public string GetFileExtension()
        {
            var nResult = cef_drag_data_t.invoke_get_file_extension(this.ptr);
            return nResult.GetStringAndFree();
        }

        /// <summary>
        /// Return the name of the file being dragged out of the browser window.
        /// </summary>
        public string GetFileName()
        {
            var nResult = cef_drag_data_t.invoke_get_file_name(this.ptr);
            return nResult.GetStringAndFree();
        }

        /// <summary>
        /// Retrieve the list of file names that are being dragged into the
        /// browser window.
        /// </summary>
        public CefStringList GetFileNames()
        {
            CefStringList result = new CefStringList();
            
            var success = cef_drag_data_t.invoke_get_file_names(this.ptr, result.GetNativeHandle()) != 0;

            if (success)
            {
                return result;
            }
            else
            {
                result.Dispose();
                return null;
            }
        }


    }
}
