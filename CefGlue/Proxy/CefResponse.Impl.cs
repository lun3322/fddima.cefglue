namespace CefGlue
{
    using System;
    using CefGlue.Interop;

    unsafe partial class CefResponse
    {
        /// <summary>
        /// Get the response status code.
        /// </summary>
        public int GetStatus()
        {
            return cef_response_t.invoke_get_status(this.ptr);
        }

        /// <summary>
        /// Set the response status code.
        /// </summary>
        public void SetStatus(int status)
        {
            cef_response_t.invoke_set_status(this.ptr, status);
        }

        /// <summary>
        /// Get the response status text.
        /// </summary>
        public string GetStatusText()
        {
            var n_result = cef_response_t.invoke_get_status_text(this.ptr);
            return n_result.GetStringAndFree();
        }

        /// <summary>
        /// Set the response status text.
        /// </summary>
        public void SetStatusText(string statusText)
        {
            fixed (char* statusText_str = statusText)
            {
                var n_statusText = new cef_string_t(statusText_str, statusText != null ? statusText.Length : 0);

                cef_response_t.invoke_set_status_text(this.ptr, &n_statusText);
            }
        }

        /// <summary>
        /// Get the response mime type.
        /// </summary>
        public string GetMimeType()
        {
            var n_result = cef_response_t.invoke_get_mime_type(this.ptr);
            return n_result.GetStringAndFree();
        }

        /// <summary>
        /// Set the response mime type.
        /// </summary>
        public void SetMimeType(string mimeType)
        {
            fixed (char* mimeType_str = mimeType)
            {
                var n_mimeType = new cef_string_t(mimeType_str, mimeType != null ? mimeType.Length : 0);

                cef_response_t.invoke_set_mime_type(this.ptr, &n_mimeType);
            }
        }

        /// <summary>
        /// Get the value for the specified response header field.
        /// </summary>
        public string GetHeader(string name)
        {
            fixed (char* name_str = name)
            {
                var n_name = new cef_string_t(name_str, name != null ? name.Length : 0);

                var n_result = cef_response_t.invoke_get_header(this.ptr, &n_name);
                return n_result.GetStringAndFree();
            }
        }

        /// <summary>
        /// Get all response header fields.
        /// </summary>
        public CefStringMultiMap GetHeaderMap()
        {
            var map = new CefStringMultiMap();
            cef_response_t.invoke_get_header_map(this.ptr, map.GetNativeHandle());
            return map;
        }

        /// <summary>
        /// Set all response header fields.
        /// </summary>
        public void SetHeaderMap(CefStringMultiMap headerMap)
        {
            cef_response_t.invoke_set_header_map(this.ptr, headerMap.GetNativeHandle());
        }

    }
}
