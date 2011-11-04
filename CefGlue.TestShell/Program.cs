﻿namespace CefGlue.TestShell
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
    using CefGlue.Windows.Forms;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Cef.Initialize(new CefSettings
            {
                MultiThreadedMessageLoop = true,
                LogSeverity = CefLogSeverity.Verbose,
            });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new CefWebView("http://www.google.com"));
            Application.Run(new MainForm());

            Cef.Shutdown();
        }
    }
}
