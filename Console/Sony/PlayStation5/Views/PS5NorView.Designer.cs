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
            IduList = new ComboBox();
            lFrimwareVersion = new Label();
            ButtonSave = new Button();
            ConsoleTypeList = new ComboBox();
            SkuList = new ComboBox();
            WifiMacEdit = new RegExTextBox();
            MacEdit = new RegExTextBox();
            BoardIdEdit = new RegExTextBox();
            MotherboardSerialEdit = new RegExTextBox();
            SerialNumberEdit = new RegExTextBox();
            lIduMode = new Label();
            lMd5Sum = new Label();
            lFileSize = new Label();
            lSerialNumber = new Label();
            lWifiMac = new Label();
            lMac = new Label();
            lBoardId = new Label();
            lConsoleType = new Label();
            lMbSerial = new Label();
            lSku = new Label();
            label9 = new Label();
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
            panel1.SuspendLayout();
            PanelInfo.SuspendLayout();
            SuspendLayout();
            // 
            // fileLocationBox
            // 
            fileLocationBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            fileLocationBox.Location = new Point(3, 3);
            fileLocationBox.Margin = new Padding(3, 2, 3, 2);
            fileLocationBox.Name = "fileLocationBox";
            fileLocationBox.ReadOnly = true;
            fileLocationBox.Size = new Size(805, 23);
            fileLocationBox.TabIndex = 3;
            // 
            // ButtonBrowse
            // 
            ButtonBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonBrowse.Location = new Point(812, 2);
            ButtonBrowse.Margin = new Padding(3, 2, 3, 2);
            ButtonBrowse.Name = "ButtonBrowse";
            ButtonBrowse.Size = new Size(82, 22);
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
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(897, 26);
            panel1.TabIndex = 4;
            // 
            // PanelInfo
            // 
            PanelInfo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PanelInfo.Controls.Add(IduList);
            PanelInfo.Controls.Add(lFrimwareVersion);
            PanelInfo.Controls.Add(ButtonSave);
            PanelInfo.Controls.Add(ConsoleTypeList);
            PanelInfo.Controls.Add(SkuList);
            PanelInfo.Controls.Add(WifiMacEdit);
            PanelInfo.Controls.Add(MacEdit);
            PanelInfo.Controls.Add(BoardIdEdit);
            PanelInfo.Controls.Add(MotherboardSerialEdit);
            PanelInfo.Controls.Add(SerialNumberEdit);
            PanelInfo.Controls.Add(lIduMode);
            PanelInfo.Controls.Add(lMd5Sum);
            PanelInfo.Controls.Add(lFileSize);
            PanelInfo.Controls.Add(lSerialNumber);
            PanelInfo.Controls.Add(lWifiMac);
            PanelInfo.Controls.Add(lMac);
            PanelInfo.Controls.Add(lBoardId);
            PanelInfo.Controls.Add(lConsoleType);
            PanelInfo.Controls.Add(lMbSerial);
            PanelInfo.Controls.Add(lSku);
            PanelInfo.Controls.Add(label9);
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
            PanelInfo.Location = new Point(0, 26);
            PanelInfo.Margin = new Padding(3, 2, 3, 2);
            PanelInfo.Name = "PanelInfo";
            PanelInfo.Size = new Size(897, 257);
            PanelInfo.TabIndex = 5;
            // 
            // IduList
            // 
            IduList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            IduList.DropDownStyle = ComboBoxStyle.DropDownList;
            IduList.FormattingEnabled = true;
            IduList.Location = new Point(652, 179);
            IduList.Margin = new Padding(3, 2, 3, 2);
            IduList.Name = "IduList";
            IduList.Size = new Size(243, 23);
            IduList.TabIndex = 52;
            // 
            // lFrimwareVersion
            // 
            lFrimwareVersion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lFrimwareVersion.AutoSize = true;
            lFrimwareVersion.Location = new Point(652, 208);
            lFrimwareVersion.Name = "lFrimwareVersion";
            lFrimwareVersion.Size = new Size(16, 15);
            lFrimwareVersion.TabIndex = 51;
            lFrimwareVersion.Text = "...";
            // 
            // ButtonSave
            // 
            ButtonSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonSave.Enabled = false;
            ButtonSave.Location = new Point(812, 205);
            ButtonSave.Margin = new Padding(3, 2, 3, 2);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(82, 22);
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
            ConsoleTypeList.Location = new Point(652, 80);
            ConsoleTypeList.Margin = new Padding(3, 2, 3, 2);
            ConsoleTypeList.Name = "ConsoleTypeList";
            ConsoleTypeList.Size = new Size(243, 23);
            ConsoleTypeList.TabIndex = 47;
            // 
            // SkuList
            // 
            SkuList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SkuList.DropDownStyle = ComboBoxStyle.DropDownList;
            SkuList.FormattingEnabled = true;
            SkuList.Location = new Point(652, 54);
            SkuList.Margin = new Padding(3, 2, 3, 2);
            SkuList.Name = "SkuList";
            SkuList.Size = new Size(243, 23);
            SkuList.TabIndex = 46;
            // 
            // WifiMacEdit
            // 
            WifiMacEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            WifiMacEdit.CharacterCasing = CharacterCasing.Upper;
            WifiMacEdit.Location = new Point(652, 154);
            WifiMacEdit.Margin = new Padding(3, 2, 3, 2);
            WifiMacEdit.MinLength = -1;
            WifiMacEdit.Name = "WifiMacEdit";
            WifiMacEdit.OriginalValue = null;
            WifiMacEdit.RegEx = "[a-fA-F0-9]+";
            WifiMacEdit.Size = new Size(243, 23);
            WifiMacEdit.TabIndex = 45;
            // 
            // MacEdit
            // 
            MacEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MacEdit.CharacterCasing = CharacterCasing.Upper;
            MacEdit.Location = new Point(652, 130);
            MacEdit.Margin = new Padding(3, 2, 3, 2);
            MacEdit.MaxLength = 12;
            MacEdit.MinLength = 12;
            MacEdit.Name = "MacEdit";
            MacEdit.OriginalValue = null;
            MacEdit.PlaceholderText = "Modify MAC";
            MacEdit.RegEx = "^[a-fA-F0-9]+$";
            MacEdit.Size = new Size(243, 23);
            MacEdit.TabIndex = 44;
            // 
            // BoardIdEdit
            // 
            BoardIdEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BoardIdEdit.CharacterCasing = CharacterCasing.Upper;
            BoardIdEdit.Location = new Point(652, 105);
            BoardIdEdit.Margin = new Padding(3, 2, 3, 2);
            BoardIdEdit.MaxLength = 13;
            BoardIdEdit.MinLength = -1;
            BoardIdEdit.Name = "BoardIdEdit";
            BoardIdEdit.OriginalValue = null;
            BoardIdEdit.PlaceholderText = "Modify board ID up to 13 digits";
            BoardIdEdit.RegEx = "^[0-9]+$";
            BoardIdEdit.Size = new Size(243, 23);
            BoardIdEdit.TabIndex = 43;
            // 
            // MotherboardSerialEdit
            // 
            MotherboardSerialEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MotherboardSerialEdit.CharacterCasing = CharacterCasing.Upper;
            MotherboardSerialEdit.Location = new Point(652, 29);
            MotherboardSerialEdit.Margin = new Padding(3, 2, 3, 2);
            MotherboardSerialEdit.MaxLength = 16;
            MotherboardSerialEdit.MinLength = -1;
            MotherboardSerialEdit.Name = "MotherboardSerialEdit";
            MotherboardSerialEdit.OriginalValue = null;
            MotherboardSerialEdit.PlaceholderText = "Modify MB serial up to 16 chars";
            MotherboardSerialEdit.RegEx = "^[a-fA-F0-9]+$";
            MotherboardSerialEdit.Size = new Size(243, 23);
            MotherboardSerialEdit.TabIndex = 42;
            // 
            // SerialNumberEdit
            // 
            SerialNumberEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SerialNumberEdit.CharacterCasing = CharacterCasing.Upper;
            SerialNumberEdit.Location = new Point(652, 4);
            SerialNumberEdit.Margin = new Padding(3, 2, 3, 2);
            SerialNumberEdit.MaxLength = 16;
            SerialNumberEdit.MinLength = -1;
            SerialNumberEdit.Name = "SerialNumberEdit";
            SerialNumberEdit.OriginalValue = null;
            SerialNumberEdit.PlaceholderText = "Modify serial up to 16 chars";
            SerialNumberEdit.RegEx = "";
            SerialNumberEdit.Size = new Size(243, 23);
            SerialNumberEdit.TabIndex = 41;
            // 
            // lIduMode
            // 
            lIduMode.AutoSize = true;
            lIduMode.Location = new Point(131, 182);
            lIduMode.Name = "lIduMode";
            lIduMode.Size = new Size(13, 15);
            lIduMode.TabIndex = 63;
            lIduMode.Tag = "True";
            lIduMode.Text = "..";
            // 
            // lMd5Sum
            // 
            lMd5Sum.AutoSize = true;
            lMd5Sum.Location = new Point(131, 232);
            lMd5Sum.Name = "lMd5Sum";
            lMd5Sum.Size = new Size(13, 15);
            lMd5Sum.TabIndex = 62;
            lMd5Sum.Tag = "True";
            lMd5Sum.Text = "..";
            // 
            // lFileSize
            // 
            lFileSize.AutoSize = true;
            lFileSize.Location = new Point(131, 208);
            lFileSize.Name = "lFileSize";
            lFileSize.Size = new Size(13, 15);
            lFileSize.TabIndex = 61;
            lFileSize.Tag = "True";
            lFileSize.Text = "..";
            // 
            // lSerialNumber
            // 
            lSerialNumber.AutoSize = true;
            lSerialNumber.Location = new Point(131, 7);
            lSerialNumber.Name = "lSerialNumber";
            lSerialNumber.Size = new Size(13, 15);
            lSerialNumber.TabIndex = 60;
            lSerialNumber.Tag = "True";
            lSerialNumber.Text = "..";
            // 
            // lWifiMac
            // 
            lWifiMac.AutoSize = true;
            lWifiMac.Location = new Point(131, 157);
            lWifiMac.Name = "lWifiMac";
            lWifiMac.Size = new Size(13, 15);
            lWifiMac.TabIndex = 54;
            lWifiMac.Tag = "True";
            lWifiMac.Text = "..";
            // 
            // lMac
            // 
            lMac.AutoSize = true;
            lMac.Location = new Point(131, 132);
            lMac.Name = "lMac";
            lMac.Size = new Size(13, 15);
            lMac.TabIndex = 55;
            lMac.Tag = "True";
            lMac.Text = "..";
            // 
            // lBoardId
            // 
            lBoardId.AutoSize = true;
            lBoardId.Location = new Point(131, 107);
            lBoardId.Name = "lBoardId";
            lBoardId.Size = new Size(13, 15);
            lBoardId.TabIndex = 56;
            lBoardId.Tag = "True";
            lBoardId.Text = "..";
            // 
            // lConsoleType
            // 
            lConsoleType.AutoSize = true;
            lConsoleType.Location = new Point(131, 82);
            lConsoleType.Name = "lConsoleType";
            lConsoleType.Size = new Size(13, 15);
            lConsoleType.TabIndex = 57;
            lConsoleType.Tag = "True";
            lConsoleType.Text = "..";
            // 
            // lMbSerial
            // 
            lMbSerial.AutoSize = true;
            lMbSerial.Location = new Point(131, 32);
            lMbSerial.Name = "lMbSerial";
            lMbSerial.Size = new Size(13, 15);
            lMbSerial.TabIndex = 59;
            lMbSerial.Tag = "True";
            lMbSerial.Text = "..";
            // 
            // lSku
            // 
            lSku.AutoSize = true;
            lSku.Location = new Point(131, 56);
            lSku.Name = "lSku";
            lSku.Size = new Size(13, 15);
            lSku.TabIndex = 58;
            lSku.Tag = "True";
            lSku.Text = "..";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(3, 182);
            label9.Name = "label9";
            label9.Size = new Size(63, 15);
            label9.TabIndex = 53;
            label9.Text = "IDU Mode:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(3, 232);
            label10.Name = "label10";
            label10.Size = new Size(94, 15);
            label10.TabIndex = 50;
            label10.Text = "MD5 Checksum:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(3, 208);
            label8.Name = "label8";
            label8.Size = new Size(51, 15);
            label8.TabIndex = 49;
            label8.Text = "File Size:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 7);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 34;
            label1.Text = "Serial Number:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 56);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 35;
            label2.Text = "SKU:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 82);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 36;
            label3.Text = "Console Type:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 32);
            label4.Name = "label4";
            label4.Size = new Size(111, 15);
            label4.TabIndex = 37;
            label4.Text = "Motherboard Serial:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 107);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 38;
            label5.Text = "Board ID:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 132);
            label6.Name = "label6";
            label6.Size = new Size(37, 15);
            label6.TabIndex = 39;
            label6.Text = "MAC:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 157);
            label7.Name = "label7";
            label7.Size = new Size(63, 15);
            label7.TabIndex = 40;
            label7.Text = "WiFi MAC:";
            // 
            // Log
            // 
            Log.Dock = DockStyle.Fill;
            Log.Location = new Point(0, 283);
            Log.Margin = new Padding(3, 2, 3, 2);
            Log.Name = "Log";
            Log.ReadOnly = true;
            Log.Size = new Size(897, 205);
            Log.TabIndex = 20;
            Log.TabStop = false;
            Log.Text = "";
            // 
            // PS5NorView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Log);
            Controls.Add(PanelInfo);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Margin = new Padding(3, 2, 3, 2);
            Name = "PS5NorView";
            Size = new Size(897, 488);
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
        private Label label9;
        private ComboBox IduList;
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
        private Label lIduMode;
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
    }
}
