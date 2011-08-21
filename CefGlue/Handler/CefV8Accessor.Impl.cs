namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefV8Accessor
    {
        /// <summary>
        /// Called to get an accessor value. |name| is the name of the property
        /// being accessed. |object| is the This() object from V8's AccessorInfo
        /// structure. |retval| is the value to return for this property. Return
        /// true if handled.
        /// </summary>
        private int get(cef_v8accessor_t* self, /*const*/ cef_string_t* name, cef_v8value_t* @object, cef_v8value_t** retval)
        {
            ThrowIfObjectDisposed();
            // TODO: CefV8Accessor.get
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called to set an accessor value. |name| is the name of the property
        /// being accessed. |value| is the new value being assigned to this
        /// property. |object| is the This() object from V8's AccessorInfo
        /// structure. Return true if handled.
        /// </summary>
        private int set(cef_v8accessor_t* self, /*const*/ cef_string_t* name, cef_v8value_t* @object, cef_v8value_t* value)
        {
            ThrowIfObjectDisposed();
            // TODO: CefV8Accessor.set
            throw new NotImplementedException();
        }


    }
}
