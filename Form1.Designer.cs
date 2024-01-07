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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            TabControlPS5Uart = new TabControl();
            tabPage3 = new TabPage();
            Log = new Controls.ReadOnlyRichTextBox();
            PanelGro = new Panel();
            lFrimwareVersion = new Label();
            label10 = new Label();
            ButtonSave = new Button();
            label8 = new Label();
            ConsoleTypeList = new ComboBox();
            SkuList = new ComboBox();
            WifiMacEdit = new RegExTextBox();
            MacEdit = new RegExTextBox();
            BoardIdEdit = new RegExTextBox();
            MotherboardSerialEdit = new RegExTextBox();
            PanelInfo = new Panel();
            lMd5Sum = new Label();
            lFileSize = new Label();
            lSerialNumber = new Label();
            lWifiMac = new Label();
            lMac = new Label();
            lBoardId = new Label();
            lConsoleType = new Label();
            lMbSerial = new Label();
            lSku = new Label();
            SerialNumberEdit = new RegExTextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            fileLocationBox = new TextBox();
            ButtonBrowse = new Button();
            TabPagePS5Uart = new TabPage();
            tabPage2 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            TabControlPS5Uart.SuspendLayout();
            tabPage3.SuspendLayout();
            PanelGro.SuspendLayout();
            PanelInfo.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1048, 723);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(TabControlPS5Uart);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1040, 690);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Playstation 5";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // TabControlPS5Uart
            // 
            TabControlPS5Uart.Controls.Add(tabPage3);
            TabControlPS5Uart.Controls.Add(TabPagePS5Uart);
            TabControlPS5Uart.Dock = DockStyle.Fill;
            TabControlPS5Uart.Location = new Point(3, 3);
            TabControlPS5Uart.Name = "TabControlPS5Uart";
            TabControlPS5Uart.SelectedIndex = 0;
            TabControlPS5Uart.Size = new Size(1034, 684);
            TabControlPS5Uart.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(Log);
            tabPage3.Controls.Add(PanelGro);
            tabPage3.Controls.Add(fileLocationBox);
            tabPage3.Controls.Add(ButtonBrowse);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1026, 651);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "NOR Tools";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // Log
            // 
            Log.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Log.Location = new Point(6, 362);
            Log.Name = "Log";
            Log.ReadOnly = true;
            Log.Size = new Size(1014, 286);
            Log.TabIndex = 19;
            Log.TabStop = false;
            Log.Text = "";
            // 
            // PanelGro
            // 
            PanelGro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PanelGro.Controls.Add(lFrimwareVersion);
            PanelGro.Controls.Add(label10);
            PanelGro.Controls.Add(ButtonSave);
            PanelGro.Controls.Add(label8);
            PanelGro.Controls.Add(ConsoleTypeList);
            PanelGro.Controls.Add(SkuList);
            PanelGro.Controls.Add(WifiMacEdit);
            PanelGro.Controls.Add(MacEdit);
            PanelGro.Controls.Add(BoardIdEdit);
            PanelGro.Controls.Add(MotherboardSerialEdit);
            PanelGro.Controls.Add(PanelInfo);
            PanelGro.Controls.Add(SerialNumberEdit);
            PanelGro.Controls.Add(label1);
            PanelGro.Controls.Add(label2);
            PanelGro.Controls.Add(label3);
            PanelGro.Controls.Add(label4);
            PanelGro.Controls.Add(label5);
            PanelGro.Controls.Add(label6);
            PanelGro.Controls.Add(label7);
            PanelGro.Location = new Point(6, 40);
            PanelGro.Name = "PanelGro";
            PanelGro.Size = new Size(1014, 316);
            PanelGro.TabIndex = 18;
            // 
            // lFrimwareVersion
            // 
            lFrimwareVersion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lFrimwareVersion.AutoSize = true;
            lFrimwareVersion.Location = new Point(734, 237);
            lFrimwareVersion.Name = "lFrimwareVersion";
            lFrimwareVersion.Size = new Size(18, 20);
            lFrimwareVersion.TabIndex = 31;
            lFrimwareVersion.Text = "...";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 276);
            label10.Name = "label10";
            label10.Size = new Size(114, 20);
            label10.TabIndex = 30;
            label10.Text = "MD5 Checksum:";
            // 
            // ButtonSave
            // 
            ButtonSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ButtonSave.Enabled = false;
            ButtonSave.Location = new Point(917, 284);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(94, 29);
            ButtonSave.TabIndex = 26;
            ButtonSave.Text = "Save";
            ButtonSave.UseVisualStyleBackColor = true;
            ButtonSave.Click += ButtonSave_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 243);
            label8.Name = "label8";
            label8.Size = new Size(66, 20);
            label8.TabIndex = 27;
            label8.Text = "File Size:";
            // 
            // ConsoleTypeList
            // 
            ConsoleTypeList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ConsoleTypeList.DropDownStyle = ComboBoxStyle.DropDownList;
            ConsoleTypeList.FormattingEnabled = true;
            ConsoleTypeList.Location = new Point(734, 107);
            ConsoleTypeList.Name = "ConsoleTypeList";
            ConsoleTypeList.Size = new Size(277, 28);
            ConsoleTypeList.TabIndex = 25;
            // 
            // SkuList
            // 
            SkuList.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SkuList.DropDownStyle = ComboBoxStyle.DropDownList;
            SkuList.FormattingEnabled = true;
            SkuList.Location = new Point(734, 73);
            SkuList.Name = "SkuList";
            SkuList.Size = new Size(277, 28);
            SkuList.TabIndex = 24;
            // 
            // WifiMacEdit
            // 
            WifiMacEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            WifiMacEdit.CharacterCasing = CharacterCasing.Upper;
            WifiMacEdit.Location = new Point(734, 207);
            WifiMacEdit.MinLength = -1;
            WifiMacEdit.Name = "WifiMacEdit";
            WifiMacEdit.OriginalValue = null;
            WifiMacEdit.RegEx = "[a-fA-F0-9]+";
            WifiMacEdit.Size = new Size(277, 27);
            WifiMacEdit.TabIndex = 23;
            // 
            // MacEdit
            // 
            MacEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MacEdit.CharacterCasing = CharacterCasing.Upper;
            MacEdit.Location = new Point(734, 174);
            MacEdit.MaxLength = 12;
            MacEdit.MinLength = 12;
            MacEdit.Name = "MacEdit";
            MacEdit.OriginalValue = null;
            MacEdit.PlaceholderText = "Modify MAC";
            MacEdit.RegEx = "^[a-fA-F0-9]+$";
            MacEdit.Size = new Size(277, 27);
            MacEdit.TabIndex = 22;
            // 
            // BoardIdEdit
            // 
            BoardIdEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BoardIdEdit.CharacterCasing = CharacterCasing.Upper;
            BoardIdEdit.Location = new Point(734, 141);
            BoardIdEdit.MaxLength = 13;
            BoardIdEdit.MinLength = -1;
            BoardIdEdit.Name = "BoardIdEdit";
            BoardIdEdit.OriginalValue = null;
            BoardIdEdit.PlaceholderText = "Modify board ID up to 13 digits";
            BoardIdEdit.RegEx = "^[0-9]+$";
            BoardIdEdit.Size = new Size(277, 27);
            BoardIdEdit.TabIndex = 21;
            // 
            // MotherboardSerialEdit
            // 
            MotherboardSerialEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MotherboardSerialEdit.CharacterCasing = CharacterCasing.Upper;
            MotherboardSerialEdit.Location = new Point(734, 40);
            MotherboardSerialEdit.MaxLength = 16;
            MotherboardSerialEdit.MinLength = -1;
            MotherboardSerialEdit.Name = "MotherboardSerialEdit";
            MotherboardSerialEdit.OriginalValue = null;
            MotherboardSerialEdit.PlaceholderText = "Modify MB serial up to 16 chars";
            MotherboardSerialEdit.RegEx = "^[a-fA-F0-9]+$";
            MotherboardSerialEdit.Size = new Size(277, 27);
            MotherboardSerialEdit.TabIndex = 18;
            // 
            // PanelInfo
            // 
            PanelInfo.Controls.Add(lMd5Sum);
            PanelInfo.Controls.Add(lFileSize);
            PanelInfo.Controls.Add(lSerialNumber);
            PanelInfo.Controls.Add(lWifiMac);
            PanelInfo.Controls.Add(lMac);
            PanelInfo.Controls.Add(lBoardId);
            PanelInfo.Controls.Add(lConsoleType);
            PanelInfo.Controls.Add(lMbSerial);
            PanelInfo.Controls.Add(lSku);
            PanelInfo.Location = new Point(170, 0);
            PanelInfo.Name = "PanelInfo";
            PanelInfo.Size = new Size(425, 316);
            PanelInfo.TabIndex = 16;
            // 
            // lMd5Sum
            // 
            lMd5Sum.AutoSize = true;
            lMd5Sum.Location = new Point(3, 276);
            lMd5Sum.Name = "lMd5Sum";
            lMd5Sum.Size = new Size(15, 20);
            lMd5Sum.TabIndex = 29;
            lMd5Sum.Text = "..";
            // 
            // lFileSize
            // 
            lFileSize.AutoSize = true;
            lFileSize.Location = new Point(3, 243);
            lFileSize.Name = "lFileSize";
            lFileSize.Size = new Size(15, 20);
            lFileSize.TabIndex = 28;
            lFileSize.Text = "..";
            // 
            // lSerialNumber
            // 
            lSerialNumber.AutoSize = true;
            lSerialNumber.Location = new Point(3, 10);
            lSerialNumber.Name = "lSerialNumber";
            lSerialNumber.Size = new Size(15, 20);
            lSerialNumber.TabIndex = 15;
            lSerialNumber.Text = "..";
            // 
            // lWifiMac
            // 
            lWifiMac.AutoSize = true;
            lWifiMac.Location = new Point(3, 210);
            lWifiMac.Name = "lWifiMac";
            lWifiMac.Size = new Size(15, 20);
            lWifiMac.TabIndex = 9;
            lWifiMac.Text = "..";
            // 
            // lMac
            // 
            lMac.AutoSize = true;
            lMac.Location = new Point(3, 177);
            lMac.Name = "lMac";
            lMac.Size = new Size(15, 20);
            lMac.TabIndex = 10;
            lMac.Text = "..";
            // 
            // lBoardId
            // 
            lBoardId.AutoSize = true;
            lBoardId.Location = new Point(3, 144);
            lBoardId.Name = "lBoardId";
            lBoardId.Size = new Size(15, 20);
            lBoardId.TabIndex = 11;
            lBoardId.Text = "..";
            // 
            // lConsoleType
            // 
            lConsoleType.AutoSize = true;
            lConsoleType.Location = new Point(3, 110);
            lConsoleType.Name = "lConsoleType";
            lConsoleType.Size = new Size(15, 20);
            lConsoleType.TabIndex = 12;
            lConsoleType.Text = "..";
            // 
            // lMbSerial
            // 
            lMbSerial.AutoSize = true;
            lMbSerial.Location = new Point(3, 43);
            lMbSerial.Name = "lMbSerial";
            lMbSerial.Size = new Size(15, 20);
            lMbSerial.TabIndex = 14;
            lMbSerial.Text = "..";
            // 
            // lSku
            // 
            lSku.AutoSize = true;
            lSku.Location = new Point(3, 76);
            lSku.Name = "lSku";
            lSku.Size = new Size(15, 20);
            lSku.TabIndex = 13;
            lSku.Text = "..";
            // 
            // SerialNumberEdit
            // 
            SerialNumberEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SerialNumberEdit.CharacterCasing = CharacterCasing.Upper;
            SerialNumberEdit.Location = new Point(734, 7);
            SerialNumberEdit.MaxLength = 16;
            SerialNumberEdit.MinLength = -1;
            SerialNumberEdit.Name = "SerialNumberEdit";
            SerialNumberEdit.OriginalValue = null;
            SerialNumberEdit.PlaceholderText = "Modify serial up to 16 chars";
            SerialNumberEdit.RegEx = "";
            SerialNumberEdit.Size = new Size(277, 27);
            SerialNumberEdit.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 10);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 2;
            label1.Text = "Serial Number:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 76);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 3;
            label2.Text = "SKU:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 110);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 4;
            label3.Text = "Console Type:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 43);
            label4.Name = "label4";
            label4.Size = new Size(141, 20);
            label4.TabIndex = 5;
            label4.Text = "Motherboard Serial:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 144);
            label5.Name = "label5";
            label5.Size = new Size(71, 20);
            label5.TabIndex = 6;
            label5.Text = "Board ID:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 177);
            label6.Name = "label6";
            label6.Size = new Size(44, 20);
            label6.TabIndex = 7;
            label6.Text = "MAC:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 210);
            label7.Name = "label7";
            label7.Size = new Size(77, 20);
            label7.TabIndex = 8;
            label7.Text = "WiFi MAC:";
            // 
            // fileLocationBox
            // 
            fileLocationBox.Location = new Point(6, 7);
            fileLocationBox.Name = "fileLocationBox";
            fileLocationBox.ReadOnly = true;
            fileLocationBox.Size = new Size(914, 27);
            fileLocationBox.TabIndex = 1;
            // 
            // ButtonBrowse
            // 
            ButtonBrowse.Location = new Point(926, 6);
            ButtonBrowse.Name = "ButtonBrowse";
            ButtonBrowse.Size = new Size(94, 29);
            ButtonBrowse.TabIndex = 0;
            ButtonBrowse.Text = "Browse";
            ButtonBrowse.UseVisualStyleBackColor = true;
            ButtonBrowse.Click += ButtonBrowse_Click;
            // 
            // TabPagePS5Uart
            // 
            TabPagePS5Uart.Location = new Point(4, 29);
            TabPagePS5Uart.Name = "TabPagePS5Uart";
            TabPagePS5Uart.Padding = new Padding(3);
            TabPagePS5Uart.Size = new Size(1026, 651);
            TabPagePS5Uart.TabIndex = 1;
            TabPagePS5Uart.Text = "UART Tools";
            TabPagePS5Uart.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1040, 690);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Playstation 4";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1048, 723);
            Controls.Add(tabControl1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Console Service Tool (C.S.T)";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            TabControlPS5Uart.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            PanelGro.ResumeLayout(false);
            PanelGro.PerformLayout();
            PanelInfo.ResumeLayout(false);
            PanelInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabControl TabControlPS5Uart;
        private TabPage tabPage3;
        private TextBox fileLocationBox;
        private Button ButtonBrowse;
        private TabPage TabPagePS5Uart;
        private TabPage tabPage2;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lSerialNumber;
        private Label lMbSerial;
        private Label lSku;
        private Label lConsoleType;
        private Label lBoardId;
        private Label lMac;
        private Label lWifiMac;
        private Label label7;
        private Label label6;
        private Label label5;
        private RegExTextBox SerialNumberEdit;
        private Panel PanelGro;
        private Panel PanelInfo;
        private RegExTextBox BoardIdEdit;
        private RegExTextBox MotherboardSerialEdit;
        private RegExTextBox WifiMacEdit;
        private RegExTextBox MacEdit;
        private ComboBox ConsoleTypeList;
        private ComboBox SkuList;
        private Button ButtonSave;
        private Label label8;
        private Label lFileSize;
        private Label label10;
        private Label lMd5Sum;
        private Controls.ReadOnlyRichTextBox Log;
        private Label lFrimwareVersion;
    }
}