using ConsoleServiceTool.Console.Sony.Shared;
using ConsoleServiceTool.Utils;

namespace ConsoleServiceTool.Console.Sony.PlayStation5.Views
{
    internal partial class PS5NorView : UserControl
    {
        //todo: Move NOR information to its own view
        private Nor? NorFile { get; set; } = default;
        private FileInfo? FileInfo { get; set; } = default;

        public PS5NorView()
        {
            InitializeComponent();
        }

        private void PS5NorView_Load(object sender, EventArgs e)
        {
            Log.AppendLine("Click \"Browse\" locate and open your PlayStation NOR binary.");
            ResetLabels();
            LoadPs5Skus();
            LoadConsoleTypes();
            LoadIduList();
        }

        private void ResetLabels()
        {
            PanelInfo.Controls.OfType<Label>().ToList().ForEach(label =>
            {
                if (label.Tag is string str && bool.TryParse(str, out var reset) && reset)
                    label.ResetText();
            });
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            Log.Clear();
            NorFile = default;
            FileInfo = default;
            using var ofd = new OpenFileDialog();
            ofd.Title = "Open NOR BIN File";
            ofd.Filter = "PlayStation BIN Files(*.bin)|*.bin";
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                Log.AppendLine("User canceled loading NOR file.");
                return;
            }
            Log.AppendLine("Analyzing PlayStation NOR file.");
            FileInfo = new(ofd.FileName);
            long length = FileInfo.Length;
            if (length != Nor.ExpectedSize)
            {
                var errorMessage = $"Warning: File size mismatch {Environment.NewLine}" +
                    $"Expected: {Nor.ExpectedSize.FormattedByteSize()}{Environment.NewLine}" +
                    $"Resulted: {length.FormattedByteSize()}";
                Log.AppendWarningLine($"[!] {errorMessage}");
                if (MessageBox.Show($"{errorMessage}" +
                    $"{Environment.NewLine}Continue trying to parse NOR file?",
                    "Invalid NOR File Size", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    Log.AppendLine("User aborted trying to parse NOR file.");
                    return;
                }
            }
            try
            {
                NorFile = new Nor(FileInfo);
            }
            catch (EndOfStreamException)
            {
                Log.AppendErrorLine("[X] Failed to parse NOR file.");
                return;
            }
            catch
            {
                Log.AppendErrorLine("[X] Failed to parse NOR file.");
                return;
            }
            SanityCheck();

            lFileSize.Text = length.FormattedByteSize();
            fileLocationBox.Text = FileInfo.FullName;
            lMd5Sum.Text = FileInfo.CalculateMd5Sum();

            ShowNorValues();
        }

        private void SanityCheck()
        {
            if (NorFile == null) return;
            Log.Append($"NOR Header: ");

            if (NorFile.Header.WarnHeaderCorrupted)
                Log.AppendWarningLine("✗");
            else Log.ApppendOkLine("✓");

            Log.Append($"MBR1 Header: ");
            if (NorFile.Mbr1.WarnHeaderCorrupted)
                Log.AppendWarningLine("✗");
            else Log.ApppendOkLine("✓");


            Log.Append($"MBR2 Header: ");
            if (NorFile.Mbr2.WarnHeaderCorrupted)
                Log.AppendWarningLine("✗");
            else Log.ApppendOkLine("✓");


            Log.Append($"EmcIplA Header: ");
            if (NorFile.EmcIplA.Header.WarnHeaderCorrupted)
                Log.AppendWarningLine("✗");
            else Log.ApppendOkLine("✓");


            Log.Append($"EmcIplB Header: ");
            if (NorFile.EmcIplB.Header.WarnHeaderCorrupted)
                Log.AppendWarningLine("✗");
            else Log.ApppendOkLine("✓");


            Log.Append($"UsbPdcA Header: ");
            if (NorFile.UsbPdcA.Header.WarnHeaderCorrupted)
                Log.AppendWarningLine("✗");
            else Log.ApppendOkLine("✓");

            Log.Append($"UsbPdcB Header: ");
            if (NorFile.UsbPdcB.Header.WarnHeaderCorrupted)
                Log.AppendWarningLine("✗");
            else Log.ApppendOkLine("✓");

            ButtonSave.Enabled = true;

        }

        private void ShowNorValues()
        {
            if (NorFile == default) return;
            lSerialNumber.Text = SerialNumberEdit.Text = NorFile.Nvs.Serial;
            lMbSerial.Text = MotherboardSerialEdit.Text = NorFile.Nvs.MotherBoardSerialNumber;
            lSku.Text = NorFile.Nvs.Sku;

            lConsoleType.Text = NorFile.Nvs.ConsoleType.ToString();
            ConsoleTypeList.SelectedValue = NorFile.Nvs.ConsoleType;

            lBoardId.Text = BoardIdEdit.Text = NorFile.Nvs.BoardId;
            lMac.Text = MacEdit.Text = NorFile.Nvs.MacAddress;
            lWifiMac.Text = WifiMacEdit.Text = $"{NorFile.Nvs.WifiMacAddress} \\ {NorFile.Nvs.WifiMacAddress1} \\ {NorFile.Nvs.WifiMacAddress2}";
            lFrimwareVersion.Text = NorFile.Nvs.FirmwareVersion.ToString("X2");
            lIduMode.Text = NorFile.Nvs.Idu.ToDescription();
            IduList.SelectedValue = NorFile.Nvs.Idu;
        }

        private void LoadPs5Skus()
        {
            SkuList.EnumForComboBox<Skus>();
            SkuList.DisplayMember = "Description";
            SkuList.ValueMember = "Value";
        }

        private void LoadConsoleTypes()
        {
            ConsoleTypeList.EnumForComboBox<ConsoleType>();
            ConsoleTypeList.DisplayMember = "Description";
            ConsoleTypeList.ValueMember = "Value";
        }

        private void LoadIduList()
        {
            IduList.EnumForComboBox<InterfaceDemonstrationUnit>();
            IduList.DisplayMember = "Description";
            IduList.ValueMember = "Value";
        }


        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                ButtonSave.Enabled = false;
                //var wifiSplit = WifiMacEdit.Text.ToUpperInvariant().TrimAllWithInplaceCharArray().Split('\\');
                //if (wifiSplit.Length != 3)
                //{
                //    //70662A2ED856 
                //    MessageBox.Show(@$"Must contain 3 valid MAC Address seperated by \{Environment.NewLine}" +
                //                    @$"MAC Address must contain 12 valid hex chars 0-9A-F.{Environment.NewLine}" +
                //                    $@"Example: 70662A2ED856\70662A2ED856\70662A2ED856", "Invalid MAC Address Format", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    return;
                //}

                UpdateChangedNorValues();
                SaveNewNorFile();
            }
            finally
            {
                ButtonSave.Enabled = true;
            }
        }

        private void UpdateChangedNorValues()
        {
            if (NorFile == default) return; //nothing to do.

            if (SerialNumberEdit.Modified)
                NorFile.Nvs.Serial = SerialNumberEdit.Text;
            if (MotherboardSerialEdit.Modified)
                NorFile.Nvs.MotherBoardSerialNumber = MotherboardSerialEdit.Text;
            if (ConsoleTypeList.SelectedValue is ConsoleType type && NorFile.Nvs.ConsoleType != type)
                NorFile.Nvs.ConsoleType = type;
            if (BoardIdEdit.Modified)
                NorFile.Nvs.BoardId = BoardIdEdit.Text;
            if (MacEdit.Modified)
                NorFile.Nvs.MacAddress = MacEdit.Text;
            if (IduList.SelectedValue is InterfaceDemonstrationUnit idu && NorFile.Nvs.Idu != idu)
                NorFile.Nvs.Idu = idu;


            
        }

        private void SaveNewNorFile()
        {
            if (NorFile == default || FileInfo == default) return; //nothing to do.
            var fileName = Path.GetFileNameWithoutExtension(FileInfo.FullName);
            fileName += @$"_patched_{DateTime.Now:yyyy_MM_dd__HH_mm_ss}.bin";
            var newFilePath = $"{Path.GetDirectoryName(FileInfo.FullName)}\\{fileName}";
            if (string.IsNullOrEmpty(newFilePath)) return;
            using var stream = new FileStream(newFilePath, FileMode.CreateNew, FileAccess.Write);
            stream.Write(NorFile.ToArray());
            Log.AppendLine($"New NOR written to: {newFilePath}");
        }
    }
}
