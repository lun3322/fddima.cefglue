namespace CefGlue.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CefGlue.ScriptableObject;

    public sealed class TestScriptableObject
    {
        public void EchoVoid() { }

        public bool EchoBoolean(bool value) { return value; }
        public int EchoInt32(int value) { return value; }
        public double EchoDouble(double value) { return value; }
        public string EchoString(string value) { return value; }
        public DateTime EchoDateTime(DateTime value) { return value; }

        public byte EchoByte(byte value) { return value; }
        public sbyte EchoSByte(sbyte value) { return value; }
        public short EchoInt16(short value) { return value; }
        public ushort EchoUInt16(ushort value) { return value; }
        public char EchoChar(char value) { return value; }
        public float EchoSingle(float value) { return value; }

        public bool? EchoNullableBoolean(bool? value) { return value; }
        public int? EchoNullableInt32(int? value) { return value; }
        public double? EchoNullableDouble(double? value) { return value; }
        public DateTime? EchoNullableDateTime(DateTime? value) { return value; }

        public byte? EchoNullableByte(byte? value) { return value; }
        public sbyte? EchoNullableSByte(sbyte? value) { return value; }
        public short? EchoNullableInt16(short? value) { return value; }
        public ushort? EchoNullableUInt16(ushort? value) { return value; }
        public char? EchoNullableChar(char? value) { return value; }
        public float? EchoNullableSingle(float? value) { return value; }

        public void ArgumentCount0() { }
        public void ArgumentCount1(int arg1) { }
        public void ArgumentCount2(int arg1, int arg2) { }



        public bool Enabled { get; set; }

        public bool ThrowingProperty
        {
            get { throw new InvalidOperationException("i'm throwing getter!"); }
            set { throw new InvalidOperationException("i'm throwing setter!"); }
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        // obj.overload() -> by argc
        public string Overload()
        {
            return "#1";
        }

        // obj.overload(10) -> by argc
        [Scriptable(false)]
        public string Overload(int arg1)
        {
            return "#2";
        }

        // obj.overload(10) -> by argc
        [Scriptable(false)]
        public string Overload(short arg1)
        {
            return "#4";
        }

        // obj.overload(10, undefined) -> by argc + optional values
        [Scriptable(false)]
        public string Overload(int arg1, int arg2 = 20)
        {
            return "#3";
        }


        // obj.overloadOpt(10, undefined) -> by argc + optional values
        // obj.overloadOpt(10) -> by argc + optional const (it is possible via create custom method marshaller)
        [Scriptable(false)]
        public string OverloadOpt(int arg1, int arg2 = 20)
        {
            return "#3";
        }

    }
}
