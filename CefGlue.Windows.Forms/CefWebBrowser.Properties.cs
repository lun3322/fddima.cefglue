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
        private string title = null;
        private bool canGoBack = false;
        private bool canGoForward = false;
        private string address = null;

        public string StartUrl { get; set; }

        public string Title
        {
            get
            {
                if (this.title == null)
                {
                    // FIXME: check that browser created
                    // FIXME: this.title = this.browser.Title;
                    this.title = "";
                }
                return this.title;
            }
            private set
            {
                if (this.title != value)
                {
                    this.title = value;
                    OnTitleChanged(EventArgs.Empty);
                }
            }
        }

        public bool CanGoBack
        {
            get
            {
                // FIXME: ???
                return this.canGoBack;
            }
            private set
            {
                if (this.canGoBack != value)
                {
                    this.canGoBack = value;
                    OnCanGoBackChanged(EventArgs.Empty);
                }
            }
        }

        public bool CanGoForward
        {
            get
            {
                // FIXME: ???
                return this.canGoForward;
            }
            private set
            {
                if (this.canGoForward != value)
                {
                    this.canGoForward = value;
                    OnCanGoForwardChanged(EventArgs.Empty);
                }
            }
        }

        public string Address
        {
            get
            {
                if (this.address == null)
                {
                    // FIXME: check that browser created
                    // FIXME: this.Address = this.browser.Address;
                    this.address = "";
                }
                return this.address;
            }
            private set
            {
                if (this.address != value)
                {
                    this.address = value;
                    OnAddressChanged(EventArgs.Empty);
                }
            }
        }

        public double ZoomLevel
        {
            get
            {
                return this.browser.ZoomLevel;
            }
            set
            {
                this.browser.ZoomLevel = value;
            }
        }

    }
}
