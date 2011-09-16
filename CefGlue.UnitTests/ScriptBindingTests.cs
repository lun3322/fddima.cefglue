namespace CefGlue.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ScriptableObject;

    class ScriptBindingTests
    {
        public void Run()
        {
            var binder = ScriptableObjectBinder.Get(typeof(TestScriptObject));

            Console.WriteLine(binder.CreateJavaScriptExtension("cefglue.unitTests.scriptableObjectV8Extension"));
        }




    }
}
