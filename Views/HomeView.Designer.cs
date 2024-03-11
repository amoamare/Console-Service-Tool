namespace ConsoleServiceTool.Views
{
    partial class HomeView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            WebViewMain = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)WebViewMain).BeginInit();
            SuspendLayout();
            // 
            // WebViewMain
            // 
            WebViewMain.AllowExternalDrop = false;
            WebViewMain.CreationProperties = null;
            WebViewMain.DefaultBackgroundColor = Color.Transparent;
            WebViewMain.Dock = DockStyle.Fill;
            WebViewMain.Location = new Point(0, 0);
            WebViewMain.Name = "WebViewMain";
            WebViewMain.Size = new Size(696, 488);
            WebViewMain.Source = new Uri("https://consoleservicetool.com/news", UriKind.Absolute);
            WebViewMain.TabIndex = 5;
            WebViewMain.ZoomFactor = 1D;
            WebViewMain.CoreWebView2InitializationCompleted += WebViewMain_CoreWebView2InitializationCompleted;
            // 
            // HomeView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(WebViewMain);
            Name = "HomeView";
            Size = new Size(696, 488);
            ((System.ComponentModel.ISupportInitialize)WebViewMain).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 WebViewMain;
    }
}
