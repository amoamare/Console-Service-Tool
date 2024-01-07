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
            panel4 = new Panel();
            Log = new Controls.ReadOnlyRichTextBox();
            PanelRawCommand = new Panel();
            LabelRawCommand = new Label();
            TextBoxRawCommand = new TextBox();
            panel3 = new Panel();
            panel4.SuspendLayout();
            PanelRawCommand.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // ButtonRunOperation
            // 
            ButtonRunOperation.Location = new Point(679, 22);
            ButtonRunOperation.Name = "ButtonRunOperation";
            ButtonRunOperation.Size = new Size(94, 29);
            ButtonRunOperation.TabIndex = 0;
            ButtonRunOperation.Text = "Run Operation";
            ButtonRunOperation.UseVisualStyleBackColor = true;
            ButtonRunOperation.Click += ButtonRunOperations_Click;
            // 
            // ComboBoxOperationType
            // 
            ComboBoxOperationType.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxOperationType.FormattingEnabled = true;
            ComboBoxOperationType.Location = new Point(3, 23);
            ComboBoxOperationType.Name = "ComboBoxOperationType";
            ComboBoxOperationType.Size = new Size(670, 28);
            ComboBoxOperationType.TabIndex = 9;
            ComboBoxOperationType.SelectedValueChanged += ComboBoxOperationType_SelectedValueChanged;
            // 
            // ComboBoxDevices
            // 
            ComboBoxDevices.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxDevices.FormattingEnabled = true;
            ComboBoxDevices.Location = new Point(3, 77);
            ComboBoxDevices.Name = "ComboBoxDevices";
            ComboBoxDevices.Size = new Size(670, 28);
            ComboBoxDevices.TabIndex = 3;
            ComboBoxDevices.DropDown += ComboBoxDevices_DropDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 54);
            label1.Name = "label1";
            label1.Size = new Size(151, 20);
            label1.TabIndex = 4;
            label1.Text = "Serial Devices (UART)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(155, 20);
            label3.TabIndex = 10;
            label3.Text = "Select Operation Type";
            // 
            // panel4
            // 
            panel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel4.Controls.Add(Log);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 177);
            panel4.Name = "panel4";
            panel4.Size = new Size(1073, 490);
            panel4.TabIndex = 17;
            // 
            // Log
            // 
            Log.Dock = DockStyle.Fill;
            Log.Location = new Point(0, 0);
            Log.Name = "Log";
            Log.ReadOnly = true;
            Log.Size = new Size(1073, 490);
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
            PanelRawCommand.Location = new Point(0, 115);
            PanelRawCommand.Name = "PanelRawCommand";
            PanelRawCommand.Size = new Size(1073, 62);
            PanelRawCommand.TabIndex = 16;
            PanelRawCommand.Visible = false;
            // 
            // LabelRawCommand
            // 
            LabelRawCommand.AutoSize = true;
            LabelRawCommand.Location = new Point(3, 3);
            LabelRawCommand.Name = "LabelRawCommand";
            LabelRawCommand.Size = new Size(110, 20);
            LabelRawCommand.TabIndex = 11;
            LabelRawCommand.Text = "Raw Command";
            // 
            // TextBoxRawCommand
            // 
            TextBoxRawCommand.Enabled = false;
            TextBoxRawCommand.Location = new Point(3, 26);
            TextBoxRawCommand.Name = "TextBoxRawCommand";
            TextBoxRawCommand.Size = new Size(670, 27);
            TextBoxRawCommand.TabIndex = 12;
            // 
            // panel3
            // 
            panel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel3.Controls.Add(ButtonRunOperation);
            panel3.Controls.Add(ComboBoxOperationType);
            panel3.Controls.Add(ComboBoxDevices);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label3);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(3, 3, 3, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(1073, 115);
            panel3.TabIndex = 15;
            // 
            // PS5UartView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel4);
            Controls.Add(PanelRawCommand);
            Controls.Add(panel3);
            Name = "PS5UartView";
            Size = new Size(1073, 667);
            Load += PS5UartView_Load;
            panel4.ResumeLayout(false);
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
        private Panel panel4;
        private Panel PanelRawCommand;
        private Label LabelRawCommand;
        private TextBox TextBoxRawCommand;
        private Panel panel3;
        private Controls.ReadOnlyRichTextBox Log;
    }
}
