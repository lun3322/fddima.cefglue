namespace CefGlue
{
    using System;
    using CefGlue.Interop;

    unsafe partial class CefRequest
    {
        /// <summary>
        /// Create a new CefRequest object.
        /// </summary>
        public static CefRequest Create()
        {
            return CefRequest.From(
                NativeMethods.cef_request_create()
                );
        }

        /// <summary>
        /// Get the fully qualified URL.
        /// </summary>
        public string GetURL()
        {
            var n_result = cef_request_t.invoke_get_url(this.ptr);
            return n_result.GetStringAndFree();
        }

        /// <summary>
        /// Set the fully qualified URL.
        /// </summary>
        public void SetURL(string url)
        {
            fixed (char* url_str = url)
            {
                var n_url = new cef_string_t(url_str, url != null ? url.Length : 0);
                cef_request_t.invoke_set_url(this.ptr, &n_url);
            }
        }

        /// <summary>
        /// Get the request method type.
        /// The value will default to POST if post data is provided and GET otherwise.
        /// </summary>
        public string GetMethod()
        {
            var n_result = cef_request_t.invoke_get_method(this.ptr);
            return n_result.GetStringAndFree();
        }

        /// <summary>
        /// Set the request method type.
        /// </summary>
        public void SetMethod(string method)
        {
            fixed (char* method_str = method)
            {
                var n_method = new cef_string_t(method_str, method != null ? method.Length : 0);
                cef_request_t.invoke_set_method(this.ptr, &n_method);
            }
        }

        /// <summary>
        /// Get the post data.
        /// </summary>
        public CefPostData GetPostData()
        {
            return CefPostData.From(
                cef_request_t.invoke_get_post_data(this.ptr)
                );
        }

        /// <summary>
        /// Set the post data.
        /// </summary>
        public void SetPostData(CefPostData postData)
        {
            cef_request_t.invoke_set_post_data(this.ptr, postData.GetNativePointerAndAddRef());
        }

        /// <summary>
        /// Get the header values.
        /// </summary>
        public CefStringMultiMap GetHeaderMap()
        {
            var map = new CefStringMultiMap();
            cef_request_t.invoke_get_header_map(this.ptr, map.GetNativeHandle());
            return map;
        }

        /// <summary>
        /// Set the header values.
        /// </summary>
        public void SetHeaderMap(CefStringMultiMap headerMap)
        {
            cef_request_t.invoke_set_header_map(this.ptr, headerMap.GetNativeHandle());
        }

        /// <summary>
        /// Set all values at one time.
        /// </summary>
        public void Set(string url, string method, CefPostData postData, CefStringMultiMap headerMap)
        {
            fixed (char* url_str = url)
            fixed (char* method_str = method)
            {
                var n_url = new cef_string_t(url_str, url != null ? url.Length : 0);
                var n_method = new cef_string_t(method_str, method != null ? method.Length : 0);

                cef_request_t.invoke_set(this.ptr, &n_url, &n_method, postData.GetNativePointerAndAddRef(), headerMap.GetNativeHandle());
            }
        }

        /// <summary>
        /// Get the flags used in combination with CefWebURLRequest.
        /// </summary>
        public CefWebUrlRequestFlags GetFlags()
        {
            return (CefWebUrlRequestFlags)cef_request_t.invoke_get_flags(this.ptr);
        }

        /// <summary>
        /// Set the flags used in combination with CefWebURLRequest.
        /// </summary>
        public void SetFlags(CefWebUrlRequestFlags flags)
        {
            cef_request_t.invoke_set_flags(this.ptr, (cef_weburlrequest_flags_t)flags);
        }

        /// <summary>
        /// Set the URL to the first party for cookies used in combination with CefWebUrlRequest.
        /// </summary>
        public string GetFirstPartyForCookies()
        {
            var n_result = cef_request_t.invoke_get_first_party_for_cookies(this.ptr);
            return n_result.GetStringAndFree();
        }

        /// <summary>
        /// Get the URL to the first party for cookies used in combination with CefWebUrlRequest.
        /// </summary>
        public void SetFirstPartyForCookies(string url)
        {
            fixed (char* url_str = url)
            {
                var n_url = new cef_string_t(url_str, url != null ? url.Length : 0);

                cef_request_t.invoke_set_first_party_for_cookies(this.ptr, &n_url);
            }
        }


    }
}
