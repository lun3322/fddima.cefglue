namespace CefGlue
{
    using System;
    using Core;

    unsafe partial class CefV8Value
    {
        /// <summary>
        /// Create a new CefV8Value object of type undefined.
        /// </summary>
        public static CefV8Value CreateUndefined()
        {
            return CefV8Value.From(
                libcef.v8value_create_undefined()
                );
        }

        /// <summary>
        /// Create a new CefV8Value object of type null.
        /// </summary>
        public static CefV8Value CreateNull()
        {
            return CefV8Value.From(
                libcef.v8value_create_null()
                );
        }

        /// <summary>
        /// Create a new CefV8Value object of type bool.
        /// </summary>
        public static CefV8Value CreateBool(bool value)
        {
            return CefV8Value.From(
                libcef.v8value_create_bool(value ? 1 : 0)
                );
        }

        /// <summary>
        /// Create a new CefV8Value object of type int.
        /// </summary>
        public static CefV8Value CreateInt(int value)
        {
            return CefV8Value.From(
                libcef.v8value_create_int(value)
                );
        }

        /// <summary>
        /// Create a new CefV8Value object of type double.
        /// </summary>
        public static CefV8Value CreateDouble(double value)
        {
            return CefV8Value.From(
                libcef.v8value_create_double(value)
                );
        }

        /// <summary>
        /// Create a new CefV8Value object of type Date.
        /// </summary>
        public static CefV8Value CreateDate(DateTime value)
        {
            cef_time_t n_date = new cef_time_t(value);
            return CefV8Value.From(
                libcef.v8value_create_date(&n_date)
                );
        }

        /// <summary>
        /// Create a new CefV8Value object of type string.
        /// </summary>
        public static CefV8Value CreateString(string value)
        {
            fixed (char* value_str = value)
            {
                var n_value = new cef_string_t(value_str, value != null ? value.Length : 0);
                return CefV8Value.From(
                    libcef.v8value_create_string(&n_value)
                    );
            }
        }

        /// <summary>
        /// Create a new CefV8Value object of type object.
        /// </summary>
        public static CefV8Value CreateObject()
        {
            return CreateObject((CefUserData)null);
        }

        /// <summary>
        /// Create a new CefV8Value object of type object.
        /// </summary>
        public static CefV8Value CreateObject(CefUserData userData)
        {
            return CefV8Value.From(libcef.v8value_create_object(
                (cef_base_t*)(userData != null ? userData.GetNativePointerAndAddRef() : null)
                ));
        }

        /// <summary>
        /// Create a new CefV8Value object of type object with accessors.
        /// </summary>
        public static CefV8Value CreateObject(CefV8Accessor accessor)
        {
            return CreateObject(null, accessor);
        }

        /// <summary>
        /// Create a new CefV8Value object of type object with accessors.
        /// </summary>
        public static CefV8Value CreateObject(CefUserData userData, CefV8Accessor accessor)
        {
            return CefV8Value.From(libcef.v8value_create_object_with_accessor(
                    (cef_base_t*)(userData != null ? userData.GetNativePointerAndAddRef() : null),
                    accessor.GetNativePointerAndAddRef()
                ));
        }

        /// <summary>
        /// Create a new CefV8Value object of type array.
        /// </summary>
        public static CefV8Value CreateArray()
        {
            return CefV8Value.From(
                libcef.v8value_create_array()
                );
        }

        /// <summary>
        /// Create a new CefV8Value object of type function.
        /// </summary>
        public static CefV8Value CreateFunction(string name, CefV8Handler handler)
        {
            fixed (char* name_str = name)
            {
                var n_name = new cef_string_t(name_str, name != null ? name.Length : 0);

                return CefV8Value.From(
                    libcef.v8value_create_function(&n_name, handler.GetNativePointerAndAddRef())
                    );
            }
        }

        /// <summary>
        /// True if the value type is undefined.
        /// </summary>
        public bool IsUndefined
        {
            get
            {
                return this.is_undefined(this.ptr) != 0;
            }
        }

        /// <summary>
        /// True if the value type is null.
        /// </summary>
        public bool IsNull
        {
            get
            {
                return this.is_null(this.ptr) != 0;
            }
        }

        /// <summary>
        /// True if the value type is bool.
        /// </summary>
        public bool IsBool
        {
            get
            {
                return this.is_bool(this.ptr) != 0;
            }
        }

        /// <summary>
        /// True if the value type is int.
        /// </summary>
        public bool IsInt
        {
            get
            {
                return this.is_int(this.ptr) != 0;
            }
        }

        /// <summary>
        /// True if the value type is double.
        /// </summary>
        public bool IsDouble
        {
            get
            {
                return this.is_double(this.ptr) != 0;
            }
        }

        /// <summary>
        /// True if the value type is Date.
        /// </summary>
        public bool IsDate
        {
            get
            {
                return this.is_date(this.ptr) != 0;
            }
        }

        /// <summary>
        /// True if the value type is string.
        /// </summary>
        public bool IsString
        {
            get
            {
                return this.is_string(this.ptr) != 0;
            }
        }

        /// <summary>
        /// True if the value type is object.
        /// </summary>
        public bool IsObject
        {
            get
            {
                return this.is_object(this.ptr) != 0;
            }
        }

        /// <summary>
        /// True if the value type is array.
        /// </summary>
        public bool IsArray
        {
            get
            {
                return this.is_array(this.ptr) != 0;
            }
        }

        /// <summary>
        /// True if the value type is function.
        /// </summary>
        public bool IsFunction
        {
            get
            {
                return this.is_function(this.ptr) != 0;
            }
        }

        /// <summary>
        /// Returns true if this object is pointing to the same handle as |that| object.
        /// </summary>
        public bool IsSame(CefV8Value that)
        {
            return this.is_same(this.ptr, that.GetNativePointerAndAddRef()) != 0;
        }

        /// <summary>
        /// Return a bool value.
        /// The underlying data will be converted to if necessary.
        /// </summary>
        public bool GetBoolValue()
        {
            return this.get_bool_value(this.ptr) != 0;
        }

        /// <summary>
        /// Return an int value.
        /// The underlying data will be converted to if necessary.
        /// </summary>
        public int GetIntValue()
        {
            return this.get_int_value(this.ptr);
        }

        /// <summary>
        /// Return a double value.
        /// The underlying data will be converted to if necessary.
        /// </summary>
        public double GetDoubleValue()
        {
            return this.get_double_value(this.ptr);
        }

        /// <summary>
        /// Return a Date value.
        /// The underlying data will be converted to if necessary.
        /// </summary>
        public DateTime GetDateValue()
        {
            var n_result = this.get_date_value(this.ptr);
            return n_result.ToDateTime();
        }

        /// <summary>
        /// Return a string value.
        /// The underlying data will be converted to if necessary.
        /// </summary>
        public string GetStringValue()
        {
            var n_result = this.get_string_value(this.ptr);
            return n_result.GetStringAndFree();
        }


        // OBJECT METHODS - These methods are only available on objects. Arrays
        // and functions are also objects. String- and integer-based keys can be
        // used interchangably with the framework converting between them as
        // necessary. Keys beginning with "Cef::" and "v8::" are reserved by the
        // system.

        /// <summary>
        /// Returns true if the object has a value with the specified identifier.
        /// </summary>
        public bool HasValue(string key)
        {
            fixed (char* key_str = key)
            {
                var n_key = new cef_string_t(key_str, key != null ? key.Length : 0);

                return this.has_value_bykey(this.ptr, &n_key) != 0;
            }
        }

        /// <summary>
        /// Returns true if the object has a value with the specified identifier.
        /// </summary>
        public bool HasValue(int index)
        {
            return this.has_value_byindex(this.ptr, index) != 0;
        }

        /// <summary>
        /// Delete the value with the specified identifier.
        /// </summary>
        public bool DeleteValue(string key)
        {
            fixed (char* key_str = key)
            {
                var n_key = new cef_string_t(key_str, key != null ? key.Length : 0);

                return this.delete_value_bykey(this.ptr, &n_key) != 0;
            }
        }

        /// <summary>
        /// Delete the value with the specified identifier.
        /// </summary>
        public bool DeleteValue(int index)
        {
            return this.delete_value_byindex(this.ptr, index) != 0;
        }

        /// <summary>
        /// Returns the value with the specified identifier.
        /// </summary>
        public CefV8Value GetValue(string key)
        {
            fixed (char* key_str = key)
            {
                var n_key = new cef_string_t(key_str, key != null ? key.Length : 0);

                return CefV8Value.From(
                    this.get_value_bykey(this.ptr, &n_key)
                    );
            }
        }

        /// <summary>
        /// Returns the value with the specified identifier.
        /// </summary>
        public CefV8Value GetValue(int index)
        {
            return CefV8Value.From(
                   this.get_value_byindex(this.ptr, index)
                   );
        }

        /// <summary>
        /// Associate a value with the specified identifier.
        /// </summary>
        public bool SetValue(string key, CefV8Value value)
        {
            fixed (char* key_str = key)
            {
                var n_key = new cef_string_t(key_str, key != null ? key.Length : 0);

                return this.set_value_bykey(this.ptr, &n_key, value.GetNativePointerAndAddRef()) != 0;
            }
        }

        /// <summary>
        /// Associate a value with the specified identifier.
        /// </summary>
        public bool SetValue(int index, CefV8Value value)
        {
            return this.set_value_byindex(this.ptr, index, value.GetNativePointerAndAddRef()) != 0;
        }

        /// <summary>
        /// Register an identifier whose access will be forwarded to the CefV8Accessor instance passed to CefV8Value::CreateObject().
        /// </summary>
        public bool SetValue(string key, CefV8AccessControl settings, CefV8PropertyAttribute attribute)
        {
            fixed (char* key_str = key)
            {
                var n_key = new cef_string_t(key_str, key != null ? key.Length : 0);

                return this.set_value_byaccessor(this.ptr, &n_key, (cef_v8_accesscontrol_t)settings, (cef_v8_propertyattribute_t)attribute) != 0;
            }
        }

        /// <summary>
        /// Read the keys for the object's values into the specified vector.
        /// Integer- based keys will also be returned as strings.
        /// </summary>
        public bool TryGetKeys(out CefStringList keys)
        {
            keys = new CefStringList();
            return this.get_keys(this.ptr, keys.GetNativeHandle()) != 0;
        }

        /// <summary>
        /// Read the keys for the object's values into the specified vector.
        /// Integer- based keys will also be returned as strings.
        /// </summary>
        public CefStringList GetKeys()
        {
            CefStringList keys;
            if (TryGetKeys(out keys))
            {
                return keys;
            }
            else throw new CefGlueException("CefV8Value.GetKeys failed.");
        }

        /// <summary>
        /// Returns the user data, if any, specified when the object was created.
        /// </summary>
        public CefUserData GetUserData()
        {
            var n_base = this.get_user_data(this.ptr);
            if (n_base == null) return null;
            return CefUserData.FromOrDefault((cefglue_userdata_t*)n_base);
        }


        // ARRAY METHODS - These methods are only available on arrays.

        /// <summary>
        /// Returns the number of elements in the array.
        /// </summary>
        public int GetArrayLength()
        {
            return this.get_array_length(this.ptr);
        }


        // FUNCTION METHODS - These methods are only available on functions.

        /// <summary>
        /// Returns the function name.
        /// </summary>
        public string GetFunctionName()
        {
            var n_result = this.get_function_name(this.ptr);
            return n_result.GetStringAndFree();
        }

        /// <summary>
        /// Returns the function handler or NULL if not a CEF-created function.
        /// </summary>
        public CefV8Handler GetFunctionHandler()
        {
            return CefV8Handler.FromOrDefault(
                this.get_function_handler(this.ptr)
            );
        }

        /// <summary>
        /// Execute the function using the current V8 context.
        /// </summary>
        public bool ExecuteFunction(CefV8Value obj, CefV8Value[] arguments, out CefV8Value returnValue, out string exception)
        {
            var n_arguments = CreateArgumentsArray(arguments);
            cef_v8value_t* n_retval = null;
            cef_string_t n_exception;
            bool result;

            fixed (cef_v8value_t** n_arguments_ptr = &n_arguments[0])
            {
                result = this.execute_function(
                    this.ptr,
                    obj.GetNativePointerAndAddRef(),
                    n_arguments != null ? n_arguments.Length : 0,
                    n_arguments_ptr,
                    &n_retval,
                    &n_exception
                    ) != 0;
            }

            returnValue = CefV8Value.FromOrDefault(n_retval);

            exception = cef_string_t.ToString(&n_exception);
            cef_string_t.Clear(&n_exception);

            return result;
        }

        /// <summary>
        /// Execute the function using the specified V8 context.
        /// </summary>
        public bool ExecuteFunctionWithContext(CefV8Context context, CefV8Value obj, CefV8Value[] arguments, out CefV8Value returnValue, out string exception)
        {
            var n_arguments = CreateArgumentsArray(arguments);
            cef_v8value_t* n_retval = null;
            cef_string_t n_exception;
            bool result;

            fixed (cef_v8value_t** n_arguments_ptr = &n_arguments[0])
            {
                result = this.execute_function_with_context(
                    this.ptr,
                    context.GetNativePointerAndAddRef(),
                    obj.GetNativePointerAndAddRef(),
                    n_arguments != null ? n_arguments.Length : 0,
                    n_arguments_ptr,
                    &n_retval,
                    &n_exception
                    ) != 0;
            }

            returnValue = CefV8Value.FromOrDefault(n_retval);

            exception = cef_string_t.ToString(&n_exception);
            cef_string_t.Clear(&n_exception);

            return result;
        }

        private static cef_v8value_t*[] CreateArgumentsArray(CefV8Value[] arguments)
        {
            if (arguments == null) return null;

            var length = arguments.Length;
            if (length == 0) return null;

            var result = new cef_v8value_t*[arguments.Length];

            for (var i = 0; i < length; i++)
            {
                result[i] = arguments[i].GetNativePointerAndAddRef();
            }

            return result;
        }
    }
}
