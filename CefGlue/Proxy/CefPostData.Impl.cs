namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefPostData
    {
        /// <summary>
        /// Create a new CefPostData object.
        /// </summary>
        /* FIXME: CefPostData.CreatePostData public */
        static cef_post_data_t* CreatePostData()
        {
            // TODO: CefPostData.CreatePostData
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the number of existing post data elements.
        /// </summary>
        /* FIXME: CefPostData.GetElementCount public */
        int GetElementCount()
        {
            // TODO: CefPostData.GetElementCount
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieve the post data elements.
        /// </summary>
        /* FIXME: CefPostData.GetElements public */
        cef_post_data_element_t* GetElements(int elementIndex)
        {
            // TODO: CefPostData.GetElements
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove the specified post data element.  Returns true if the removal
        /// succeeds.
        /// </summary>
        /* FIXME: CefPostData.RemoveElement public */
        int RemoveElement(cef_post_data_element_t* element)
        {
            // TODO: CefPostData.RemoveElement
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add the specified post data element.  Returns true if the add
        /// succeeds.
        /// </summary>
        /* FIXME: CefPostData.AddElement public */
        int AddElement(cef_post_data_element_t* element)
        {
            // TODO: CefPostData.AddElement
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove all existing post data elements.
        /// </summary>
        /* FIXME: CefPostData.RemoveElements public */
        void RemoveElements()
        {
            // TODO: CefPostData.RemoveElements
            throw new NotImplementedException();
        }


    }
}
