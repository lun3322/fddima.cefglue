namespace CefGlue.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using ScriptableObject;

    [ScriptableObject]
    class TestScriptObject
    {
        private bool _enabled;

        // instance methods
        public void EchoVoid() { }


        // method overloading
        public int Sub(int arg1, int arg2)
        {
            return arg1 - arg2;
        }
        /*
        public int Sub(int arg1, int arg2, int arg3)
        {
            return arg1 - arg2 - arg3;
        }*/


        // properties

        public bool Enabled
        {
            get { return this._enabled; }
            [Scriptable(true)]
            private set { this._enabled = value; }
        }

        [Scriptable]
        private bool GetEnabled2()
        {
            return this.Enabled;
        }

        [Scriptable]
        private bool getEnabled()
        {
            return false;
        }






    }
}
