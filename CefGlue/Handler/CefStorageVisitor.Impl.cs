namespace CefGlue
{
    using System;
    using CefGlue.Interop;

    unsafe partial class CefStorageVisitor
    {
        /// <summary>
        /// Method that will be called once for each key/value data pair in
        /// storage. |count| is the 0-based index for the current pair. |total|
        /// is the total number of pairs. Set |deleteData| to true to delete the
        /// pair currently being visited. Return false to stop visiting pairs.
        /// This method may never be called if no data is found.
        /// </summary>
        private int visit(cef_storage_visitor_t* self, cef_storage_type_t type, /*const*/ cef_string_t* origin, /*const*/ cef_string_t* key, /*const*/ cef_string_t* value, int count, int total, int* deleteData)
        {
            ThrowIfObjectDisposed();

            var mOrigin = cef_string_t.ToString(origin);
            var mKey = cef_string_t.ToString(key);
            var mValue = cef_string_t.ToString(value);

            bool mDeleteData = *deleteData != 0;

            var handled = this.Visit((CefStorageType)type, mOrigin, mKey, mValue, count, total, ref mDeleteData);

            *deleteData = mDeleteData ? 1 : 0;

            return handled ? 1 : 0;
        }

        /// <summary>
        /// Method that will be called once for each key/value data pair in storage.
        /// |count| is the 0-based index for the current pair.
        /// |total| is the total number of pairs.
        /// Set |deleteData| to true to delete the pair currently being visited.
        /// Return false to stop visiting pairs.
        /// This method may never be called if no data is found.
        /// </summary>
        protected virtual bool Visit(CefStorageType type, string origin, string key, string value, int count, int total, ref bool deleteData)
        {
            deleteData = false;
            return true;
        }

    }
}
