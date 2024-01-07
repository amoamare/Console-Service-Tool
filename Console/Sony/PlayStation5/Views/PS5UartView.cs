using ConsoleServiceTool.Communication;
using ConsoleServiceTool.Console.Sony.Shared;
using ConsoleServiceTool.Console.Sony.Shared.Models;
using ConsoleServiceTool.Controls;
using ConsoleServiceTool.Utils;
using Microsoft.VisualStudio.Threading;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Xml.Linq;

namespace ConsoleServiceTool.Console.Sony.PlayStation5.Views
{
    internal partial class PS5UartView : UserControl
    {
        private readonly string FileNameCache = @"cache.json";
        private readonly string StrAuto = @"Auto";
        private PS5ErrorCodeList? errorCodeList;
        private CancellationTokenSource? cancellationTokenSource;

        internal PS5UartView()
        {
            InitializeComponent();
        }


        public override DockStyle Dock => DockStyle.Fill;

        private async void PS5UartView_Load(object sender, EventArgs e)
        {
            LoadOperationTypes();
            LoadPorts();
            await GetErrorCodesListAsync();
            if (errorCodeList == default)
            {
                Log.AppendLine("[-] No Errors List Loaded, Close Application and Try Again!");
            }
            else
            {
                Log.AppendLine("[+] Please connect your Playstation 5 to UART do not power up the console.", ReadOnlyRichTextBox.ColorInformation);
            }
        }
        private void ComboBoxOperationType_SelectedValueChanged(object? sender, EventArgs e)
        {
            if (ComboBoxOperationType.SelectedValue is not OperationType type) return;
            PanelRawCommand.Visible = type == OperationType.RunRawCommand | type == OperationType.CodeLookUp;
            LabelRawCommand.Text = type == OperationType.RunRawCommand ? "Raw Command" : type == OperationType.CodeLookUp ? "Code Lookup" : "Raw Command";
            TextBoxRawCommand.Enabled = type != OperationType.RunRawCommand && type == OperationType.CodeLookUp;
        }

        private void ComboBoxDevices_DropDown(object sender, EventArgs e)
        {
            LoadPorts();
        }


        #region Data Source Information

        private void LoadPorts()
        {
            ComboBoxDevices.DataSource = SerialPort.SelectSerial();
        }


        private void LoadOperationTypes()
        {
            ComboBoxOperationType.EnumForComboBox<OperationType>();
            ComboBoxOperationType.DisplayMember = "Description";
            ComboBoxOperationType.ValueMember = "Value";
        }

        #endregion

        #region Error Codes List From Server

        private async Task GetErrorCodesListAsync()
        {
            Log.AppendLine("[+] Loading Errors List", ReadOnlyRichTextBox.ColorInformation);
            errorCodeList = default;
            try
            {
                Log.Append("Attempting to load from server...");
                errorCodeList = await GetErrorCodesGitHubAsync();
                if (errorCodeList != default)
                {
                    Log.Okay();
                    //Store errorCode list as a chache.
                    await CacheErrorListLocalAsync();
                }
                else
                {
                    Log.Fail();
                }
            }
            catch
            {
                Log.Fail();
                //todo: Error Handling
                //Attempt to get error codes from server failed. 
                //Lets get errorCodes from a cached local file. 
                errorCodeList = await GetErrorCodesCacheAsync();
            }
            if (errorCodeList != default && errorCodeList.PlayStation5 != null && errorCodeList.PlayStation5.ErrorCodes.Any())
            {
                Log.AppendLine($"[+] Loaded {errorCodeList.PlayStation5.ErrorCodes.Count} Errors Succesfully.", ReadOnlyRichTextBox.ColorSuccess);
            }
            else
            {
                Log.AppendLine("[-] Failed to load Errors List.", ReadOnlyRichTextBox.ColorError);
            }
        }

        /// <summary>
        /// Get List of Error Codes for the PS5 from Git hub server.
        /// </summary>
        /// <returns>Error Code List</returns>
        private static async Task<PS5ErrorCodeList?> GetErrorCodesGitHubAsync()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://raw.githubusercontent.com/");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (compatible; PS5CodeReader/2.1; +https://github.com/amoamare)");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync("amoamare/PS5CodeReader/master/ErrorCodes.json");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PS5ErrorCodeList>();
        }

        /// <summary>
        /// Gets a list of Error Codes from Cached File on System
        /// </summary>
        /// <returns></returns>
        private async Task<PS5ErrorCodeList?> GetErrorCodesCacheAsync()
        {
            Log.Append("Loading Errors List From Cached File...");
            if (!File.Exists(FileNameCache))
            {
                Log.Fail();
                Log.AppendText("No Cached File Saved!");
                return default;
            }
            using var stream = File.OpenRead(FileNameCache);
            var cached = await JsonSerializer.DeserializeAsync<PS5ErrorCodeList>(stream);
            if (cached == default || cached.PlayStation5 != default && !cached.PlayStation5.ErrorCodes.Any())
            {
                Log.Fail();
                return default;
            }
            Log.Okay();
            return cached;
        }


        /// <summary>
        /// Save error codes to a cached file on system
        /// </summary>
        /// <param name="fileName">cached.json</param>
        /// <returns></returns>
        private async Task SaveCacheFileAsync(string fileName)
        {
            using var stream = File.Create(fileName);
            var options = new JsonSerializerOptions { WriteIndented = true };
            await JsonSerializer.SerializeAsync(stream, errorCodeList, options: options);
            await stream.DisposeAsync();
            return; // only need to store it as a cahce first time creating it
        }


        /// <summary>
        /// Cachce error list on local disk
        /// </summary>
        /// <returns></returns>
        private async Task CacheErrorListLocalAsync()
        {
            if (errorCodeList == default)
            {
                //Can't save what we don't have right?
                return;
            }
            if (!File.Exists(FileNameCache) && errorCodeList != default)
            {
                Log.Append("Creating new errors list cache file...");
                await SaveCacheFileAsync(FileNameCache);
                Log.Okay();
                return; // only need to store it as a cahce first time creating it
            }
            else
            {
                Log.Append("Comparing cached version from server version...");
                //Lets open and serialize the revision to compare if we need to update the cached file. 
                using var stream = File.OpenRead(FileNameCache);
                var cached = await JsonSerializer.DeserializeAsync<PS5ErrorCodeList>(stream);
                if (cached == default || errorCodeList == default)
                {
                    Log.Fail();
                    //todo: Update error handling
                    return;
                }
                Log.Okay();
                if (cached.Revision < errorCodeList.Revision)
                {
                    Log.AppendLine($"Cached Version: {cached.Revision}.");
                    Log.AppendLine($"Server Version: {errorCodeList.Revision}.");
                    Log.Append("Updating cached version with server...");
                    //Our downloaded error codes have updated. Lets update the cached version.
                    await stream.DisposeAsync();
                    try
                    {
                        File.Delete(FileNameCache);
                    }
                    catch
                    {
                        try
                        {
                            File.Move(FileNameCache, $"{FileNameCache}.old");
                        }
                        catch
                        {
                            //todo: update error handling if we can not delete or move the file.
                            Log.Fail();
                            return;
                        }
                    }
                    if (!File.Exists(FileNameCache))
                    {
                        //safe to create new file.
                        await SaveCacheFileAsync(FileNameCache);
                        Log.Okay();
                    }
                }
            }
        }

        #endregion

        private bool InterfaceState
        {
            set
            {
                ButtonRunOperation.Text = value ? @"Run Operation" : @"Cancel";
                ButtonRunOperation.Tag = !value;
                ComboBoxDevices.Enabled = value;
                ComboBoxOperationType.Enabled = value;


                TextBoxRawCommand.Enabled = !value;

                if (ComboBoxOperationType.SelectedValue is not OperationType type) return;
            }
        }


        private async Task<Device?> AutoDetectDeviceAsync()
        {
            Device? device = ComboBoxDevices.SelectedItem as Device;
            if (device == default || errorCodeList == null) return default;
            var autoDetect = device.Port.StartsWith(StrAuto, StringComparison.InvariantCultureIgnoreCase);
            if (!autoDetect) return device;
            var devices = ComboBoxDevices.Items.OfType<Device>().ToList();
            devices.Remove(device); // remove the auto detect device. 
            if (devices.Count == 1) return devices.FirstOrDefault(); //if only 1 device is detected we can just skipp detecting it.
            cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(1));
            foreach (var autoDevice in devices)
            {
                Log.AppendLine($"[*] Auto Detecting Playstation 5 on {autoDevice}", ReadOnlyRichTextBox.ColorInformation);
                Log.AppendLine("\t- Disconnect power cord from PS5\r\n\t- Wait 5 seconds.\r\n\t- Connect Power to PS5 due not power on!", ReadOnlyRichTextBox.ColorError);
                using var serial = new SerialPort(autoDevice.Port);
                Log.Append($"Opening Device on {autoDevice.FriendlyName}...");
                serial.Open();
                Log.Okay();
                Log.AppendLine("[*] Listening for Playstation 5.", ReadOnlyRichTextBox.ColorInformation);
                List<string> Lines = new();
                do
                {
                    try
                    {
                        var line = await serial.ReadLineAsync(cancellationTokenSource.Token);
                        Lines.Add(line);
                    }
                    catch (OperationCanceledException)
                    {
                        cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
                        await serial.SendBreakAsync(cancellationToken: cancellationTokenSource.Token);
                        var line = await serial.ReadLineAsync(cancellationTokenSource.Token);
                        Lines.Add(line);
                    }
                } while (serial.BytesToRead != 0);

                var flag = Lines.Any(x => x.StartsWith(@"$$ [MANU] UART CMD READY:36") || x.StartsWith(@"NG E0000003:4D") || x.StartsWith("OK 00000000:3A"));
                if (flag)
                {
                    Log.AppendLine($@"[+] Detected a Playstation 5 on {autoDevice.FriendlyName}", ReadOnlyRichTextBox.ColorSuccess);
                    ComboBoxDevices.SelectedItem = autoDevice;
                    return autoDevice;
                }
            }
            return default;
        }

        private async void ButtonRunOperations_Click(object sender, EventArgs e)
        {
            if (ComboBoxOperationType.SelectedValue is not OperationType type) return;
            try
            {
                if (ButtonRunOperation.Tag is not null && ButtonRunOperation.Tag is bool cancel && cancel
                    && cancellationTokenSource != null)
                {
                    cancellationTokenSource.Cancel(false);
                    return;
                }

                Log.Clear();
                InterfaceState = false;
                await RunOperationsAsync(type);
            }
            catch (OperationCanceledException)
            {
                Log.AppendLine("[!] Operation Cancelled");
            }
            catch (Exception ex)
            {
                //todo: add error handling
                Debug.WriteLine(ex);
            }
            finally
            {
                InterfaceState = true;
            }
        }

        private async Task RunOperationsAsync(OperationType type)
        {
            Log.AppendErrorLine($"[*] Operation: Run {type.ToDescription()}");
            switch (type)
            {
                default: return;
                case OperationType.ReadErrorCodes:
                    await ReadCodesAsync();
                    break;
                case OperationType.ClearErrorCodes:
                    await ClearLogsAsync();
                    break;
                case OperationType.MonitorMode:
                    await RunMonitorModeAsync();
                    break;
                case OperationType.RunCommandList:
                    await RunCommmandListAsync();
                    break;
                case OperationType.RunRawCommand:
                    await RunRawCommandAsync();
                    break;
                case OperationType.CodeLookUp:
                    break;
            }
        }

        #region Run Operation Types

        /// <summary>
        /// Read all errors until no more errors to read. 
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private async Task ReadCodesAsync(int count = 0x255)
        {
            var device = await AutoDetectDeviceAsync();
            if (device == default)
            {
                Log.AppendLine("[-] No Playstation 5 Detected!", ReadOnlyRichTextBox.ColorError);
                return;
            }
            cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(1000));
            using var serial = new SerialPort(device.Port);
            serial.Open();
            List<(string LogCount, string LogLine)> Lines = new();
            var isNoError = false;
            for (byte i = 0; i <= count; i++)
            {
                if (isNoError)
                {
                    break;
                }
                var command = $"errlog {i:X2}";
                var checksum = SerialPort.CalculateChecksum(command);

                /*

                var d = new UartErrLogRequest(0);
                var rrr = d;
                var r = new UartErrLogResponse(Encoding.ASCII.GetBytes("OK 00000000 C0020303 1673D178 150000E5 00010000 217B 001E 32B2"));
                if (r.IsError) return;
                var rr = r;
                */

                await serial.WriteLineAsync(command);
                do
                {
                    var line = await serial.ReadLineAsync(cancellationTokenSource.Token);
                    if (!string.Equals($"{command}:{checksum:X2}", line, StringComparison.InvariantCultureIgnoreCase))
                    {
                        //ignore the echo'd command capture everything else. 
                        //todo: parse error codes here, break on NG or No Error Codes instead.                         
                        Lines.Add((LogCount: $"{i:X2}", LogLine: line));
                        //tmp soluti          on. 
                        var split = line.Split(' ');
                        if (!split.Any()) continue;
                        switch (split[0])
                        {
                            case "NG":
                                //isNoError = true;
                                break;
                            case "OK":
                                var errorCode = split[2];
                                var noErrors = "FFFFFFFF";
                                isNoError = string.Equals(errorCode, noErrors, StringComparison.InvariantCultureIgnoreCase);
                                break;
                        }
                    }
                } while (serial.BytesToRead != 0 && !isNoError);
            }


            foreach (var (LogCount, LogLine) in Lines)
            {
                var split = LogLine.Split(' ');
                if (!split.Any()) continue;
                switch (split[0])
                {
                    case "NG":
                        Log.AppendLine("Failed to read data");
                        break;
                    case "OK":
                        var errorCode = split[2];
                        var errorLookup = errorCodeList?.PlayStation5?.ErrorCodes.FirstOrDefault(x => x.ID == errorCode);
                        if (errorLookup == default)
                        {
                            Log.AppendLine($"{LogCount}: {errorCode}: Not found in list. Report Findings.");
                        }
                        else
                        {
                            Log.AppendLine($"{LogCount}: {errorLookup.ID}: {errorLookup.Message}");
                        }
                        break;
                }
            }
            Log.AppendLine("End of errors.");
        }

        /// <summary>
        /// Clears Error Logs
        /// </summary>
        /// <returns></returns>
        private async Task ClearLogsAsync()
        {
            var device = await AutoDetectDeviceAsync();
            if (device == default)
            {
                Log.AppendLine("[-] No Playstation 5 Detected!", ReadOnlyRichTextBox.ColorError);
                return;
            }
            cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            using var serial = new SerialPort(device.Port);
            serial.Open();
            Log.Append("[+]\tClearing Logs...", ReadOnlyRichTextBox.ColorInformation);
            var command = "errlog clear";
            var checksum = SerialPort.CalculateChecksum(command);
            await serial.WriteLineAsync("errlog clear", cancellationTokenSource.Token);
            string? response = default;
            do
            {
                var line = await serial.ReadLineAsync(cancellationTokenSource.Token);
                if (!string.Equals($"{command}:{checksum:X2}", line, StringComparison.InvariantCultureIgnoreCase))
                {
                    //ignore the echo'd command capture everything else. 
                    response = line;
                }
            } while (serial.BytesToRead != 0);
            var split = response?.Split(' ');
            if (split == default || split.Any())
            {
                Log.Okay();
                return;
            }
            switch (split[0])
            {
                case "NG":
                    Log.Fail();
                    break;
                case "OK":
                    Log.Okay();
                    break;
            }
        }


        /// <summary>
        /// Run in monitor mode. This will listen to anything the console might be saying. 
        /// </summary>
        /// <returns></returns>
        private async Task RunMonitorModeAsync()
        {
            var device = await AutoDetectDeviceAsync();
            if (device == default)
            {
                Log.AppendLine("[-] No Playstation 5 Detected!", ReadOnlyRichTextBox.ColorError);
                return;
            }
            cancellationTokenSource = new CancellationTokenSource();
            using var serial = new SerialPort(device.Port);
            serial.Open();
            do
            {
                var line = await serial.ReadLineAsync(cancellationTokenSource.Token);
                Log.AppendLine(line);

            } while (!cancellationTokenSource.IsCancellationRequested);
        }

        /// <summary>
        /// Run a list of commands saved in a text file. 
        /// </summary>
        /// <returns></returns>
        private async Task RunCommmandListAsync()
        {
            var device = await AutoDetectDeviceAsync();
            if (device == default)
            {
                Log.AppendLine("[-] No Playstation 5 Detected!", ReadOnlyRichTextBox.ColorError);
                return;
            }
            using var ofd = new OpenFileDialog();
            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            ofd.RestoreDirectory = true;
            ofd.Title = @"Select Command List";
            ofd.DefaultExt = @"txt";
            ofd.Filter = @"txt files (*.txt)|*.txt";
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() != DialogResult.OK) return;
            FileInfo file = new(ofd.FileName);
            using var stream = new StreamReader(file.FullName);
            string? command = default;
            cancellationTokenSource = new CancellationTokenSource();
            using var serial = new SerialPort(device.Port);
            serial.Open();
            do
            {
                command = await stream.ReadLineAsync();
                if (string.IsNullOrEmpty(command)) continue;
                await serial.WriteLineAsync(command, cancellationTokenSource.Token);
                do
                {
                    var response = await serial.ReadLineAsync(cancellationTokenSource.Token);
                    Log.AppendLine(response);

                } while (serial.BytesToRead != 0);
            } while (!stream.EndOfStream);
        }

        private readonly AsyncAutoResetEvent AutoResetEventRawCommand = new(false);
        /// <summary>
        /// Run raw command from user. Keeps port open.
        /// </summary>
        /// <returns></returns>
        private async Task RunRawCommandAsync()
        {
            var device = await AutoDetectDeviceAsync();
            if (device == default)
            {
                Log.AppendLine("[-] No Playstation 5 Detected!", ReadOnlyRichTextBox.ColorError);
                return;
            }
            using var serial = new SerialPort(device.Port);
            serial.Open();
            do
            {
                cancellationTokenSource = new CancellationTokenSource();
                TextBoxRawCommand.Enabled = true;
                await AutoResetEventRawCommand.WaitAsync(cancellationTokenSource.Token);
                var command = TextBoxRawCommand.Text.Trim();
                TextBoxRawCommand.Clear();
                TextBoxRawCommand.Enabled = false;
                Log.Focus();
                cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
                await serial.WriteLineAsync(command);
                do
                {
                    var line = await serial.ReadLineAsync(cancellationTokenSource.Token);
                    Log.AppendLine(line);
                } while (serial.BytesToRead != 0);
            } while (!cancellationTokenSource.IsCancellationRequested);
        }
        #endregion

        private void TextBoxRawCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!TextBoxRawCommand.Text.Any()) return; // dont send empty commands
            if (e.KeyChar == (char)Keys.Enter)
            {
                AutoResetEventRawCommand.Set();
            }
        }

    }
}
