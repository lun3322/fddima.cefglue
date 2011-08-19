namespace CefGlue.Windows.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Diagnostics;

    partial class CefWebBrowser
    {
        private sealed class LifeSpanHandler : CefLifeSpanHandler
        {
            private CefWebBrowser control;

            public LifeSpanHandler(CefWebBrowser control)
            {
                this.control = control;
            }

            protected override PopupCreation OnBeforePopup(CefBrowser parentBrowser, CefPopupFeatures popupFeatures, CefWindowInfo windowInfo, string url, ref CefClient client, CefBrowserSettings settings)
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(LogTarget.Default, "LifeSpanHandler.OnBeforePopup");
#endif
                /*
    #if DEBUG
                string message = string.Format(
                    "LifeSpanHandler:OnBeforePopup\n"
                    + "               URL: {0}\n"
                    + "                 X: {1}\n"
                    + "                 Y: {2}\n"
                    + "             Width: {3}\n"
                    + "            Height: {4}\n"
                    + "    MenuBarVisible: {5}\n"
                    + "  StatusBarVisible: {6}\n"
                    + "    ToolBarVisible: {7}\n"
                    + "LocationBarVisible: {8}\n"
                    + " ScrollbarsVisible: {9}\n"
                    + "         Resizable: {10}\n"
                    + "        Fullscreen: {11}\n"
                    + "            Dialog: {12}\n",
                    url,
                    popupFeatures.X.HasValue ? popupFeatures.X.ToString() : "not set",
                    popupFeatures.Y.HasValue ? popupFeatures.Y.ToString() : "not set",
                    popupFeatures.Width.HasValue ? popupFeatures.Width.ToString() : "not set",
                    popupFeatures.Height.HasValue ? popupFeatures.Height.ToString() : "not set",
                    popupFeatures.MenuBarVisible,
                    popupFeatures.StatusBarVisible,
                    popupFeatures.ToolBarVisible,
                    popupFeatures.LocationBarVisible,
                    popupFeatures.ScrollbarsVisible,
                    popupFeatures.Resizable,
                    popupFeatures.Fullscreen,
                    popupFeatures.Dialog
                    );
                Debug.Write(message);
    #endif
                */

                return PopupCreation.Proceed;
            }

            protected override void OnAfterCreated(CefBrowser browser)
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(LogTarget.Default, "LifeSpanHandler.OnAfterCreated");
#endif
                if (!browser.IsPopup)
                {
                    this.control.browser = browser;
                    this.control.browserWindowHandle = browser.WindowHandle;

                    this.control.SetStyle(ControlStyles.Opaque, true);
                }
            }

            protected override ModalLoop RunModal(CefBrowser browser)
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(LogTarget.Default, "LifeSpanHandler.RunModal");
#endif
                return ModalLoop.Default;
            }

            protected override WindowClose DoClose(CefBrowser browser)
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(LogTarget.Default, "LifeSpanHandler.DoClose");
#endif
                return WindowClose.Proceed;
            }

            protected override void OnBeforeClose(CefBrowser browser)
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(LogTarget.Default, "LifeSpanHandler.OnBeforeClose");
#endif
                if (!browser.IsPopup)
                {
                    browser.Dispose();

                    if (this.control.browser != null)
                    {
                        this.control.browser.Dispose();
                        this.control.browser = null;
                        this.control.browserWindowHandle = IntPtr.Zero;
                    }

                    if (!this.control.IsDisposed)
                    {
                        if (this.control.InvokeRequired)
                        {
                            this.control.BeginInvoke(new Action(this.control.DestroyHandle));
                        }
                        else
                        {
                            this.control.DestroyHandle();
                        }
                    }
                }
                else
                {
                    browser.Dispose();
                }
            }
        }
    }
}
