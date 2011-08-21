namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefV8Handler
    {
        /// <summary>
        /// Execute with the specified argument list and return value. Return
        /// true if the method was handled. To invoke V8 callback functions
        /// outside the scope of this method you need to keep references to the
        /// current V8 context (CefV8Context) along with any necessary callback
        /// objects.
        /// </summary>
        private int execute(cef_v8handler_t* self, /*const*/ cef_string_t* name, cef_v8value_t* @object, int argumentCount, cef_v8value_t* /*const*/ * arguments, cef_v8value_t** retval, cef_string_t* exception)
        {
            ThrowIfObjectDisposed();
            // TODO: CefV8Handler.execute
            throw new NotImplementedException();
        }


    }
}
