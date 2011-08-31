namespace CefGlue.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Threading;
    using System.IO;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var settings = new CefSettings();
            settings.MultiThreadedMessageLoop = true;
            settings.CachePath = Path.GetDirectoryName(Application.ExecutablePath) + "/cache/";
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


            Cef.RegisterExtension("clientExtension",
            @"
var cefglue = cefglue || {};
if (!cefglue.client) {
    cefglue.client = {
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

            Cef.RegisterCustomScheme("client", false, false, false);
            Cef.RegisterSchemeHandlerFactory("client", null, new ClientSchemeHandlerFactory());

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

            bool cefMessageLoop = false;

            if (!Cef.CurrentSettings.MultiThreadedMessageLoop && !cefMessageLoop)
            {
                Application.Idle += (sender, e) => { Cef.DoMessageLoopWork(); };
            }
            using (var mainForm = new MainForm())
            {
                if (cefMessageLoop)
                {
                    mainForm.Show();
                    Cef.RunMessageLoop();
                }
                else
                {
                    Application.Run(mainForm);
                }
            }

            Cef.Shutdown();
        }
    }
}
