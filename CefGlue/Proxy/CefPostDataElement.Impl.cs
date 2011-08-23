namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefPostDataElement
    {
        /// <summary>
        /// Create a new CefPostDataElement object.
        /// </summary>
        public static CefPostDataElement Create()
        {
            return CefPostDataElement.From(
                libcef.post_data_element_create()
                );
        }

        /// <summary>
        /// Remove all contents from the post data element.
        /// </summary>
        public void SetToEmpty()
        {
            this.set_to_empty(this.ptr);
        }

        /// <summary>
        /// The post data element will represent a file.
        /// </summary>
        public void SetToFile(string fileName)
        {
            fixed (char* fileName_str = fileName)
            {
                var n_fileName = new cef_string_t(fileName_str, fileName != null ? fileName.Length : 0);
                this.set_to_file(this.ptr, &n_fileName);
            }
        }

        /// <summary>
        /// The post data element will represent bytes.
        /// The bytes passed in will be copied.
        /// </summary>
        public void SetToBytes(int size, IntPtr bytes)
        {
            this.set_to_bytes(this.ptr, size, (void*)bytes);

            // TODO: make usable method overrides (byte[] bytes, int offset, int length), (byte[] bytes, int length), (byte[] bytes)
        }

        /// <summary>
        /// Return the type of this post data element.
        /// </summary>
        public CefPostDataElementType Type
        {
            get
            {
                return (CefPostDataElementType)this.get_type(this.ptr);
            }
        }

        /// <summary>
        /// Return the file name.
        /// </summary>
        public string GetFile()
        {
            var n_result = this.get_file(this.ptr);
            return n_result.GetStringAndFree();
        }

        /// <summary>
        /// Return the number of bytes.
        /// </summary>
        public int GetBytesCount()
        {
            return this.get_bytes_count(this.ptr);
        }

        /// <summary>
        /// Read up to |size| bytes into |bytes| and return the number of bytes actually read.
        /// </summary>
        public int GetBytes(int size, IntPtr bytes)
        {
            return this.get_bytes(this.ptr, size, (void*)bytes);
            // TODO: make usable overrides
        }

    }
}
