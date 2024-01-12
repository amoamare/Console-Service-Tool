using ConsoleServiceTool.Console.Sony.PlayStation5;
using ConsoleServiceTool.Console.Sony.PlayStation5.Views;
using ConsoleServiceTool.Console.Sony.Shared;
using ConsoleServiceTool.Utils;

namespace ConsoleServiceTool
{
    internal partial class Form1 : Form
    {
        private Nor? NorFile { get; set; } = default;
        private FileInfo? FileInfo { get; set; } = default;
        private readonly PS5UartView _ps5UartView = new();

        internal Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = $"{Text} - {ProductVersion}";
            LoadViews();
            Log.AppendLine("Click \"Browse\" locate and open your PlayStation NOR binary.");
            ResetLabels();
            LoadPs5Skus();
            LoadConsoleTypes();
            LoadIduList();
        }

        private void LoadViews()
        {
            TabPagePS5Uart.Controls.Add(_ps5UartView);
        }

        private void ResetLabels()
        {
            foreach (var i in PanelInfo.Controls)
            {
                if (i is not Label label) continue;
                label.Text = string.Empty;
            }
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
        }

        private void SaveNewNorFile()
        {
            if (NorFile == default || FileInfo == default) return; //nothing to do.
            var fileName = Path.GetFileNameWithoutExtension(FileInfo.FullName);
            fileName += @$"_patched_{DateTime.Now:yyyy_MM_d__HH_mm_ss}.bin";
            var newFilePath = $"{Path.GetDirectoryName(FileInfo.FullName)}\\{fileName}";
            if (string.IsNullOrEmpty(newFilePath)) return;
            using var stream = new FileStream(newFilePath, FileMode.CreateNew, FileAccess.Write);
            stream.Write(NorFile.ToArray());
            Log.AppendLine($"New NOR written to: {newFilePath}");
        }
    }
}