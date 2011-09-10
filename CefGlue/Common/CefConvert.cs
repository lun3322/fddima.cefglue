namespace CefGlue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
    using Core;

    public static unsafe class CefConvert
    {
        #region System.Boolean

        // System.Boolean <- V8.Boolean
        // System.Boolean -> V8.Boolean

        public static bool ToBoolean(CefV8Value value)
        {
            return ToBoolean(value.NativePointer);
        }

        internal static bool ToBoolean(cef_v8value_t* value)
        {
            if (cef_v8value_t.invoke_is_bool(value) != 0)
            {
                return cef_v8value_t.invoke_get_bool_value(value) != 0;
            }
            else throw new InvalidCastException();
        }

        public static CefV8Value ToV8Value(bool value)
        {
            return CefV8Value.From(ToNativeV8Value(value));
        }

        internal static cef_v8value_t* ToNativeV8Value(bool value)
        {
            return libcef.v8value_create_bool(value ? 1 : 0);
        }

        #endregion

        #region System.Int32

        // System.Int32 <- V8.In32
        // System.Int32 -> V8.In32

        public static int ToInt32(CefV8Value value)
        {
            return ToInt32(value.NativePointer);
        }

        internal static int ToInt32(cef_v8value_t* value)
        {
            if (cef_v8value_t.invoke_is_int(value) != 0)
            {
                return cef_v8value_t.invoke_get_int_value(value);
            }
            else throw new InvalidCastException();
        }

        public static CefV8Value ToV8Value(int value)
        {
            return CefV8Value.From(ToNativeV8Value(value));
        }

        internal static cef_v8value_t* ToNativeV8Value(int value)
        {
            return libcef.v8value_create_int(value);
        }

        #endregion

        #region System.Double

        // System.Double <- V8.Double | V8.Int32
        // System.Double -> V8.Double

        public static double ToDouble(CefV8Value value)
        {
            return ToDouble(value.NativePointer);
        }

        internal static double ToDouble(cef_v8value_t* value)
        {
            if (cef_v8value_t.invoke_is_double(value) != 0
                || cef_v8value_t.invoke_is_int(value) != 0)
            {
                return cef_v8value_t.invoke_get_double_value(value);
            }
            else throw new InvalidCastException();
        }

        public static CefV8Value ToV8Value(double value)
        {
            return CefV8Value.From(ToNativeV8Value(value));
        }

        internal static cef_v8value_t* ToNativeV8Value(double value)
        {
            return libcef.v8value_create_double(value);
        }

        #endregion

        #region System.String

        // System.String <- V8.String | V8.Null | V8.Undefined
        // System.String -> V8.String | V8.Null

        public static string ToString(CefV8Value value)
        {
            return ToString(value.NativePointer);
        }

        internal static string ToString(cef_v8value_t* value)
        {
            if (cef_v8value_t.invoke_is_string(value) != 0)
            {
                var nResult = cef_v8value_t.invoke_get_string_value(value);
                return nResult.GetStringAndFree();
            }
            else if (cef_v8value_t.invoke_is_null(value) != 0
                     || cef_v8value_t.invoke_is_undefined(value) != 0)
            {
                return null;
            }
            else throw new InvalidCastException();
        }

        public static CefV8Value ToV8Value(string value)
        {
            return CefV8Value.From(ToNativeV8Value(value));
        }

        internal static cef_v8value_t* ToNativeV8Value(string value)
        {
            if (value == null)
            {
                return libcef.v8value_create_null();
            }
            else
            {
                fixed (char* value_str = value)
                {
                    var nValue = new cef_string_t(value_str, value.Length);
                    return libcef.v8value_create_string(&nValue);
                }
            }
        }

        #endregion

        public static MethodInfo GetChangeTypeMethod(Type from, Type to)
        {
            var method = typeof(CefConvert)
                .GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(_ => _.ReturnType == to)
                .Where(_ =>
                {
                    var parameters = _.GetParameters();
                    return parameters.Length == 1 && parameters[0].ParameterType == from;
                })
                .SingleOrDefault();

            if (method == null) throw new NotSupportedException("Specified cast is not supported.");

            return method;
        }

        // TODO: public static object ChangeType(CefV8Value value, Type conversionType);
    }
}
