namespace ConsoleServiceTool.Console.Sony.PlayStation5.Views
{
    partial class PS5NorView
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
            fileLocationBox = new TextBox();
            ButtonBrowse = new Button();
            panel1 = new Panel();
            PanelInfo = new Panel();
            lFrimwareVersion = new Label();
            ButtonSave = new Button();
            ConsoleTypeList = new ComboBox();
            SkuList = new ComboBox();
            WifiMacEdit = new RegExTextBox();
            MacEdit = new RegExTextBox();
            BoardIdEdit = new RegExTextBox();
            MotherboardSerialEdit = new RegExTextBox();
            SerialNumberEdit = new RegExTextBox();
            lMd5Sum = new Label();
            lFileSize = new Label();
            lSerialNumber = new Label();
            lWifiMac = new Label();
            lMac = new Label();
            lBoardId = new Label();
            lConsoleType = new Label();
            lMbSerial = new Label();
            lSku = new Label();
            label10 = new Label();
            label8 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            Log = new Controls.ReadOnlyRichTextBox();
            pS5osFlagsView1 = new PS5OSFlagsView();
            pS5osFlagsView2 = new PS5OSFlagsView();
            panel1.SuspendLayout();
            PanelInfo.SuspendLayout();
            SuspendLayout();
            // 
            // fileLocationBox
            // 
            fileLocationBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            fileLocationBox.Location = new Point(4, 5);
            fileLocationBox.Margin = new Padding(4, 3, 4, 3);
            fileLocationBox.Name = "fileLocationBox";
            fileLocationBox.ReadOnly = true;
            fileLocationBox.Size = new Size(1521, 31);
            fileLocationBox.TabIndex = 3;
            // 
            // ButtonBrowse
            // 
            ButtonBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonBrowse.Location = new Point(1533, 3);
            ButtonBrowse.Margin = new Padding(4, 3, 4, 3);
            ButtonBrowse.Name = "ButtonBrowse";
            ButtonBrowse.Size = new Size(117, 37);
            ButtonBrowse.TabIndex = 2;
            ButtonBrowse.Text = "Browse";
            ButtonBrowse.UseVisualStyleBackColor = true;
            ButtonBrowse.Click += ButtonBrowse_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(fileLocationBox);
            panel1.Controls.Add(ButtonBrowse);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1654, 43);
            panel1.TabIndex = 4;
            // 
            // PanelInfo
            // 
            PanelInfo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PanelInfo.Controls.Add(lFrimwareVersion);
            PanelInfo.Controls.Add(ButtonSave);
            PanelInfo.Controls.Add(ConsoleTypeList);
            PanelInfo.Controls.Add(SkuList);
            PanelInfo.Controls.Add(WifiMacEdit);
            PanelInfo.Controls.Add(MacEdit);
            PanelInfo.Controls.Add(BoardIdEdit);
            PanelInfo.Controls.Add(MotherboardSerialEdit);
            PanelInfo.Controls.Add(SerialNumberEdit);
            PanelInfo.Controls.Add(lMd5Sum);
            PanelInfo.Controls.Add(lFileSize);
            PanelInfo.Controls.Add(lSerialNumber);
            PanelInfo.Controls.Add(lWifiMac);
            PanelInfo.Controls.Add(lMac);
            PanelInfo.Controls.Add(lBoardId);
            PanelInfo.Controls.Add(lConsoleType);
            PanelInfo.Controls.Add(lMbSerial);
            PanelInfo.Controls.Add(lSku);
            PanelInfo.Controls.Add(label10);
            PanelInfo.Controls.Add(label8);
            PanelInfo.Controls.Add(label1);
            PanelInfo.Controls.Add(label2);
            PanelInfo.Controls.Add(label3);
            PanelInfo.Controls.Add(label4);
            PanelInfo.Controls.Add(label5);
            PanelInfo.Controls.Add(label6);
            PanelInfo.Controls.Add(label7);
            PanelInfo.Dock = DockStyle.Top;
            PanelInfo.Location = new Point(0, 43);
            PanelInfo.Margin = new Padding(4, 3, 4, 3);
            PanelInfo.Name = "PanelInfo";
            PanelInfo.Size = new Size(1654, 386);
            PanelInfo.TabIndex = 5;
            // 
            // lFrimwareVersion
            // 
            lFrimwareVersion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lFrimwareVersion.AutoSize = true;
            lFrimwareVersion.Location = new Point(1304, 301);
            lFrimwareVersion.Margin = new Padding(4, 0, 4, 0);
            lFrimwareVersion.Name = "lFrimwareVersion";
            lFrimwareVersion.Size = new Size(24, 25);
            lFrimwareVersion.TabIndex = 51;
            lFrimwareVersion.Text = "...";
            // 
            // ButtonSave
            // 
            ButtonSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonSave.Enabled = false;
            ButtonSave.Location = new Point(1532, 341);
            ButtonSave.Margin = new Padding(4, 3, 4, 3);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(117, 37);
            ButtonSave.TabIndex = 48;
            ButtonSave.Text = "Save";
            ButtonSave.UseVisualStyleBackColor = true;
            ButtonSave.Click += ButtonSave_Click;
            // 
            // ConsoleTypeList
            // 
            ConsoleTypeList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ConsoleTypeList.DropDownStyle = ComboBoxStyle.DropDownList;
            ConsoleTypeList.FormattingEnabled = true;
            ConsoleTypeList.Location = new Point(1304, 133);
            ConsoleTypeList.Margin = new Padding(4, 3, 4, 3);
            ConsoleTypeList.Name = "ConsoleTypeList";
            ConsoleTypeList.Size = new Size(345, 33);
            ConsoleTypeList.TabIndex = 47;
            // 
            // SkuList
            // 
            SkuList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SkuList.DropDownStyle = ComboBoxStyle.DropDownList;
            SkuList.FormattingEnabled = true;
            SkuList.Location = new Point(1304, 90);
            SkuList.Margin = new Padding(4, 3, 4, 3);
            SkuList.Name = "SkuList";
            SkuList.Size = new Size(345, 33);
            SkuList.TabIndex = 46;
            // 
            // WifiMacEdit
            // 
            WifiMacEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            WifiMacEdit.CharacterCasing = CharacterCasing.Upper;
            WifiMacEdit.Location = new Point(1304, 257);
            WifiMacEdit.Margin = new Padding(4, 3, 4, 3);
            WifiMacEdit.MinLength = -1;
            WifiMacEdit.Name = "WifiMacEdit";
            WifiMacEdit.OriginalValue = null;
            WifiMacEdit.RegEx = "[a-fA-F0-9]+";
            WifiMacEdit.Size = new Size(345, 31);
            WifiMacEdit.TabIndex = 45;
            // 
            // MacEdit
            // 
            MacEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MacEdit.CharacterCasing = CharacterCasing.Upper;
            MacEdit.Location = new Point(1304, 217);
            MacEdit.Margin = new Padding(4, 3, 4, 3);
            MacEdit.MaxLength = 12;
            MacEdit.MinLength = 12;
            MacEdit.Name = "MacEdit";
            MacEdit.OriginalValue = null;
            MacEdit.PlaceholderText = "Modify MAC";
            MacEdit.RegEx = "^[a-fA-F0-9]+$";
            MacEdit.Size = new Size(345, 31);
            MacEdit.TabIndex = 44;
            // 
            // BoardIdEdit
            // 
            BoardIdEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BoardIdEdit.CharacterCasing = CharacterCasing.Upper;
            BoardIdEdit.Location = new Point(1304, 175);
            BoardIdEdit.Margin = new Padding(4, 3, 4, 3);
            BoardIdEdit.MaxLength = 13;
            BoardIdEdit.MinLength = -1;
            BoardIdEdit.Name = "BoardIdEdit";
            BoardIdEdit.OriginalValue = null;
            BoardIdEdit.PlaceholderText = "Modify board ID up to 13 digits";
            BoardIdEdit.RegEx = "^[0-9]+$";
            BoardIdEdit.Size = new Size(345, 31);
            BoardIdEdit.TabIndex = 43;
            // 
            // MotherboardSerialEdit
            // 
            MotherboardSerialEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MotherboardSerialEdit.CharacterCasing = CharacterCasing.Upper;
            MotherboardSerialEdit.Location = new Point(1304, 48);
            MotherboardSerialEdit.Margin = new Padding(4, 3, 4, 3);
            MotherboardSerialEdit.MaxLength = 16;
            MotherboardSerialEdit.MinLength = -1;
            MotherboardSerialEdit.Name = "MotherboardSerialEdit";
            MotherboardSerialEdit.OriginalValue = null;
            MotherboardSerialEdit.PlaceholderText = "Modify MB serial up to 16 chars";
            MotherboardSerialEdit.RegEx = "^[a-fA-F0-9]+$";
            MotherboardSerialEdit.Size = new Size(345, 31);
            MotherboardSerialEdit.TabIndex = 42;
            // 
            // SerialNumberEdit
            // 
            SerialNumberEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SerialNumberEdit.CharacterCasing = CharacterCasing.Upper;
            SerialNumberEdit.Location = new Point(1304, 7);
            SerialNumberEdit.Margin = new Padding(4, 3, 4, 3);
            SerialNumberEdit.MaxLength = 32;
            SerialNumberEdit.MinLength = -1;
            SerialNumberEdit.Name = "SerialNumberEdit";
            SerialNumberEdit.OriginalValue = null;
            SerialNumberEdit.PlaceholderText = "Modify serial up to 16 chars";
            SerialNumberEdit.RegEx = "";
            SerialNumberEdit.Size = new Size(345, 31);
            SerialNumberEdit.TabIndex = 41;
            // 
            // lMd5Sum
            // 
            lMd5Sum.AutoSize = true;
            lMd5Sum.Location = new Point(187, 341);
            lMd5Sum.Margin = new Padding(4, 0, 4, 0);
            lMd5Sum.Name = "lMd5Sum";
            lMd5Sum.Size = new Size(20, 25);
            lMd5Sum.TabIndex = 62;
            lMd5Sum.Tag = "True";
            lMd5Sum.Text = "..";
            // 
            // lFileSize
            // 
            lFileSize.AutoSize = true;
            lFileSize.Location = new Point(187, 301);
            lFileSize.Margin = new Padding(4, 0, 4, 0);
            lFileSize.Name = "lFileSize";
            lFileSize.Size = new Size(20, 25);
            lFileSize.TabIndex = 61;
            lFileSize.Tag = "True";
            lFileSize.Text = "..";
            // 
            // lSerialNumber
            // 
            lSerialNumber.AutoSize = true;
            lSerialNumber.Location = new Point(187, 12);
            lSerialNumber.Margin = new Padding(4, 0, 4, 0);
            lSerialNumber.Name = "lSerialNumber";
            lSerialNumber.Size = new Size(20, 25);
            lSerialNumber.TabIndex = 60;
            lSerialNumber.Tag = "True";
            lSerialNumber.Text = "..";
            // 
            // lWifiMac
            // 
            lWifiMac.AutoSize = true;
            lWifiMac.Location = new Point(187, 262);
            lWifiMac.Margin = new Padding(4, 0, 4, 0);
            lWifiMac.Name = "lWifiMac";
            lWifiMac.Size = new Size(20, 25);
            lWifiMac.TabIndex = 54;
            lWifiMac.Tag = "True";
            lWifiMac.Text = "..";
            // 
            // lMac
            // 
            lMac.AutoSize = true;
            lMac.Location = new Point(187, 220);
            lMac.Margin = new Padding(4, 0, 4, 0);
            lMac.Name = "lMac";
            lMac.Size = new Size(20, 25);
            lMac.TabIndex = 55;
            lMac.Tag = "True";
            lMac.Text = "..";
            // 
            // lBoardId
            // 
            lBoardId.AutoSize = true;
            lBoardId.Location = new Point(187, 178);
            lBoardId.Margin = new Padding(4, 0, 4, 0);
            lBoardId.Name = "lBoardId";
            lBoardId.Size = new Size(20, 25);
            lBoardId.TabIndex = 56;
            lBoardId.Tag = "True";
            lBoardId.Text = "..";
            // 
            // lConsoleType
            // 
            lConsoleType.AutoSize = true;
            lConsoleType.Location = new Point(187, 137);
            lConsoleType.Margin = new Padding(4, 0, 4, 0);
            lConsoleType.Name = "lConsoleType";
            lConsoleType.Size = new Size(20, 25);
            lConsoleType.TabIndex = 57;
            lConsoleType.Tag = "True";
            lConsoleType.Text = "..";
            // 
            // lMbSerial
            // 
            lMbSerial.AutoSize = true;
            lMbSerial.Location = new Point(187, 53);
            lMbSerial.Margin = new Padding(4, 0, 4, 0);
            lMbSerial.Name = "lMbSerial";
            lMbSerial.Size = new Size(20, 25);
            lMbSerial.TabIndex = 59;
            lMbSerial.Tag = "True";
            lMbSerial.Text = "..";
            // 
            // lSku
            // 
            lSku.AutoSize = true;
            lSku.Location = new Point(187, 93);
            lSku.Margin = new Padding(4, 0, 4, 0);
            lSku.Name = "lSku";
            lSku.Size = new Size(20, 25);
            lSku.TabIndex = 58;
            lSku.Tag = "True";
            lSku.Text = "..";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(4, 341);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(141, 25);
            label10.TabIndex = 50;
            label10.Text = "MD5 Checksum:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(4, 301);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(78, 25);
            label8.TabIndex = 49;
            label8.Text = "File Size:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 12);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(128, 25);
            label1.TabIndex = 34;
            label1.Text = "Serial Number:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 93);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(48, 25);
            label2.TabIndex = 35;
            label2.Text = "SKU:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 137);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(122, 25);
            label3.TabIndex = 36;
            label3.Text = "Console Type:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(4, 53);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(169, 25);
            label4.TabIndex = 37;
            label4.Text = "Motherboard Serial:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 178);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(86, 25);
            label5.TabIndex = 38;
            label5.Text = "Board ID:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(4, 220);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(55, 25);
            label6.TabIndex = 39;
            label6.Text = "MAC:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(4, 262);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(94, 25);
            label7.TabIndex = 40;
            label7.Text = "WiFi MAC:";
            // 
            // Log
            // 
            Log.Dock = DockStyle.Bottom;
            Log.Location = new Point(0, 750);
            Log.Margin = new Padding(4, 3, 4, 3);
            Log.Name = "Log";
            Log.ReadOnly = true;
            Log.Size = new Size(1654, 450);
            Log.TabIndex = 20;
            Log.TabStop = false;
            Log.Text = "";
            // 
            // pS5osFlagsView1
            // 
            pS5osFlagsView1.Dock = DockStyle.Left;
            pS5osFlagsView1.Location = new Point(0, 429);
            pS5osFlagsView1.Margin = new Padding(4, 3, 4, 3);
            pS5osFlagsView1.Name = "pS5osFlagsView1";
            pS5osFlagsView1.Size = new Size(672, 321);
            pS5osFlagsView1.TabIndex = 21;
            // 
            // pS5osFlagsView2
            // 
            pS5osFlagsView2.Dock = DockStyle.Right;
            pS5osFlagsView2.Location = new Point(951, 429);
            pS5osFlagsView2.Margin = new Padding(4, 3, 4, 3);
            pS5osFlagsView2.Name = "pS5osFlagsView2";
            pS5osFlagsView2.Size = new Size(703, 321);
            pS5osFlagsView2.TabIndex = 22;
            // 
            // PS5NorView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pS5osFlagsView2);
            Controls.Add(pS5osFlagsView1);
            Controls.Add(Log);
            Controls.Add(PanelInfo);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "PS5NorView";
            Size = new Size(1654, 1200);
            Load += PS5NorView_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            PanelInfo.ResumeLayout(false);
            PanelInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox fileLocationBox;
        private Button ButtonBrowse;
        private Panel panel1;
        private Panel PanelInfo;
        private Label lFrimwareVersion;
        private Label label10;
        private Button ButtonSave;
        private Label label8;
        private ComboBox ConsoleTypeList;
        private ComboBox SkuList;
        private RegExTextBox WifiMacEdit;
        private RegExTextBox MacEdit;
        private RegExTextBox BoardIdEdit;
        private RegExTextBox MotherboardSerialEdit;
        private RegExTextBox SerialNumberEdit;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label lMd5Sum;
        private Label lFileSize;
        private Label lSerialNumber;
        private Label lWifiMac;
        private Label lMac;
        private Label lBoardId;
        private Label lConsoleType;
        private Label lMbSerial;
        private Label lSku;
        private Controls.ReadOnlyRichTextBox Log;
        private PS5OSFlagsView pS5osFlagsView1;
        private PS5OSFlagsView pS5osFlagsView2;
    }
}
