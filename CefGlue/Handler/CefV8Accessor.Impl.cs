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
        internal virtual int get(cef_v8accessor_t* self, /*const*/ cef_string_t* name, cef_v8value_t* @object, cef_v8value_t** retval)
        {
            ThrowIfObjectDisposed();

            var m_name = cef_string_t.ToString(name);
            var m_obj = CefV8Value.From(@object);
            CefV8Value m_returnValue;

            var handled = this.Get(m_name, m_obj, out m_returnValue);

            if (handled)
            {
                if (m_returnValue != null)
                {
                    *retval = m_returnValue.GetNativePointerAndAddRef();
                }
            }

            return handled ? 1 : 0;
        }

        /// <summary>
        /// Called to get an accessor value.
        /// |name| is the name of the property being accessed.
        /// |object| is the This() object from V8's AccessorInfo structure.
        /// |retval| is the value to return for this property.
        /// Return true if handled.
        /// </summary>
        protected virtual bool Get(string name, CefV8Value obj, out CefV8Value returnValue)
        {
            returnValue = null;
            return false;
        }


        /// <summary>
        /// Called to set an accessor value. |name| is the name of the property
        /// being accessed. |value| is the new value being assigned to this
        /// property. |object| is the This() object from V8's AccessorInfo
        /// structure. Return true if handled.
        /// </summary>
        internal virtual int set(cef_v8accessor_t* self, /*const*/ cef_string_t* name, cef_v8value_t* @object, cef_v8value_t* value)
        {
            ThrowIfObjectDisposed();

            var m_name = cef_string_t.ToString(name);
            var m_obj = CefV8Value.From(@object);
            var m_value = CefV8Value.From(value);

            var handled = this.Set(m_name, m_obj, m_value);

            return handled ? 1 : 0;
        }

        /// <summary>
        /// Called to set an accessor value.
        /// |name| is the name of the property being accessed.
        /// |value| is the new value being assigned to this property.
        /// |object| is the This() object from V8's AccessorInfo structure.
        /// Return true if handled.
        /// </summary>
        protected virtual bool Set(string name, CefV8Value obj, CefV8Value value)
        {
            return false;
        }


    }
}
