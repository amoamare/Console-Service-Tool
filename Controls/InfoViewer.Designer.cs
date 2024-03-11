namespace ConsoleServiceTool.Controls
{
    partial class InfoViewer
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
            ButtonClose = new PictureBox();
            LabelLoading = new Label();
            ((System.ComponentModel.ISupportInitialize)WebViewMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ButtonClose).BeginInit();
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
            WebViewMain.Size = new Size(763, 561);
            WebViewMain.TabIndex = 3;
            WebViewMain.ZoomFactor = 1D;
            WebViewMain.CoreWebView2InitializationCompleted += WebViewMain_CoreWebView2InitializationCompleted;
            // 
            // ButtonClose
            // 
            ButtonClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonClose.BackColor = Color.Transparent;
            ButtonClose.Image = Properties.Resources.close_black_icon;
            ButtonClose.InitialImage = Properties.Resources.close_black_icon;
            ButtonClose.Location = new Point(727, 3);
            ButtonClose.Name = "ButtonClose";
            ButtonClose.Size = new Size(16, 16);
            ButtonClose.TabIndex = 4;
            ButtonClose.TabStop = false;
            ButtonClose.Click += ButtonClose_Click;
            ButtonClose.MouseDown += ButtonClose_MouseDown;
            ButtonClose.MouseEnter += ButtonClose_MouseEnter;
            ButtonClose.MouseLeave += ButtonClose_MouseLeave;
            // 
            // LabelLoading
            // 
            LabelLoading.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LabelLoading.BackColor = Color.Transparent;
            LabelLoading.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelLoading.Location = new Point(3, 243);
            LabelLoading.Name = "LabelLoading";
            LabelLoading.Size = new Size(757, 59);
            LabelLoading.TabIndex = 5;
            LabelLoading.Text = "Loading...";
            LabelLoading.TextAlign = ContentAlignment.MiddleCenter;
            LabelLoading.VisibleChanged += LabelLoading_VisibleChanged;
            // 
            // InfoViewer
            // 
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(LabelLoading);
            Controls.Add(ButtonClose);
            Controls.Add(WebViewMain);
            Name = "InfoViewer";
            Size = new Size(763, 561);
            ((System.ComponentModel.ISupportInitialize)WebViewMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)ButtonClose).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Microsoft.Web.WebView2.WinForms.WebView2 WebViewMain;
        private PictureBox ButtonClose;
        private Label LabelLoading;
    }
}
