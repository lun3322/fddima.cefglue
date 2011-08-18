namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefResponse
    {
        /// <summary>
        /// Get the response status code.
        /// </summary>
        /* FIXME: CefResponse.GetStatus public */
        int GetStatus()
        {
            // TODO: CefResponse.GetStatus
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the response status code.
        /// </summary>
        /* FIXME: CefResponse.SetStatus public */
        void SetStatus(int status)
        {
            // TODO: CefResponse.SetStatus
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the response status text.
        /// </summary>
        /* FIXME: CefResponse.GetStatusText public */
        cef_string_userfree_t GetStatusText()
        {
            // TODO: CefResponse.GetStatusText
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the response status text.
        /// </summary>
        /* FIXME: CefResponse.SetStatusText public */
        void SetStatusText(/*const*/ cef_string_t* statusText)
        {
            // TODO: CefResponse.SetStatusText
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the response mime type.
        /// </summary>
        /* FIXME: CefResponse.GetMimeType public */
        cef_string_userfree_t GetMimeType()
        {
            // TODO: CefResponse.GetMimeType
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the response mime type.
        /// </summary>
        /* FIXME: CefResponse.SetMimeType public */
        void SetMimeType(/*const*/ cef_string_t* mimeType)
        {
            // TODO: CefResponse.SetMimeType
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the value for the specified response header field.
        /// </summary>
        /* FIXME: CefResponse.GetHeader public */
        cef_string_userfree_t GetHeader(/*const*/ cef_string_t* name)
        {
            // TODO: CefResponse.GetHeader
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all response header fields.
        /// </summary>
        /* FIXME: CefResponse.GetHeaderMap public */
        void GetHeaderMap(cef_string_map_t headerMap)
        {
            // TODO: CefResponse.GetHeaderMap
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set all response header fields.
        /// </summary>
        /* FIXME: CefResponse.SetHeaderMap public */
        void SetHeaderMap(cef_string_map_t headerMap)
        {
            // TODO: CefResponse.SetHeaderMap
            throw new NotImplementedException();
        }


    }
}
