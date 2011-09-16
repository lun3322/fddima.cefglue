namespace CefGlue.ScriptableObject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Core;

    internal sealed class ScriptableObjectV8Accessor : CefV8Accessor
    {
        private DispatchTable<PropertyDef> dispatchTable;
        private object instance;

        public ScriptableObjectV8Accessor(ScriptableObjectBinder binder)
            : this(binder, null)
        { }

        /// <summary>
        /// If instance == null -> then object reference will be got from object's userdata.
        /// Otherwise userdata ignored.
        /// </summary>
        public ScriptableObjectV8Accessor(ScriptableObjectBinder binder, object instance)
        {
            this.instance = instance;
            this.dispatchTable = binder.PropertyDispatchTable;
        }

        internal unsafe override int get(cef_v8accessor_t* self, cef_string_t* name, cef_v8value_t* @object, cef_v8value_t** retval)
        {
            var prop = this.dispatchTable.GetOrDefault(name);
            if (prop == null) return 0;

            var method = prop.GetMethod;
            if (method == null) return 0;

            var instance = this.instance;
            if (instance == null)
            {
                // TODO: self must be got from obj's userdata
                throw new NotImplementedException();
            }

            try
            {
                method.Invoke(instance, 0, null, retval);
            }
            catch (Exception ex)
            {
                // FIXME: cef issue #327 http://code.google.com/p/chromiumembedded/issues/detail?id=327
                throw new NotImplementedException();
            }

            // TODO: this pointer must be typed
            cef_v8value_t.invoke_release((cef_base_t*)@object);

            return 1;
        }

        internal override unsafe int set(cef_v8accessor_t* self, cef_string_t* name, cef_v8value_t* @object, cef_v8value_t* value)
        {
            var prop = this.dispatchTable.GetOrDefault(name);
            if (prop == null) return 0;

            var method = prop.SetMethod;
            if (method == null) return 0;

            var instance = this.instance;
            if (instance == null)
            {
                // TODO: self must be got from obj's userdata
                throw new NotImplementedException();
            }

            try
            {
                method.Invoke(instance, 1, &value, null);
            }
            catch (Exception ex)
            {
                // FIXME: cef issue #327 http://code.google.com/p/chromiumembedded/issues/detail?id=327
                throw new NotImplementedException();
            }

            // TODO: this pointer must be typed
            cef_v8value_t.invoke_release((cef_base_t*)@object);
            cef_v8value_t.invoke_release((cef_base_t*)value);

            return 1;
        }

        protected override bool Get(string name, CefV8Value obj, out CefV8Value returnValue)
        {
            throw new NotSupportedException();
        }

        protected override bool Set(string name, CefV8Value obj, CefV8Value value)
        {
            throw new NotSupportedException();
        }
    }
}
