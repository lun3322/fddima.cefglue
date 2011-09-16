namespace CefGlue.Windows.Forms
{
    using System;
    using System.Collections.Generic;
#if DIAGNOSTICS
    using Diagnostics;
#endif

    partial class CefWebBrowser
    {
        private sealed class DisplayHandler : CefDisplayHandler
        {
            private CefWebBrowser control;
            private Dictionary<CefHandlerStatusType, string> statusMessages = new Dictionary<CefHandlerStatusType, string>();

            public DisplayHandler(CefWebBrowser control)
            {
                this.control = control;
            }

            protected override void OnNavStateChange(CefBrowser browser, bool canGoBack, bool canGoForward)
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(LogTarget.Default, "DisplayHandler.OnNavStateChange: CanGoBack=[{0}] CanGoForward=[{1}]", canGoBack, canGoForward);
#endif
                if (!browser.IsPopup)
                {
                    this.control.CanGoBack = canGoBack; // TODO: do it async
                    this.control.CanGoForward = canGoForward;
                }
            }

            protected override void OnAddressChange(CefBrowser browser, CefFrame frame, string url)
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(LogTarget.Default, "DisplayHandler.OnAddressChange: URL=[{0}]", url);
#endif
                if (!browser.IsPopup)
                {
                    this.control.Address = url; // TODO: do it async
                }
            }

            protected override void OnTitleChange(CefBrowser browser, string title)
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(LogTarget.Default, "DisplayHandler.OnTitleChange: Title=[{0}]", title);
#endif
                if (!browser.IsPopup)
                {
                    this.control.Title = title; // TODO: do it async
                }
                else
                {
                    // FIXME: set popup window's title here
                }
            }

            protected override bool OnTooltip(CefBrowser browser, ref string text)
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(LogTarget.Default, "DisplayHandler.OnTooltip: Text=[{0}]", text);
#endif

                return false;
            }

            protected override void OnStatusMessage(CefBrowser browser, string value, CefHandlerStatusType type)
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(LogTarget.Default, "DisplayHandler.OnStatusMessage: Type=[{0}] Value=[{1}]", type, value);
#endif
                // TODO: popups support...

                if (value.Length == 0)
                {
                    this.statusMessages.Remove(type);
                    GetMostImportantStatusMessage(this.statusMessages, out type, out value);
                }
                else
                {
                    this.statusMessages[type] = value;
                }

                this.control.PostStatusMessage(new StatusMessageEventArgs(type, value ?? ""));
            }

            protected override bool OnConsoleMessage(CefBrowser browser, string message, string source, int line)
            {
#if DIAGNOSTICS
                Cef.Logger.Trace(LogTarget.Default, "DisplayHandler.OnConsoleMessage: Message=[{0}] Source=[{1}] Line=[{2}]", message, source, line);
#endif
                if (this.control.IsDisposed) return false;

                this.control.PostConsoleMessage(new ConsoleMessageEventArgs(message, source, line));

                return true;
            }

            private static void GetMostImportantStatusMessage(Dictionary<CefHandlerStatusType, string> messages, out CefHandlerStatusType type, out string value)
            {
                type = CefHandlerStatusType.MouseOverUrl;
                if (messages.TryGetValue(type, out value)) return;

                type = CefHandlerStatusType.KeyboardFocusUrl;
                if (messages.TryGetValue(type, out value)) return;

                type = CefHandlerStatusType.Text;
                if (messages.TryGetValue(type, out value)) return;
            }
        }
    }
}
