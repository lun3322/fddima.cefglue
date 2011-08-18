namespace CefGlue.Windows.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Diagnostics;

    partial class CefWebBrowser
    {
        public event EventHandler TitleChanged;
        public event EventHandler CanGoBackChanged;
        public event EventHandler CanGoForwardChanged;
        public event EventHandler AddressChanged;
        public event EventHandler<CefStatusMessageEventArgs> StatusMessage;

        protected virtual void OnTitleChanged(EventArgs e)
        {
            var handler = TitleChanged;
            if (handler != null)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action<EventArgs>(this.OnTitleChanged), e);
                    return;
                }

                handler(this, e);
            }
        }

        protected virtual void OnCanGoBackChanged(EventArgs e)
        {
            var handler = CanGoBackChanged;
            if (handler != null)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action<EventArgs>(this.OnCanGoBackChanged), e);
                    return;
                }

                handler(this, e);
            }
        }

        protected virtual void OnCanGoForwardChanged(EventArgs e)
        {
            var handler = CanGoForwardChanged;
            if (handler != null)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action<EventArgs>(this.OnCanGoForwardChanged), e);
                    return;
                }

                handler(this, e);
            }
        }

        protected virtual void OnAddressChanged(EventArgs e)
        {
            var handler = AddressChanged;
            if (handler != null)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action<EventArgs>(this.OnAddressChanged), e);
                    return;
                }

                handler(this, e);
            }
        }

        protected virtual void OnStatusMessage(CefStatusMessageEventArgs e)
        {
            var handler = StatusMessage;
            if (handler != null)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action<CefStatusMessageEventArgs>(this.OnStatusMessage), e);
                    return;
                }

                handler(this, e);
            }
        }
    }
}
