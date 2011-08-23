namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefPostData
    {
        /// <summary>
        /// Create a new CefPostData object.
        /// </summary>
        public static CefPostData Create()
        {
            return CefPostData.From(
                libcef.post_data_create()
                );
        }

        /// <summary>
        /// Returns the number of existing post data elements.
        /// </summary>
        public int GetElementCount()
        {
            return this.get_element_count(this.ptr);
        }

        /// <summary>
        /// Retrieve the post data elements.
        /// </summary>
        public CefPostDataElement GetElements(int elementIndex)
        {
            return CefPostDataElement.From(
                this.get_elements(this.ptr, elementIndex)
                );
        }

        /// <summary>
        /// Remove the specified post data element.
        /// Returns true if the removal succeeds.
        /// </summary>
        public bool RemoveElement(CefPostDataElement element)
        {
            return this.remove_element(this.ptr, element.GetNativePointerAndAddRef()) != 0;
        }

        /// <summary>
        /// Add the specified post data element.
        /// Returns true if the add succeeds.
        /// </summary>
        public bool AddElement(CefPostDataElement element)
        {
            return this.add_element(this.ptr, element.GetNativePointerAndAddRef()) != 0;
        }

        /// <summary>
        /// Remove all existing post data elements.
        /// </summary>
        public void RemoveElements()
        {
            this.remove_elements(this.ptr);
        }

    }
}
