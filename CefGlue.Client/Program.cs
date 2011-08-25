namespace CefGlue.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

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
            settings.CachePath = "cache";
            settings.LogFile = "CEF.log";
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
