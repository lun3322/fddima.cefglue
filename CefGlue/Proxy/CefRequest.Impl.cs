namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefRequest
    {
        /// <summary>
        /// Create a new CefRequest object.
        /// </summary>
        /* FIXME: CefRequest.CreateRequest public */
        static cef_request_t* CreateRequest()
        {
            // TODO: CefRequest.CreateRequest
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the fully qualified URL.
        /// </summary>
        /* FIXME: CefRequest.GetURL public */
        cef_string_userfree_t GetURL()
        {
            // TODO: CefRequest.GetURL
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the fully qualified URL.
        /// </summary>
        /* FIXME: CefRequest.SetURL public */
        void SetURL(/*const*/ cef_string_t* url)
        {
            // TODO: CefRequest.SetURL
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the request method type. The value will default to POST if post
        /// data is provided and GET otherwise.
        /// </summary>
        /* FIXME: CefRequest.GetMethod public */
        cef_string_userfree_t GetMethod()
        {
            // TODO: CefRequest.GetMethod
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the request method type.
        /// </summary>
        /* FIXME: CefRequest.SetMethod public */
        void SetMethod(/*const*/ cef_string_t* method)
        {
            // TODO: CefRequest.SetMethod
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the post data.
        /// </summary>
        /* FIXME: CefRequest.GetPostData public */
        cef_post_data_t* GetPostData()
        {
            // TODO: CefRequest.GetPostData
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the post data.
        /// </summary>
        /* FIXME: CefRequest.SetPostData public */
        void SetPostData(cef_post_data_t* postData)
        {
            // TODO: CefRequest.SetPostData
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the header values.
        /// </summary>
        /* FIXME: CefRequest.GetHeaderMap public */
        void GetHeaderMap(cef_string_map_t headerMap)
        {
            // TODO: CefRequest.GetHeaderMap
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the header values.
        /// </summary>
        /* FIXME: CefRequest.SetHeaderMap public */
        void SetHeaderMap(cef_string_map_t headerMap)
        {
            // TODO: CefRequest.SetHeaderMap
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set all values at one time.
        /// </summary>
        /* FIXME: CefRequest.Set public */
        void Set(/*const*/ cef_string_t* url, /*const*/ cef_string_t* method, cef_post_data_t* postData, cef_string_map_t headerMap)
        {
            // TODO: CefRequest.Set
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the flags used in combination with CefWebURLRequest.
        /// </summary>
        /* FIXME: CefRequest.GetFlags public */
        cef_weburlrequest_flags_t GetFlags()
        {
            // TODO: CefRequest.GetFlags
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the flags used in combination with CefWebURLRequest.
        /// </summary>
        /* FIXME: CefRequest.SetFlags public */
        void SetFlags(cef_weburlrequest_flags_t flags)
        {
            // TODO: CefRequest.SetFlags
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the URL to the first party for cookies used in combination with
        /// CefWebURLRequest.
        /// </summary>
        /* FIXME: CefRequest.GetFirstPartyForCookies public */
        cef_string_userfree_t GetFirstPartyForCookies()
        {
            // TODO: CefRequest.GetFirstPartyForCookies
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the URL to the first party for cookies used in combination with
        /// CefWebURLRequest.
        /// </summary>
        /* FIXME: CefRequest.SetFirstPartyForCookies public */
        void SetFirstPartyForCookies(/*const*/ cef_string_t* url)
        {
            // TODO: CefRequest.SetFirstPartyForCookies
            throw new NotImplementedException();
        }


    }
}
