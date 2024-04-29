namespace ConsoleServiceTool.Console.Sony.PlayStation5.Views
{
    partial class ControllerView
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
            dualControlWebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            panel1 = new Panel();
            readOnlyRichTextBox1 = new Controls.ReadOnlyRichTextBox();
            button2 = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dualControlWebView).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dualControlWebView
            // 
            dualControlWebView.AllowExternalDrop = true;
            dualControlWebView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dualControlWebView.BackColor = SystemColors.ActiveCaption;
            dualControlWebView.CreationProperties = null;
            dualControlWebView.DefaultBackgroundColor = Color.White;
            dualControlWebView.Location = new Point(0, 117);
            dualControlWebView.Margin = new Padding(4, 3, 4, 3);
            dualControlWebView.Name = "dualControlWebView";
            dualControlWebView.Size = new Size(1281, 696);
            dualControlWebView.Source = new Uri("https://dualshock-tools.github.io/", UriKind.Absolute);
            dualControlWebView.TabIndex = 0;
            dualControlWebView.ZoomFactor = 1D;
            dualControlWebView.CoreWebView2InitializationCompleted += dualControlWebView_CoreWebView2InitializationCompleted;
            // 
            // panel1
            // 
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(readOnlyRichTextBox1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(17, 26);
            panel1.Name = "panel1";
            panel1.Size = new Size(1238, 76);
            panel1.TabIndex = 1;
            // 
            // readOnlyRichTextBox1
            // 
            readOnlyRichTextBox1.Location = new Point(465, 12);
            readOnlyRichTextBox1.Name = "readOnlyRichTextBox1";
            readOnlyRichTextBox1.ReadOnly = true;
            readOnlyRichTextBox1.Size = new Size(770, 61);
            readOnlyRichTextBox1.TabIndex = 2;
            readOnlyRichTextBox1.TabStop = false;
            readOnlyRichTextBox1.Text = "The dualshock calibration tool and Gamepad tester are not affiliated with the Console Service Tool. Please consider supporting the maintainers of these tools.";
            // 
            // button2
            // 
            button2.Location = new Point(241, 19);
            button2.Name = "button2";
            button2.Size = new Size(200, 34);
            button2.TabIndex = 1;
            button2.Text = "Gamepad tester";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(16, 19);
            button1.Name = "button1";
            button1.Size = new Size(201, 34);
            button1.TabIndex = 0;
            button1.Text = "Dualshock calibration";
            button1.UseVisualStyleBackColor = true;
            button1.MouseDown += button1_MouseDown;
            // 
            // ControllerView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(panel1);
            Controls.Add(dualControlWebView);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ControllerView";
            Size = new Size(1281, 837);
            ((System.ComponentModel.ISupportInitialize)dualControlWebView).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 dualControlWebView;
        private Panel panel1;
        private Button button1;
        private Button button2;
        private Controls.ReadOnlyRichTextBox readOnlyRichTextBox1;
    }
}
