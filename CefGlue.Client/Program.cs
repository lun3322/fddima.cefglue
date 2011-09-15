namespace CefGlue.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Threading;
    using System.IO;
    using System.Text;
    using CefGlue.ScriptableObject;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var options = Options.Parse(args);
            if (options.Help)
            {
                MessageBox.Show(options.GetHelpText(), "CefGlue Client");
                return;
            }


            var settings = new CefSettings();
            settings.MultiThreadedMessageLoop = options.MultiThreadedMessageLoop;
            settings.CachePath = Path.GetDirectoryName(Application.ExecutablePath) + "/cache";
            settings.LogFile = Path.GetDirectoryName(Application.ExecutablePath) + "/CEF.log";
            settings.LogSeverity = CefLogSeverity.Verbose;
            try
            {
                Cef.Initialize(settings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var version = Application.ProductVersion; // TODO: make Cef.Version property

            Cef.RegisterExtension("clientExtension",
            @"
var cefGlue = cefGlue || {};
Object.defineProperty(cefGlue, ""version"", { value: """ + version + @""", configurable: false });
if (!cefGlue.client) {
    cefGlue.client = {
        dump: function() {
            native function Dump();
            return Dump.apply(this, arguments);
        },
        returnVoid: function() {
            native function ReturnVoid();
            ReturnVoid();
        },
        returnVoidAndDisposeThis: function() {
            native function ReturnVoidAndDisposeThis();
            ReturnVoidAndDisposeThis();
        },
        returnUndefined: function() {
            native function ReturnUndefined();
            return ReturnUndefined();
        },
        returnNull: function() {
            native function ReturnNull();
            return ReturnNull();
        },
        returnBool: function() {
            native function ReturnBool();
            return ReturnBool();
        },
        returnInt: function() {
            native function ReturnInt();
            return ReturnInt();
        },
        returnDouble: function() {
            native function ReturnDouble();
            return ReturnDouble();
        },
        returnDate: function() {
            native function ReturnDate();
            return ReturnDate();
        },
        returnString: function() {
            native function ReturnString();
            return ReturnString();
        },
        returnArray: function() {
            native function ReturnArray();
            return ReturnArray();
        },
        returnObject: function() {
            native function ReturnObject();
            return ReturnObject();
        },
        subtractIntImplicit: function(a, b) {
            native function SubtractIntImplicit();
            return SubtractIntImplicit(a, b);
        },
        subtractIntExplicit: function(a, b) {
            native function SubtractIntExplicit();
            return SubtractIntExplicit(a, b);
        },

        get privateWorkingSet() {
            native function get_PrivateWorkingSet();
            return get_PrivateWorkingSet();
        }
    };
};
", new ClientV8Handler());

            Cef.RegisterScriptableObject(
                "cefGlue.tests.scriptableObject.v8Extension",
                new TestScriptableObject(),
                ScriptableObjectOptions.Extension
                );

            // TODO: must be cefglue.scriptableObject.tests.jsBinding
            Cef.RegisterScriptableObject(
                "testScriptableObject",
                new TestScriptableObject()
                );

            var testObject1 = new CefGlue.Client.Examples.ScriptableObject.TestObject1();
            Cef.RegisterScriptableObject(testObject1, ScriptableObjectOptions.Extension);
            Cef.RegisterScriptableObject("myTestObject1", testObject1, ScriptableObjectOptions.Extension);

            Cef.RegisterCustomScheme("res", true, true, false);
            Cef.RegisterSchemeHandlerFactory("res", null, new ClientSchemeHandlerFactory());

            // This is shows that handler works like zombie - when handler is used by native side only
            // it prevents to be collected by GC.
            CefTask.Post(CefThreadId.UI, () =>
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(Diagnostics.LogTarget.Default, "Cef.CurrentlyOn(CefThreadId.UI)=[{0}]", Cef.CurrentlyOn(CefThreadId.UI));
#endif
            });
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

            CefTask.Post(CefThreadId.IO, () =>
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(Diagnostics.LogTarget.Default, "Cef.CurrentlyOn(CefThreadId.IO)=[{0}]", Cef.CurrentlyOn(CefThreadId.IO));
#endif
            });

            CefTask.Post(CefThreadId.File, () =>
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(Diagnostics.LogTarget.Default, "Cef.CurrentlyOn(CefThreadId.File)=[{0}]", Cef.CurrentlyOn(CefThreadId.File));
#endif
            });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!Cef.CurrentSettings.MultiThreadedMessageLoop && !options.CefMessageLoop)
            {
                Application.Idle += (sender, e) => { Cef.DoMessageLoopWork(); };
            }

            using (var mainForm = new MainForm())
            {
                if (Cef.CurrentSettings.MultiThreadedMessageLoop || !options.CefMessageLoop)
                {
                    Application.Run(mainForm);
                }
                else
                {
                    mainForm.Show();
                    Cef.RunMessageLoop();
                }

                /*
                if (!cefMessageLoop)
                {
                    for (var i = 0; i < 1000; i++)
                    {
                        Cef.DoMessageLoopWork();
                    }
                }
                */
            }


            Cef.Shutdown();
        }
    }
}
