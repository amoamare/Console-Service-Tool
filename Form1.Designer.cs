using ConsoleServiceTool.Console.Sony.PlayStation5.Views;

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
            menuStrip1 = new MenuStrip();
            homeToolStripMenuItem = new ToolStripMenuItem();
            sonyToolStripMenuItem = new ToolStripMenuItem();
            playStation5ToolStripMenuItem = new ToolStripMenuItem();
            MainPanel = new Panel();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, sonyToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1564, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            homeToolStripMenuItem.Size = new Size(52, 20);
            homeToolStripMenuItem.Text = "Home";
            // 
            // sonyToolStripMenuItem
            // 
            sonyToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { playStation5ToolStripMenuItem });
            sonyToolStripMenuItem.Name = "sonyToolStripMenuItem";
            sonyToolStripMenuItem.Size = new Size(45, 20);
            sonyToolStripMenuItem.Text = "Sony";
            // 
            // playStation5ToolStripMenuItem
            // 
            playStation5ToolStripMenuItem.Name = "playStation5ToolStripMenuItem";
            playStation5ToolStripMenuItem.Size = new Size(142, 22);
            playStation5ToolStripMenuItem.Text = "PlayStation 5";
            // 
            // MainPanel
            // 
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 75);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1564, 916);
            MainPanel.TabIndex = 2;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ControlLight;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Open Sans", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 24);
            label1.Margin = new Padding(15);
            label1.Name = "label1";
            label1.Padding = new Padding(20, 0, 0, 0);
            label1.Size = new Size(1564, 51);
            label1.TabIndex = 3;
            label1.Text = "Home";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1564, 991);
            Controls.Add(MainPanel);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Console Service Tool (C.S.T)";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem sonyToolStripMenuItem;
        private ToolStripMenuItem playStation5ToolStripMenuItem;
        private ToolStripMenuItem homeToolStripMenuItem;
        private Panel MainPanel;
        private Label label1;
    }
}