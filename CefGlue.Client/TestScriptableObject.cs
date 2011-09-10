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



        public bool Enabled { get; set; }

        public int Subtract(int a, int b)
        {
            return a - b;
        }
    }
}
