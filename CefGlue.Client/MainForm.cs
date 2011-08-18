namespace CefGlue.Client
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using CefGlue;
    using CefGlue.Windows.Forms;

    public partial class MainForm : Form
    {
        private string caption;
        private CefWebBrowser browser;

        private const string homeUrl = "https://bitbucket.org/fddima/cefglue";
        private const string chromiumEmbeddedUrl = "http://code.google.com/p/chromiumembedded";

        public MainForm()
        {
            InitializeComponent();

            this.caption = this.Text;

            var settings = new CefBrowserSettings();
            // settings.WebSecurityDisabled = true;
            // settings.DragDropDisabled = true;
            // settings.MinimumFontSize = 20;
            // settings.ImageLoadDisabled = true;
            // settings.JavaScriptDisabled = true;
            // settings.JavaScriptOpenWindowsDisallowed = false;
            // settings.JavaScriptCloseWindowsDisallowed = true;
            // settings.JavaScriptAccessClipboardDisallowed = true;
            // settings.DefaultEncoding = "Windows-1251";
            // settings.EncodingDetectorEnabled = false;
            // settings.DeveloperToolsDisabled = true;

            this.browser = new CefWebBrowser(settings, homeUrl);
            this.browser.Parent = this;
            this.browser.Dock = DockStyle.Fill;
            this.browser.BringToFront();

            this.browser.BackColor = Color.White;

            this.browser.CanGoBackChanged += new EventHandler(browser_CanGoBackChanged);
            this.browser.CanGoForwardChanged += new EventHandler(browser_CanGoForwardChanged);
            this.browser.AddressChanged += new EventHandler(browser_AddressChanged);
            this.browser.TitleChanged += new EventHandler(browser_TitleChanged);
            this.browser.StatusMessage += new EventHandler<CefStatusMessageEventArgs>(browser_StatusMessage);

        }

        void browser_CanGoBackChanged(object sender, EventArgs e)
        {
            var browser = (CefWebBrowser)sender;
            goBackButton.Enabled = browser.CanGoBack;
        }

        void browser_CanGoForwardChanged(object sender, EventArgs e)
        {
            var browser = (CefWebBrowser)sender;
            goForwardButton.Enabled = browser.CanGoForward;
        }

        void browser_AddressChanged(object sender, EventArgs e)
        {
            var browser = (CefWebBrowser)sender;
            addressTextBox.Text = browser.Address;
        }

        void browser_TitleChanged(object sender, EventArgs e)
        {
            var browser = (CefWebBrowser)sender;
            var documentTitle = browser.Title;
            if (documentTitle != "" && documentTitle != caption)
            {
                this.Text = documentTitle + " - " + this.caption;
            }
            else
            {
                this.Text = this.caption;
            }
        }

        void browser_StatusMessage(object sender, CefStatusMessageEventArgs e)
        {
            var browser = (CefWebBrowser)sender;
            this.statusLabel.Visible = true;
            if (string.IsNullOrEmpty(e.Value))
            {
                this.statusLabel.Text = "";
            }
            else
            {
                this.statusLabel.Text = string.Format("{0}: {1}", e.Type, e.Value);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            /*
            if (this.browser != null)
            {
                if (!this.browser.IsDisposed)
                {
                    this.browser.Close();
                }
            }
            */

            if (!Cef.CurrentSettings.MultiThreadedMessageLoop)
            {
                NativeMethods.PostQuitMessage(0);
            }
        }

        private void fileExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void browserCloseMenuItem_Click(object sender, EventArgs e)
        {
            this.browser.Close();
        }

        private void browserShowDevToolsMenuItem_Click(object sender, EventArgs e)
        {
            this.browser.ShowDevTools();
        }

        private void browserCloseDevToolsMenuItem_Click(object sender, EventArgs e)
        {
            this.browser.CloseDevTools();
        }

        private void bookmarksCefGlueHomeMenuItem_Click(object sender, EventArgs e)
        {
            this.addressTextBox.Text = homeUrl;
            this.goButton.PerformClick();
        }

        private void bookmarksCefHomeMenuItem_Click(object sender, EventArgs e)
        {
            this.addressTextBox.Text = chromiumEmbeddedUrl;
            this.goButton.PerformClick();
        }

        private void bookmarksGoogleSearchMenuItem_Click(object sender, EventArgs e)
        {
            this.addressTextBox.Text = "http://google.com";
            this.goButton.PerformClick();
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            this.browser.GoBack();
        }

        private void goForwardButton_Click(object sender, EventArgs e)
        {
            this.browser.GoForward();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            this.browser.StopLoad();
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            this.browser.Reload();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            this.browser.LoadURL(addressTextBox.Text);
        }

        private void addressTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') goButton.PerformClick();
        }

    }
}
