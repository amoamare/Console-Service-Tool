namespace ConsoleServiceTool.Console.Sony.PlayStation5.Views
{
    partial class PS5UartView
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
            ButtonRunOperation = new Button();
            ComboBoxOperationType = new ComboBox();
            ComboBoxDevices = new ComboBox();
            label1 = new Label();
            label3 = new Label();
            PanelInfo = new Panel();
            Log = new Controls.ReadOnlyRichTextBox();
            PanelRawCommand = new Panel();
            LabelRawCommand = new Label();
            TextBoxRawCommand = new TextBox();
            panel3 = new Panel();
            HighlightSevereLines = new CheckBox();
            ShowErrorLine = new CheckBox();
            PanelInfo.SuspendLayout();
            PanelRawCommand.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // ButtonRunOperation
            // 
            ButtonRunOperation.Location = new Point(594, 16);
            ButtonRunOperation.Margin = new Padding(3, 2, 3, 2);
            ButtonRunOperation.Name = "ButtonRunOperation";
            ButtonRunOperation.Size = new Size(82, 22);
            ButtonRunOperation.TabIndex = 0;
            ButtonRunOperation.Text = "Run Operation";
            ButtonRunOperation.UseVisualStyleBackColor = true;
            ButtonRunOperation.Click += ButtonRunOperations_Click;
            // 
            // ComboBoxOperationType
            // 
            ComboBoxOperationType.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxOperationType.FormattingEnabled = true;
            ComboBoxOperationType.Location = new Point(3, 17);
            ComboBoxOperationType.Margin = new Padding(3, 2, 3, 2);
            ComboBoxOperationType.Name = "ComboBoxOperationType";
            ComboBoxOperationType.Size = new Size(587, 23);
            ComboBoxOperationType.TabIndex = 9;
            ComboBoxOperationType.SelectedValueChanged += ComboBoxOperationType_SelectedValueChanged;
            // 
            // ComboBoxDevices
            // 
            ComboBoxDevices.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxDevices.FormattingEnabled = true;
            ComboBoxDevices.Location = new Point(3, 58);
            ComboBoxDevices.Margin = new Padding(3, 2, 3, 2);
            ComboBoxDevices.Name = "ComboBoxDevices";
            ComboBoxDevices.Size = new Size(587, 23);
            ComboBoxDevices.TabIndex = 3;
            ComboBoxDevices.DropDown += ComboBoxDevices_DropDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 40);
            label1.Name = "label1";
            label1.Size = new Size(117, 15);
            label1.TabIndex = 4;
            label1.Text = "Serial Devices (UART)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(121, 15);
            label3.TabIndex = 10;
            label3.Text = "Select Operation Type";
            // 
            // PanelInfo
            // 
            PanelInfo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PanelInfo.Controls.Add(Log);
            PanelInfo.Dock = DockStyle.Fill;
            PanelInfo.Location = new Point(0, 132);
            PanelInfo.Margin = new Padding(3, 2, 3, 2);
            PanelInfo.Name = "PanelInfo";
            PanelInfo.Size = new Size(939, 368);
            PanelInfo.TabIndex = 17;
            // 
            // Log
            // 
            Log.Dock = DockStyle.Fill;
            Log.Location = new Point(0, 0);
            Log.Margin = new Padding(3, 2, 3, 2);
            Log.Name = "Log";
            Log.ReadOnly = true;
            Log.Size = new Size(939, 368);
            Log.TabIndex = 20;
            Log.TabStop = false;
            Log.Text = "";
            // 
            // PanelRawCommand
            // 
            PanelRawCommand.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PanelRawCommand.Controls.Add(LabelRawCommand);
            PanelRawCommand.Controls.Add(TextBoxRawCommand);
            PanelRawCommand.Dock = DockStyle.Top;
            PanelRawCommand.Location = new Point(0, 86);
            PanelRawCommand.Margin = new Padding(3, 2, 3, 2);
            PanelRawCommand.Name = "PanelRawCommand";
            PanelRawCommand.Size = new Size(939, 46);
            PanelRawCommand.TabIndex = 16;
            PanelRawCommand.Visible = false;
            // 
            // LabelRawCommand
            // 
            LabelRawCommand.AutoSize = true;
            LabelRawCommand.Location = new Point(3, 2);
            LabelRawCommand.Name = "LabelRawCommand";
            LabelRawCommand.Size = new Size(89, 15);
            LabelRawCommand.TabIndex = 11;
            LabelRawCommand.Text = "Raw Command";
            // 
            // TextBoxRawCommand
            // 
            TextBoxRawCommand.Enabled = false;
            TextBoxRawCommand.Location = new Point(3, 20);
            TextBoxRawCommand.Margin = new Padding(3, 2, 3, 2);
            TextBoxRawCommand.Name = "TextBoxRawCommand";
            TextBoxRawCommand.Size = new Size(587, 23);
            TextBoxRawCommand.TabIndex = 12;
            TextBoxRawCommand.KeyPress += TextBoxRawCommand_KeyPress;
            // 
            // panel3
            // 
            panel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel3.Controls.Add(HighlightSevereLines);
            panel3.Controls.Add(ShowErrorLine);
            panel3.Controls.Add(ButtonRunOperation);
            panel3.Controls.Add(ComboBoxOperationType);
            panel3.Controls.Add(ComboBoxDevices);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label3);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(3, 2, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(939, 86);
            panel3.TabIndex = 15;
            // 
            // HighlightSevereLines
            // 
            HighlightSevereLines.AutoSize = true;
            HighlightSevereLines.Checked = true;
            HighlightSevereLines.CheckState = CheckState.Checked;
            HighlightSevereLines.Location = new Point(744, 59);
            HighlightSevereLines.Margin = new Padding(3, 2, 3, 2);
            HighlightSevereLines.Name = "HighlightSevereLines";
            HighlightSevereLines.Size = new Size(143, 19);
            HighlightSevereLines.TabIndex = 12;
            HighlightSevereLines.Text = "Highlight Severe Lines";
            HighlightSevereLines.UseVisualStyleBackColor = true;
            // 
            // ShowErrorLine
            // 
            ShowErrorLine.AutoSize = true;
            ShowErrorLine.Checked = true;
            ShowErrorLine.CheckState = CheckState.Checked;
            ShowErrorLine.Location = new Point(594, 59);
            ShowErrorLine.Margin = new Padding(3, 2, 3, 2);
            ShowErrorLine.Name = "ShowErrorLine";
            ShowErrorLine.Size = new Size(133, 19);
            ShowErrorLine.TabIndex = 11;
            ShowErrorLine.Text = "Show Line Response";
            ShowErrorLine.UseVisualStyleBackColor = true;
            // 
            // PS5UartView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(PanelInfo);
            Controls.Add(PanelRawCommand);
            Controls.Add(panel3);
            DoubleBuffered = true;
            Margin = new Padding(3, 2, 3, 2);
            Name = "PS5UartView";
            Size = new Size(939, 500);
            Load += PS5UartView_Load;
            PanelInfo.ResumeLayout(false);
            PanelRawCommand.ResumeLayout(false);
            PanelRawCommand.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button ButtonRunOperation;
        private ComboBox ComboBoxOperationType;
        private ComboBox ComboBoxDevices;
        private Label label1;
        private Label label3;
        private Panel PanelInfo;
        private Panel PanelRawCommand;
        private Label LabelRawCommand;
        private TextBox TextBoxRawCommand;
        private Panel panel3;
        private Controls.ReadOnlyRichTextBox Log;
        private CheckBox ShowErrorLine;
        private CheckBox HighlightSevereLines;
    }
}
