namespace ConsoleServiceTool
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            TabControlPS5Uart = new TabControl();
            TabPagePS5Nor = new TabPage();
            TabPagePS5Uart = new TabPage();
            tabPage2 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            TabControlPS5Uart.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(917, 542);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(TabControlPS5Uart);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 2, 3, 2);
            tabPage1.Size = new Size(909, 514);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Playstation 5";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // TabControlPS5Uart
            // 
            TabControlPS5Uart.Controls.Add(TabPagePS5Nor);
            TabControlPS5Uart.Controls.Add(TabPagePS5Uart);
            TabControlPS5Uart.Dock = DockStyle.Fill;
            TabControlPS5Uart.Location = new Point(3, 2);
            TabControlPS5Uart.Margin = new Padding(3, 2, 3, 2);
            TabControlPS5Uart.Name = "TabControlPS5Uart";
            TabControlPS5Uart.SelectedIndex = 0;
            TabControlPS5Uart.Size = new Size(903, 510);
            TabControlPS5Uart.TabIndex = 0;
            // 
            // TabPagePS5Nor
            // 
            TabPagePS5Nor.Location = new Point(4, 24);
            TabPagePS5Nor.Margin = new Padding(3, 2, 3, 2);
            TabPagePS5Nor.Name = "TabPagePS5Nor";
            TabPagePS5Nor.Padding = new Padding(3, 2, 3, 2);
            TabPagePS5Nor.Size = new Size(895, 482);
            TabPagePS5Nor.TabIndex = 0;
            TabPagePS5Nor.Text = "NOR Tools";
            TabPagePS5Nor.UseVisualStyleBackColor = true;
            // 
            // TabPagePS5Uart
            // 
            TabPagePS5Uart.Location = new Point(4, 24);
            TabPagePS5Uart.Margin = new Padding(3, 2, 3, 2);
            TabPagePS5Uart.Name = "TabPagePS5Uart";
            TabPagePS5Uart.Padding = new Padding(3, 2, 3, 2);
            TabPagePS5Uart.Size = new Size(895, 482);
            TabPagePS5Uart.TabIndex = 1;
            TabPagePS5Uart.Text = "UART Tools";
            TabPagePS5Uart.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(909, 514);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Playstation 4";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(917, 542);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Console Service Tool (C.S.T)";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            TabControlPS5Uart.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabControl TabControlPS5Uart;
        private TabPage TabPagePS5Nor;
        private TabPage TabPagePS5Uart;
        private TabPage tabPage2;
    }
}