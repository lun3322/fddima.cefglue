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
        #region Boolean

        // Boolean <- V8.Boolean
        // Boolean -> V8.Boolean

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

        #region Int32

        // Int32 <- V8.In32
        // Int32 -> V8.In32

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

        #region Double

        // Double <- V8.Double | V8.Int32
        // Double -> V8.Double

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

        #region String

        // String <- V8.String | V8.Null | V8.Undefined
        // String -> V8.String | V8.Null

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

        #region DateTime

        // DateTime <- V8.Date
        // DateTime -> V8.Date

        public static DateTime ToDateTime(CefV8Value value)
        {
            return ToDateTime(value.NativePointer);
        }

        internal static DateTime ToDateTime(cef_v8value_t* value)
        {
            if (cef_v8value_t.invoke_is_date(value) != 0)
            {
                var nResult = cef_v8value_t.invoke_get_date_value(value);
                return nResult.ToDateTime();
            }
            else throw new InvalidCastException();
        }

        public static CefV8Value ToV8Value(DateTime value)
        {
            return CefV8Value.From(ToNativeV8Value(value));
        }

        internal static cef_v8value_t* ToNativeV8Value(DateTime value)
        {
            cef_time_t nDate = new cef_time_t(value);
            return libcef.v8value_create_date(&nDate);
        }

        #endregion

        #region Byte

        // Byte <- V8.Int32 + ByteRangeCheck
        // Byte -> V8.Int32

        public static byte ToByte(CefV8Value value)
        {
            return ToByte(value.NativePointer);
        }

        internal static byte ToByte(cef_v8value_t* value)
        {
            if (cef_v8value_t.invoke_is_int(value) != 0)
            {
                checked
                {
                    return (byte)cef_v8value_t.invoke_get_int_value(value);
                }
            }
            else throw new InvalidCastException();
        }

        public static CefV8Value ToV8Value(byte value)
        {
            return CefV8Value.From(ToNativeV8Value(value));
        }

        internal static cef_v8value_t* ToNativeV8Value(byte value)
        {
            return libcef.v8value_create_int(value);
        }

        #endregion

        #region SByte

        // SByte <- V8.Int32 + SByteRangeCheck
        // SByte -> V8.Int32

        public static sbyte ToSByte(CefV8Value value)
        {
            return ToSByte(value.NativePointer);
        }

        internal static sbyte ToSByte(cef_v8value_t* value)
        {
            if (cef_v8value_t.invoke_is_int(value) != 0)
            {
                checked
                {
                    return (sbyte)cef_v8value_t.invoke_get_int_value(value);
                }
            }
            else throw new InvalidCastException();
        }

        public static CefV8Value ToV8Value(sbyte value)
        {
            return CefV8Value.From(ToNativeV8Value(value));
        }

        internal static cef_v8value_t* ToNativeV8Value(sbyte value)
        {
            return libcef.v8value_create_int(value);
        }

        #endregion

        #region Int16

        // Int16 <- V8.Int32 + Int16RangeCheck
        // Int16 -> V8.Int32

        public static short ToInt16(CefV8Value value)
        {
            return ToInt16(value.NativePointer);
        }

        internal static short ToInt16(cef_v8value_t* value)
        {
            if (cef_v8value_t.invoke_is_int(value) != 0)
            {
                checked
                {
                    return (short)cef_v8value_t.invoke_get_int_value(value);
                }
            }
            else throw new InvalidCastException();
        }

        public static CefV8Value ToV8Value(short value)
        {
            return CefV8Value.From(ToNativeV8Value(value));
        }

        internal static cef_v8value_t* ToNativeV8Value(short value)
        {
            return libcef.v8value_create_int(value);
        }

        #endregion

        #region UInt16

        // UInt16 <- V8.Int32 + UInt16RangeCheck
        // UInt16 -> V8.Int32

        public static ushort ToUInt16(CefV8Value value)
        {
            return ToUInt16(value.NativePointer);
        }

        internal static ushort ToUInt16(cef_v8value_t* value)
        {
            if (cef_v8value_t.invoke_is_int(value) != 0)
            {
                checked
                {
                    return (ushort)cef_v8value_t.invoke_get_int_value(value);
                }
            }
            else throw new InvalidCastException();
        }

        public static CefV8Value ToV8Value(ushort value)
        {
            return CefV8Value.From(ToNativeV8Value(value));
        }

        internal static cef_v8value_t* ToNativeV8Value(ushort value)
        {
            return libcef.v8value_create_int(value);
        }

        #endregion

        #region Char

        // Char <- V8.Int32 + CharRangeCheck | V8.String + CharStringCheck
        // Char -> V8.Int32

        public static char ToChar(CefV8Value value)
        {
            return ToChar(value.NativePointer);
        }

        internal static char ToChar(cef_v8value_t* value)
        {
            if (cef_v8value_t.invoke_is_int(value) != 0)
            {
                checked
                {
                    return (char)cef_v8value_t.invoke_get_int_value(value);
                }
            }
            else if (cef_v8value_t.invoke_is_string(value) != 0)
            {
                var nResult = cef_v8value_t.invoke_get_string_value(value);
                if (nResult.Length == 1)
                {
                    var result = nResult.GetFirstCharOrDefault();
                    nResult.Free();
                    return result;
                }
                else
                {
                    nResult.Free();
                    throw new InvalidCastException();
                }
            }
            else throw new InvalidCastException();
        }

        public static CefV8Value ToV8Value(char value)
        {
            return CefV8Value.From(ToNativeV8Value(value));
        }

        internal static cef_v8value_t* ToNativeV8Value(char value)
        {
            return libcef.v8value_create_int(value);
        }

        #endregion

        #region Single

        // Single <- V8.Double | V8.Int32
        // Single -> V8.Double

        public static float ToSingle(CefV8Value value)
        {
            return ToSingle(value.NativePointer);
        }

        internal static float ToSingle(cef_v8value_t* value)
        {
            if (cef_v8value_t.invoke_is_double(value) != 0
                || cef_v8value_t.invoke_is_int(value) != 0)
            {
                return (float)cef_v8value_t.invoke_get_double_value(value);
            }
            else throw new InvalidCastException();
        }

        public static CefV8Value ToV8Value(float value)
        {
            return CefV8Value.From(ToNativeV8Value(value));
        }

        internal static cef_v8value_t* ToNativeV8Value(float value)
        {
            return libcef.v8value_create_double(value);
        }

        #endregion

        #region NullableBoolean

        // Boolean? <- V8.Boolean | V8.Null | V8.Undefined
        // Boolean? -> V8.Boolean | V8.Null

        public static bool? ToNullableBoolean(CefV8Value value)
        {
            return ToNullableBoolean(value.NativePointer);
        }

        internal static bool? ToNullableBoolean(cef_v8value_t* value)
        {
            if (cef_v8value_t.invoke_is_bool(value) != 0)
            {
                return cef_v8value_t.invoke_get_bool_value(value) != 0;
            }
            else if (cef_v8value_t.invoke_is_null(value) != 0
                || cef_v8value_t.invoke_is_undefined(value) != 0)
            {
                return null;
            }
            else throw new InvalidCastException();
        }

        public static CefV8Value ToV8Value(bool? value)
        {
            return CefV8Value.From(ToNativeV8Value(value));
        }

        internal static cef_v8value_t* ToNativeV8Value(bool? value)
        {
            if (value.HasValue)
            {
                return libcef.v8value_create_bool(value.Value ? 1 : 0);
            }
            else
            {
                return libcef.v8value_create_null();
            }
        }

        #endregion

        #region NullableInt32

        // Int32? <- V8.In32 | V8.Null | V8.Undefined
        // Int32? -> V8.In32 | V8.Null

        public static int? ToNullableInt32(CefV8Value value)
        {
            return ToNullableInt32(value.NativePointer);
        }

        internal static int? ToNullableInt32(cef_v8value_t* value)
        {
            if (cef_v8value_t.invoke_is_int(value) != 0)
            {
                return cef_v8value_t.invoke_get_int_value(value);
            }
            else if (cef_v8value_t.invoke_is_null(value) != 0
                || cef_v8value_t.invoke_is_undefined(value) != 0)
            {
                return null;
            }
            else throw new InvalidCastException();
        }

        public static CefV8Value ToV8Value(int? value)
        {
            return CefV8Value.From(ToNativeV8Value(value));
        }

        internal static cef_v8value_t* ToNativeV8Value(int? value)
        {
            if (value.HasValue)
            {
                return libcef.v8value_create_int(value.Value);
            }
            else
            {
                return libcef.v8value_create_null();
            }
        }

        #endregion

        #region NullableDouble

        // Double? <- V8.Double | V8.Int32 | V8.Null | V8.Undefined
        // Double? -> V8.Double | V8.Null

        public static double? ToNullableDouble(CefV8Value value)
        {
            return ToNullableDouble(value.NativePointer);
        }

        internal static double? ToNullableDouble(cef_v8value_t* value)
        {
            if (cef_v8value_t.invoke_is_double(value) != 0
                || cef_v8value_t.invoke_is_int(value) != 0)
            {
                return cef_v8value_t.invoke_get_double_value(value);
            }
            else if (cef_v8value_t.invoke_is_null(value) != 0
                || cef_v8value_t.invoke_is_undefined(value) != 0)
            {
                return null;
            }
            else throw new InvalidCastException();
        }

        public static CefV8Value ToV8Value(double? value)
        {
            return CefV8Value.From(ToNativeV8Value(value));
        }

        internal static cef_v8value_t* ToNativeV8Value(double? value)
        {
            if (value.HasValue)
            {
                return libcef.v8value_create_double(value.Value);
            }
            else
            {
                return libcef.v8value_create_null();
            }
        }

        #endregion

        #region NullableDateTime

        // DateTime? <- V8.Date | V8.Null | V8.Undefined
        // DateTime? -> V8.Date | V8.Null

        public static DateTime? ToNullableDateTime(CefV8Value value)
        {
            return ToNullableDateTime(value.NativePointer);
        }

        internal static DateTime? ToNullableDateTime(cef_v8value_t* value)
        {
            if (cef_v8value_t.invoke_is_date(value) != 0)
            {
                var nResult = cef_v8value_t.invoke_get_date_value(value);
                return nResult.ToDateTime();
            }
            else if (cef_v8value_t.invoke_is_null(value) != 0
                || cef_v8value_t.invoke_is_undefined(value) != 0)
            {
                return null;
            }
            else throw new InvalidCastException();
        }

        public static CefV8Value ToV8Value(DateTime? value)
        {
            return CefV8Value.From(ToNativeV8Value(value));
        }

        internal static cef_v8value_t* ToNativeV8Value(DateTime? value)
        {
            if (value.HasValue)
            {
                cef_time_t nDate = new cef_time_t(value.Value);
                return libcef.v8value_create_date(&nDate);
            }
            else
            {
                return libcef.v8value_create_null();
            }
        }

        #endregion

        #region NullableByte

        // Byte? <- V8.Int32 + ByteRangeCheck | V8.Null | V8.Undefined
        // Byte? -> V8.Int32 | V8.Null

        public static byte? ToNullableByte(CefV8Value value)
        {
            return ToNullableByte(value.NativePointer);
        }

        internal static byte? ToNullableByte(cef_v8value_t* value)
        {
            if (cef_v8value_t.invoke_is_int(value) != 0)
            {
                checked
                {
                    return (byte)cef_v8value_t.invoke_get_int_value(value);
                }
            }
            else if (cef_v8value_t.invoke_is_null(value) != 0
                || cef_v8value_t.invoke_is_undefined(value) != 0)
            {
                return null;
            }
            else throw new InvalidCastException();
        }

        public static CefV8Value ToV8Value(byte? value)
        {
            return CefV8Value.From(ToNativeV8Value(value));
        }

        internal static cef_v8value_t* ToNativeV8Value(byte? value)
        {
            if (value.HasValue)
            {
                return libcef.v8value_create_int(value.Value);
            }
            else
            {
                return libcef.v8value_create_null();
            }
        }

        #endregion

        #region NullableSByte

        // SByte? <- V8.Int32 + SByteRangeCheck | V8.Null | V8.Undefined
        // SByte? -> V8.Int32 | V8.Null

        public static sbyte? ToNullableSByte(CefV8Value value)
        {
            return ToNullableSByte(value.NativePointer);
        }

        internal static sbyte? ToNullableSByte(cef_v8value_t* value)
        {
            if (cef_v8value_t.invoke_is_int(value) != 0)
            {
                checked
                {
                    return (sbyte)cef_v8value_t.invoke_get_int_value(value);
                }
            }
            else if (cef_v8value_t.invoke_is_null(value) != 0
                || cef_v8value_t.invoke_is_undefined(value) != 0)
            {
                return null;
            }
            else throw new InvalidCastException();
        }

        public static CefV8Value ToV8Value(sbyte? value)
        {
            return CefV8Value.From(ToNativeV8Value(value));
        }

        internal static cef_v8value_t* ToNativeV8Value(sbyte? value)
        {
            if (value.HasValue)
            {
                return libcef.v8value_create_int(value.Value);
            }
            else
            {
                return libcef.v8value_create_null();
            }
        }

        #endregion

        #region NullableInt16

        // Int16? <- V8.Int32 + Int16RangeCheck | V8.Null | V8.Undefined
        // Int16? -> V8.Int32 | V8.Null | V8.Undefined

        public static short? ToNullableInt16(CefV8Value value)
        {
            return ToNullableInt16(value.NativePointer);
        }

        internal static short? ToNullableInt16(cef_v8value_t* value)
        {
            if (cef_v8value_t.invoke_is_int(value) != 0)
            {
                checked
                {
                    return (short)cef_v8value_t.invoke_get_int_value(value);
                }
            }
            else if (cef_v8value_t.invoke_is_null(value) != 0
                || cef_v8value_t.invoke_is_undefined(value) != 0)
            {
                return null;
            }
            else throw new InvalidCastException();
        }

        public static CefV8Value ToV8Value(short? value)
        {
            return CefV8Value.From(ToNativeV8Value(value));
        }

        internal static cef_v8value_t* ToNativeV8Value(short? value)
        {
            if (value.HasValue)
            {
                return libcef.v8value_create_int(value.Value);
            }
            else
            {
                return libcef.v8value_create_null();
            }
        }

        #endregion

        #region NullableUInt16

        // UInt16? <- V8.Int32 + UInt16RangeCheck | V8.Null | V8.Undefined
        // UInt16? -> V8.Int32 | V8.Null

        public static ushort? ToNullableUInt16(CefV8Value value)
        {
            return ToNullableUInt16(value.NativePointer);
        }

        internal static ushort? ToNullableUInt16(cef_v8value_t* value)
        {
            if (cef_v8value_t.invoke_is_int(value) != 0)
            {
                checked
                {
                    return (ushort)cef_v8value_t.invoke_get_int_value(value);
                }
            }
            else if (cef_v8value_t.invoke_is_null(value) != 0
                || cef_v8value_t.invoke_is_undefined(value) != 0)
            {
                return null;
            }
            else throw new InvalidCastException();
        }

        public static CefV8Value ToV8Value(ushort? value)
        {
            return CefV8Value.From(ToNativeV8Value(value));
        }

        internal static cef_v8value_t* ToNativeV8Value(ushort? value)
        {
            if (value.HasValue)
            {
                return libcef.v8value_create_int(value.Value);
            }
            else
            {
                return libcef.v8value_create_null();
            }
        }

        #endregion

        #region NullableChar

        // Char? <- V8.Int32 + CharRangeCheck | V8.String + CharStringCheck | V8.Null | V8.Undefined
        // Char? -> V8.Int32 | V8.Null

        public static char? ToNullableChar(CefV8Value value)
        {
            return ToNullableChar(value.NativePointer);
        }

        internal static char? ToNullableChar(cef_v8value_t* value)
        {
            if (cef_v8value_t.invoke_is_int(value) != 0)
            {
                checked
                {
                    return (char)cef_v8value_t.invoke_get_int_value(value);
                }
            }
            else if (cef_v8value_t.invoke_is_string(value) != 0)
            {
                var nResult = cef_v8value_t.invoke_get_string_value(value);
                if (nResult.Length == 1)
                {
                    var result = nResult.GetFirstCharOrDefault();
                    nResult.Free();
                    return result;
                }
                else
                {
                    nResult.Free();
                    throw new InvalidCastException();
                }
            }
            else if (cef_v8value_t.invoke_is_null(value) != 0
                || cef_v8value_t.invoke_is_undefined(value) != 0)
            {
                return null;
            }
            else throw new InvalidCastException();
        }

        public static CefV8Value ToV8Value(char? value)
        {
            return CefV8Value.From(ToNativeV8Value(value));
        }

        internal static cef_v8value_t* ToNativeV8Value(char? value)
        {
            if (value.HasValue)
            {
                return libcef.v8value_create_int(value.Value);
            }
            else
            {
                return libcef.v8value_create_null();
            }
        }

        #endregion

        #region NullableSingle

        // Single? <- V8.Double | V8.Int32 | V8.Null | V8.Undefined
        // Single? -> V8.Double | V8.Null

        public static float? ToNullableSingle(CefV8Value value)
        {
            return ToNullableSingle(value.NativePointer);
        }

        internal static float? ToNullableSingle(cef_v8value_t* value)
        {
            if (cef_v8value_t.invoke_is_double(value) != 0
                || cef_v8value_t.invoke_is_int(value) != 0)
            {
                return (float)cef_v8value_t.invoke_get_double_value(value);
            }
            else if (cef_v8value_t.invoke_is_null(value) != 0
                || cef_v8value_t.invoke_is_undefined(value) != 0)
            {
                return null;
            }
            else throw new InvalidCastException();
        }

        public static CefV8Value ToV8Value(float? value)
        {
            return CefV8Value.From(ToNativeV8Value(value));
        }

        internal static cef_v8value_t* ToNativeV8Value(float? value)
        {
            if (value.HasValue)
            {
                return libcef.v8value_create_double(value.Value);
            }
            else
            {
                return libcef.v8value_create_null();
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
