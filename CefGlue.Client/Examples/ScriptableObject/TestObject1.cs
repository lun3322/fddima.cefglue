namespace CefGlue.Client.Examples.ScriptableObject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CefGlue.ScriptableObject;

    internal sealed class TestObject1
    {
        public bool Enabled { get; set; }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        [Scriptable]
        private void ScriptOnlyMethod()
        {
        }

        [Scriptable(false)]
        public void HostOnlyMethod()
        {
        }
    }
}
