namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefV8Value
    {
        /// <summary>
        /// Create a new CefV8Value object of type undefined.
        /// </summary>
        /* FIXME: CefV8Value.CreateUndefined public */
        static cef_v8value_t* CreateUndefined()
        {
            // TODO: CefV8Value.CreateUndefined
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new CefV8Value object of type null.
        /// </summary>
        /* FIXME: CefV8Value.CreateNull public */
        static cef_v8value_t* CreateNull()
        {
            // TODO: CefV8Value.CreateNull
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new CefV8Value object of type bool.
        /// </summary>
        /* FIXME: CefV8Value.CreateBool public */
        static cef_v8value_t* CreateBool(int value)
        {
            // TODO: CefV8Value.CreateBool
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new CefV8Value object of type int.
        /// </summary>
        /* FIXME: CefV8Value.CreateInt public */
        static cef_v8value_t* CreateInt(int value)
        {
            // TODO: CefV8Value.CreateInt
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new CefV8Value object of type double.
        /// </summary>
        /* FIXME: CefV8Value.CreateDouble public */
        static cef_v8value_t* CreateDouble(double value)
        {
            // TODO: CefV8Value.CreateDouble
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new CefV8Value object of type Date.
        /// </summary>
        /* FIXME: CefV8Value.CreateDate public */
        static cef_v8value_t* CreateDate(/*const*/ cef_time_t* date)
        {
            // TODO: CefV8Value.CreateDate
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new CefV8Value object of type string.
        /// </summary>
        /* FIXME: CefV8Value.CreateString public */
        static cef_v8value_t* CreateString(/*const*/ cef_string_t* value)
        {
            // TODO: CefV8Value.CreateString
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new CefV8Value object of type object.
        /// </summary>
        /* FIXME: CefV8Value.CreateObject public */
        static cef_v8value_t* CreateObject(cef_base_t* user_data)
        {
            // TODO: CefV8Value.CreateObject
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new CefV8Value object of type object with accessors.
        /// </summary>
        /* FIXME: CefV8Value.CreateObject public */
        static cef_v8value_t* CreateObject(cef_base_t* user_data, cef_v8accessor_t* accessor)
        {
            // TODO: CefV8Value.CreateObject
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new CefV8Value object of type array.
        /// </summary>
        /* FIXME: CefV8Value.CreateArray public */
        static cef_v8value_t* CreateArray()
        {
            // TODO: CefV8Value.CreateArray
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new CefV8Value object of type function.
        /// </summary>
        /* FIXME: CefV8Value.CreateFunction public */
        static cef_v8value_t* CreateFunction(/*const*/ cef_string_t* name, cef_v8handler_t* handler)
        {
            // TODO: CefV8Value.CreateFunction
            throw new NotImplementedException();
        }

        /// <summary>
        /// True if the value type is undefined.
        /// </summary>
        /* FIXME: CefV8Value.IsUndefined public */
        int IsUndefined()
        {
            // TODO: CefV8Value.IsUndefined
            throw new NotImplementedException();
        }

        /// <summary>
        /// True if the value type is null.
        /// </summary>
        /* FIXME: CefV8Value.IsNull public */
        int IsNull()
        {
            // TODO: CefV8Value.IsNull
            throw new NotImplementedException();
        }

        /// <summary>
        /// True if the value type is bool.
        /// </summary>
        /* FIXME: CefV8Value.IsBool public */
        int IsBool()
        {
            // TODO: CefV8Value.IsBool
            throw new NotImplementedException();
        }

        /// <summary>
        /// True if the value type is int.
        /// </summary>
        /* FIXME: CefV8Value.IsInt public */
        int IsInt()
        {
            // TODO: CefV8Value.IsInt
            throw new NotImplementedException();
        }

        /// <summary>
        /// True if the value type is double.
        /// </summary>
        /* FIXME: CefV8Value.IsDouble public */
        int IsDouble()
        {
            // TODO: CefV8Value.IsDouble
            throw new NotImplementedException();
        }

        /// <summary>
        /// True if the value type is Date.
        /// </summary>
        /* FIXME: CefV8Value.IsDate public */
        int IsDate()
        {
            // TODO: CefV8Value.IsDate
            throw new NotImplementedException();
        }

        /// <summary>
        /// True if the value type is string.
        /// </summary>
        /* FIXME: CefV8Value.IsString public */
        int IsString()
        {
            // TODO: CefV8Value.IsString
            throw new NotImplementedException();
        }

        /// <summary>
        /// True if the value type is object.
        /// </summary>
        /* FIXME: CefV8Value.IsObject public */
        int IsObject()
        {
            // TODO: CefV8Value.IsObject
            throw new NotImplementedException();
        }

        /// <summary>
        /// True if the value type is array.
        /// </summary>
        /* FIXME: CefV8Value.IsArray public */
        int IsArray()
        {
            // TODO: CefV8Value.IsArray
            throw new NotImplementedException();
        }

        /// <summary>
        /// True if the value type is function.
        /// </summary>
        /* FIXME: CefV8Value.IsFunction public */
        int IsFunction()
        {
            // TODO: CefV8Value.IsFunction
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if this object is pointing to the same handle as |that|
        /// object.
        /// </summary>
        /* FIXME: CefV8Value.IsSame public */
        int IsSame(cef_v8value_t* that)
        {
            // TODO: CefV8Value.IsSame
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return a bool value.  The underlying data will be converted to if
        /// necessary.
        /// </summary>
        /* FIXME: CefV8Value.GetBoolValue public */
        int GetBoolValue()
        {
            // TODO: CefV8Value.GetBoolValue
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return an int value.  The underlying data will be converted to if
        /// necessary.
        /// </summary>
        /* FIXME: CefV8Value.GetIntValue public */
        int GetIntValue()
        {
            // TODO: CefV8Value.GetIntValue
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return a double value.  The underlying data will be converted to if
        /// necessary.
        /// </summary>
        /* FIXME: CefV8Value.GetDoubleValue public */
        double GetDoubleValue()
        {
            // TODO: CefV8Value.GetDoubleValue
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return a Date value.  The underlying data will be converted to if
        /// necessary.
        /// </summary>
        /* FIXME: CefV8Value.GetDateValue public */
        cef_time_t GetDateValue()
        {
            // TODO: CefV8Value.GetDateValue
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return a string value.  The underlying data will be converted to if
        /// necessary.
        /// </summary>
        /* FIXME: CefV8Value.GetStringValue public */
        cef_string_userfree_t GetStringValue()
        {
            // TODO: CefV8Value.GetStringValue
            throw new NotImplementedException();
        }


        // OBJECT METHODS - These methods are only available on objects. Arrays
        // and functions are also objects. String- and integer-based keys can be
        // used interchangably with the framework converting between them as
        // necessary. Keys beginning with "Cef::" and "v8::" are reserved by the
        // system.

        /// <summary>
        /// Returns true if the object has a value with the specified identifier.
        /// </summary>
        /* FIXME: CefV8Value.HasValue public */
        int HasValue(/*const*/ cef_string_t* key)
        {
            // TODO: CefV8Value.HasValue
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if the object has a value with the specified identifier.
        /// </summary>
        /* FIXME: CefV8Value.HasValue public */
        int HasValue(int index)
        {
            // TODO: CefV8Value.HasValue
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete the value with the specified identifier.
        /// </summary>
        /* FIXME: CefV8Value.DeleteValue public */
        int DeleteValue(/*const*/ cef_string_t* key)
        {
            // TODO: CefV8Value.DeleteValue
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete the value with the specified identifier.
        /// </summary>
        /* FIXME: CefV8Value.DeleteValue public */
        int DeleteValue(int index)
        {
            // TODO: CefV8Value.DeleteValue
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the value with the specified identifier.
        /// </summary>
        /* FIXME: CefV8Value.GetValue public */
        cef_v8value_t* GetValue(/*const*/ cef_string_t* key)
        {
            // TODO: CefV8Value.GetValue
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the value with the specified identifier.
        /// </summary>
        /* FIXME: CefV8Value.GetValue public */
        cef_v8value_t* GetValue(int index)
        {
            // TODO: CefV8Value.GetValue
            throw new NotImplementedException();
        }

        /// <summary>
        /// Associate a value with the specified identifier.
        /// </summary>
        /* FIXME: CefV8Value.SetValue public */
        int SetValue(/*const*/ cef_string_t* key, cef_v8value_t* value)
        {
            // TODO: CefV8Value.SetValue
            throw new NotImplementedException();
        }

        /// <summary>
        /// Associate a value with the specified identifier.
        /// </summary>
        /* FIXME: CefV8Value.SetValue public */
        int SetValue(int index, cef_v8value_t* value)
        {
            // TODO: CefV8Value.SetValue
            throw new NotImplementedException();
        }

        /// <summary>
        /// Register an identifier whose access will be forwarded to the
        /// CefV8Accessor instance passed to CefV8Value::CreateObject().
        /// </summary>
        /* FIXME: CefV8Value.SetValue public */
        int SetValue(/*const*/ cef_string_t* key, cef_v8_accesscontrol_t settings, cef_v8_propertyattribute_t attribute)
        {
            // TODO: CefV8Value.SetValue
            throw new NotImplementedException();
        }

        /// <summary>
        /// Read the keys for the object's values into the specified vector.
        /// Integer- based keys will also be returned as strings.
        /// </summary>
        /* FIXME: CefV8Value.GetKeys public */
        int GetKeys(cef_string_list_t keys)
        {
            // TODO: CefV8Value.GetKeys
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the user data, if any, specified when the object was created.
        /// </summary>
        /* FIXME: CefV8Value.GetUserData public */
        cef_base_t* GetUserData()
        {
            // TODO: CefV8Value.GetUserData
            throw new NotImplementedException();
        }


        // ARRAY METHODS - These methods are only available on arrays.

        /// <summary>
        /// Returns the number of elements in the array.
        /// </summary>
        /* FIXME: CefV8Value.GetArrayLength public */
        int GetArrayLength()
        {
            // TODO: CefV8Value.GetArrayLength
            throw new NotImplementedException();
        }


        // FUNCTION METHODS - These methods are only available on functions.

        /// <summary>
        /// Returns the function name.
        /// </summary>
        /* FIXME: CefV8Value.GetFunctionName public */
        cef_string_userfree_t GetFunctionName()
        {
            // TODO: CefV8Value.GetFunctionName
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the function handler or NULL if not a CEF-created function.
        /// </summary>
        /* FIXME: CefV8Value.GetFunctionHandler public */
        cef_v8handler_t* GetFunctionHandler()
        {
            // TODO: CefV8Value.GetFunctionHandler
            throw new NotImplementedException();
        }

        /// <summary>
        /// Execute the function using the current V8 context.
        /// </summary>
        /* FIXME: CefV8Value.ExecuteFunction public */
        int ExecuteFunction(cef_v8value_t* @object, int argumentCount, cef_v8value_t* /*const*/ * arguments, cef_v8value_t** retval, cef_string_t* exception)
        {
            // TODO: CefV8Value.ExecuteFunction
            throw new NotImplementedException();
        }

        /// <summary>
        /// Execute the function using the specified V8 context.
        /// </summary>
        /* FIXME: CefV8Value.ExecuteFunctionWithContext public */
        int ExecuteFunctionWithContext(cef_v8context_t* context, cef_v8value_t* @object, int argumentCount, cef_v8value_t* /*const*/ * arguments, cef_v8value_t** retval, cef_string_t* exception)
        {
            // TODO: CefV8Value.ExecuteFunctionWithContext
            throw new NotImplementedException();
        }


    }
}
