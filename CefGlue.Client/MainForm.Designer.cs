namespace CefGlue.Client
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browserMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miCloseBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.browserShowDevToolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browserCloseDevToolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookmarksMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookmarksCefGlueHomeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookmarksCefHomeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookmarksGoogleSearchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.goBackButton = new System.Windows.Forms.ToolStripButton();
            this.goForwardButton = new System.Windows.Forms.ToolStripButton();
            this.stopButton = new System.Windows.Forms.ToolStripButton();
            this.reloadButton = new System.Windows.Forms.ToolStripButton();
            this.addressTextBox = new CefGlue.Client.ToolStripSpringTextBox();
            this.goButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.browserMenuItem,
            this.bookmarksMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileExitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "&File";
            // 
            // fileExitMenuItem
            // 
            this.fileExitMenuItem.Name = "fileExitMenuItem";
            this.fileExitMenuItem.Size = new System.Drawing.Size(92, 22);
            this.fileExitMenuItem.Text = "E&xit";
            this.fileExitMenuItem.Click += new System.EventHandler(this.fileExitMenuItem_Click);
            // 
            // browserMenuItem
            // 
            this.browserMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCloseBrowser,
            this.toolStripSeparator1,
            this.browserShowDevToolsMenuItem,
            this.browserCloseDevToolsMenuItem});
            this.browserMenuItem.Name = "browserMenuItem";
            this.browserMenuItem.Size = new System.Drawing.Size(61, 20);
            this.browserMenuItem.Text = "&Browser";
            // 
            // miCloseBrowser
            // 
            this.miCloseBrowser.Name = "miCloseBrowser";
            this.miCloseBrowser.Size = new System.Drawing.Size(191, 22);
            this.miCloseBrowser.Text = "CloseBrowser";
            this.miCloseBrowser.Click += new System.EventHandler(this.browserCloseMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // browserShowDevToolsMenuItem
            // 
            this.browserShowDevToolsMenuItem.Name = "browserShowDevToolsMenuItem";
            this.browserShowDevToolsMenuItem.Size = new System.Drawing.Size(191, 22);
            this.browserShowDevToolsMenuItem.Text = "Show Developer Tools";
            this.browserShowDevToolsMenuItem.Click += new System.EventHandler(this.browserShowDevToolsMenuItem_Click);
            // 
            // browserCloseDevToolsMenuItem
            // 
            this.browserCloseDevToolsMenuItem.Name = "browserCloseDevToolsMenuItem";
            this.browserCloseDevToolsMenuItem.Size = new System.Drawing.Size(191, 22);
            this.browserCloseDevToolsMenuItem.Text = "Close Developer Tools";
            this.browserCloseDevToolsMenuItem.Click += new System.EventHandler(this.browserCloseDevToolsMenuItem_Click);
            // 
            // bookmarksMenuItem
            // 
            this.bookmarksMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookmarksCefGlueHomeMenuItem,
            this.bookmarksCefHomeMenuItem,
            this.bookmarksGoogleSearchMenuItem});
            this.bookmarksMenuItem.Name = "bookmarksMenuItem";
            this.bookmarksMenuItem.Size = new System.Drawing.Size(78, 20);
            this.bookmarksMenuItem.Text = "&Bookmarks";
            // 
            // bookmarksCefGlueHomeMenuItem
            // 
            this.bookmarksCefGlueHomeMenuItem.Name = "bookmarksCefGlueHomeMenuItem";
            this.bookmarksCefGlueHomeMenuItem.Size = new System.Drawing.Size(254, 22);
            this.bookmarksCefGlueHomeMenuItem.Text = "&CefGlue Project";
            this.bookmarksCefGlueHomeMenuItem.Click += new System.EventHandler(this.bookmarksCefGlueHomeMenuItem_Click);
            // 
            // bookmarksCefHomeMenuItem
            // 
            this.bookmarksCefHomeMenuItem.Name = "bookmarksCefHomeMenuItem";
            this.bookmarksCefHomeMenuItem.Size = new System.Drawing.Size(254, 22);
            this.bookmarksCefHomeMenuItem.Text = "Chromium Embedded Framework";
            this.bookmarksCefHomeMenuItem.Click += new System.EventHandler(this.bookmarksCefHomeMenuItem_Click);
            // 
            // bookmarksGoogleSearchMenuItem
            // 
            this.bookmarksGoogleSearchMenuItem.Name = "bookmarksGoogleSearchMenuItem";
            this.bookmarksGoogleSearchMenuItem.Size = new System.Drawing.Size(254, 22);
            this.bookmarksGoogleSearchMenuItem.Text = "Google &Search";
            this.bookmarksGoogleSearchMenuItem.Click += new System.EventHandler(this.bookmarksGoogleSearchMenuItem_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "blue_arrow_left_16.png");
            this.imageList.Images.SetKeyName(1, "blue_arrow_right_16.png");
            this.imageList.Images.SetKeyName(2, "close_16.png");
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goBackButton,
            this.goForwardButton,
            this.stopButton,
            this.reloadButton,
            this.addressTextBox,
            this.goButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip.TabIndex = 2;
            // 
            // goBackButton
            // 
            this.goBackButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.goBackButton.Enabled = false;
            this.goBackButton.Image = global::CefGlue.Client.Properties.Resources.blue_arrow_left_16;
            this.goBackButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.goBackButton.Name = "goBackButton";
            this.goBackButton.Size = new System.Drawing.Size(23, 22);
            this.goBackButton.Text = "Back";
            this.goBackButton.Click += new System.EventHandler(this.goBackButton_Click);
            // 
            // goForwardButton
            // 
            this.goForwardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.goForwardButton.Enabled = false;
            this.goForwardButton.Image = global::CefGlue.Client.Properties.Resources.blue_arrow_right_16;
            this.goForwardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.goForwardButton.Name = "goForwardButton";
            this.goForwardButton.Size = new System.Drawing.Size(23, 22);
            this.goForwardButton.Text = "Forward";
            this.goForwardButton.Click += new System.EventHandler(this.goForwardButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopButton.Enabled = false;
            this.stopButton.Image = global::CefGlue.Client.Properties.Resources.close_16;
            this.stopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(23, 22);
            this.stopButton.Text = "Stop";
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // reloadButton
            // 
            this.reloadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.reloadButton.Enabled = false;
            this.reloadButton.Image = global::CefGlue.Client.Properties.Resources.reload_16;
            this.reloadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(23, 22);
            this.reloadButton.Text = "Reload";
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // addressTextBox
            // 
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(850, 25);
            this.addressTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.addressTextBox_KeyPress);
            // 
            // goButton
            // 
            this.goButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.goButton.Image = global::CefGlue.Client.Properties.Resources.go_16;
            this.goButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(23, 22);
            this.goButton.Text = "Go";
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 658);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip.TabIndex = 3;
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            this.progressBar.Visible = false;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(993, 17);
            this.statusLabel.Spring = true;
            this.statusLabel.Text = "statusLabel";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusLabel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 680);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "CefGlue Client";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browserMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miCloseBrowser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem browserShowDevToolsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browserCloseDevToolsMenuItem;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton goBackButton;
        private System.Windows.Forms.ToolStripButton goForwardButton;
        private System.Windows.Forms.ToolStripButton reloadButton;
        private ToolStripSpringTextBox addressTextBox;
        private System.Windows.Forms.ToolStripButton goButton;
        private System.Windows.Forms.ToolStripButton stopButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripMenuItem bookmarksMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookmarksCefGlueHomeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookmarksGoogleSearchMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripMenuItem bookmarksCefHomeMenuItem;
    }
}

