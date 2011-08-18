namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefPostDataElement
    {
        /// <summary>
        /// Create a new CefPostDataElement object.
        /// </summary>
        /* FIXME: CefPostDataElement.CreatePostDataElement public */
        static cef_post_data_element_t* CreatePostDataElement()
        {
            // TODO: CefPostDataElement.CreatePostDataElement
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove all contents from the post data element.
        /// </summary>
        /* FIXME: CefPostDataElement.SetToEmpty public */
        void SetToEmpty()
        {
            // TODO: CefPostDataElement.SetToEmpty
            throw new NotImplementedException();
        }

        /// <summary>
        /// The post data element will represent a file.
        /// </summary>
        /* FIXME: CefPostDataElement.SetToFile public */
        void SetToFile(/*const*/ cef_string_t* fileName)
        {
            // TODO: CefPostDataElement.SetToFile
            throw new NotImplementedException();
        }

        /// <summary>
        /// The post data element will represent bytes.  The bytes passed in will
        /// be copied.
        /// </summary>
        /* FIXME: CefPostDataElement.SetToBytes public */
        void SetToBytes(int size, /*const*/ void* bytes)
        {
            // TODO: CefPostDataElement.SetToBytes
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the type of this post data element.
        /// </summary>
        /* FIXME: CefPostDataElement.GetType public */
        cef_postdataelement_type_t GetType()
        {
            // TODO: CefPostDataElement.GetType
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the file name.
        /// </summary>
        /* FIXME: CefPostDataElement.GetFile public */
        cef_string_userfree_t GetFile()
        {
            // TODO: CefPostDataElement.GetFile
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the number of bytes.
        /// </summary>
        /* FIXME: CefPostDataElement.GetBytesCount public */
        int GetBytesCount()
        {
            // TODO: CefPostDataElement.GetBytesCount
            throw new NotImplementedException();
        }

        /// <summary>
        /// Read up to |size| bytes into |bytes| and return the number of bytes
        /// actually read.
        /// </summary>
        /* FIXME: CefPostDataElement.GetBytes public */
        int GetBytes(int size, void* bytes)
        {
            // TODO: CefPostDataElement.GetBytes
            throw new NotImplementedException();
        }


    }
}
