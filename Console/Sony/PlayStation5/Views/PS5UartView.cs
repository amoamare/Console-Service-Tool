using ConsoleServiceTool.Communication;
using ConsoleServiceTool.Console.Sony.Shared;
using ConsoleServiceTool.Console.Sony.Shared.Models;
using ConsoleServiceTool.Controls;
using ConsoleServiceTool.Models;
using ConsoleServiceTool.Utils;
using Microsoft.VisualStudio.Threading;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace ConsoleServiceTool.Console.Sony.PlayStation5.Views
{
    internal partial class PS5UartView : UserControl
    {
        private const string OkStr = @"OK";
        private const string NgStr = @"NG";
#if DEBUG
        private readonly string FileNameCache = @"../../../Resources/ErrorCodes.json";
#else
        private readonly string FileNameCache = @"cache.json";
#endif
        private readonly string StrAuto = @"Auto";
        private readonly string PlayStation5NotFound = @"[-] No Playstation 5 Detected!";
        private DirectoryInfo LogsDirectory = new ($"{AppDomain.CurrentDomain.BaseDirectory}logs");
        private PS5ErrorCodeList? errorCodeList;
        private CancellationTokenSource? cancellationTokenSource;
        private readonly Uri OnlineResourcesUrl = new ("https://raw.githubusercontent.com/amoamare/Console-Service-Tool/master/Resources/");
        private readonly Uri OnlineTsbUrl = new ("https://consoleservicetool.com/tsb/sony/playstation5/");

        private readonly InfoViewer infoViewer = new ();

        #region Form Initialize, Load & Populate Data

        public PS5UartView()
        {
            InitializeComponent();
            DoubleBuffered = true;
            infoViewer.Dock = DockStyle.Fill;
            infoViewer.Visible = false;            
            PanelInfo.Controls.Add(infoViewer);
            infoViewer.SendToBack();
            Log.LinkClicked += Log_LinkClicked;
        }

        private void Log_LinkClicked(object? sender, LinkClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.LinkText)) { return; }
            //verify we are opening a real web url and not a file path.
            if (!Uri.TryCreate(e.LinkText, UriKind.Absolute, out var uriResult)
                || uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps)
            {
                return;
            }
            infoViewer.GotoPage(uriResult);
            infoViewer.Visible = true;
            infoViewer.BringToFront();
        }

        private void PS5UartView_Load(object sender, EventArgs e)
        {
            _= LoadAsync();
            Log.Focus();
        }

        private async Task LoadAsync()
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
                Log.AppendLine("[+] Please connect your Playstation 5 to UART do not power up the console.", WarningStatus.Information);
                PrintUartRefrences();   
            }
        }

        private void PrintUartRefrences()
        {           
            Log.Append("Quick UART Test Point References: ");
            Log.InsertFriendlyNameHyperLink("Click Here", "https://consoleservicetool.com/tsb/sony/playstation5/uart/pinouts");
            Log.Append("Gettinging Started: ");
            Log.InsertFriendlyNameHyperLink("Click Here", "https://consoleservicetool.com/tsb/sony/playstation5/uart/gettingstarted");
        }

        private void ComboBoxOperationType_SelectedValueChanged(object? sender, EventArgs e)
        {
            if (ComboBoxOperationType.SelectedValue is not OperationType type) return;
            PanelRawCommand.Visible = type == OperationType.RunRawCommand | type == OperationType.CodeLookUp;
            LabelRawCommand.Text = type == OperationType.RunRawCommand ? "Raw Command" : type == OperationType.CodeLookUp ? "Code Lookup" : "Raw Command";
            TextBoxRawCommand.Enabled = type != OperationType.RunRawCommand && type == OperationType.CodeLookUp;
            ComboBoxDevices.Enabled = ButtonRunOperation.Enabled = type != OperationType.CodeLookUp;
        }

        private void ComboBoxDevices_DropDown(object sender, EventArgs e)
        {
            LoadPorts();
        }

        #endregion

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
            Log.AppendLine("[+] Loading Errors List", WarningStatus.Information);
            errorCodeList = default;
            try
            {
                Log.Append("Attempting to load from server...");
#if DEBUG
                errorCodeList = default;
                //for testing purposes we want to use our local copy.
#else
    
                errorCodeList = await GetErrorCodesGitHubAsync();
#endif
                if (errorCodeList != default)
                {
                    Log.Okay();
                    //Store errorCode list as a chache.
                    await CacheErrorListLocalAsync();
                }
                else
                {
                    Log.Fail();
                    errorCodeList = await GetErrorCodesCacheAsync();
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
            if (errorCodeList != default && errorCodeList.PlayStation5 != null && errorCodeList.PlayStation5.ErrorCodes.Count != 0)
            {
                Log.AppendLine($"[+] Loaded {errorCodeList.PlayStation5.ErrorCodes.Count} Errors Succesfully.", WarningStatus.Success);
            }
            else
            {
                Log.AppendLine("[-] Failed to load Errors List.", WarningStatus.Error);
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
            var response = await client.GetAsync("amoamare/ConsoleServiceTool/master/Resources/ErrorCodes.json");
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
            if (cached == default || cached.PlayStation5 != default && cached.PlayStation5.ErrorCodes.Count == 0)
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
            var jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
            var options = jsonSerializerOptions;
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

        /// <summary>
        /// Set Certain Interfaces state to enabled or disabled.
        /// </summary>
        private bool InterfaceState
        {
            set
            {
                ButtonRunOperation.Text = value ? @"Run Operation" : @"Cancel";
                ButtonRunOperation.Tag = !value;
                ComboBoxDevices.Enabled = value;
                ComboBoxOperationType.Enabled = value;
                TextBoxRawCommand.Enabled = !value;
                if (ComboBoxOperationType.SelectedValue is not OperationType) return;
            }
        }

        /// <summary>
        /// Auto detect PlayStation 5 on any given serial port.
        /// </summary>
        /// <remarks>
        /// The only way to detect if its a PlayStation 5 console. Is by listening to the port or sending a Break command and listening for the response. 
        /// Usual response from the PS5 is $$ [MANU] UART CMD READY:36, NG E0000003:4D, or OK 00000000:3A. If we get one of the three responses it's
        /// safe to assume we found a PlayStation 5 on that port.
        /// </remarks>
        /// <returns>Device List</returns>
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
                Log.AppendLine($"[*] Auto Detecting Playstation 5 on {autoDevice}", WarningStatus.Information);
                Log.AppendLine("\t- Disconnect power cord from PS5\r\n\t- Wait 5 seconds.\r\n\t- Connect Power to PS5 due not power on!", WarningStatus.Error);
                using var serial = new SerialPort(autoDevice.Port);
                Log.Append($"Opening Device on {autoDevice.FriendlyName}...");
                serial.Open();
                Log.Okay();
                Log.AppendLine("[*] Listening for Playstation 5.", WarningStatus.Information);
                List<string> Lines = [];
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
                    Log.AppendLine($@"[+] Detected a Playstation 5 on {autoDevice.FriendlyName}", WarningStatus.Success);
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

        /// <summary>
        /// Run selected operation
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>

        private async Task RunOperationsAsync(OperationType type)
        {
            var logFile = CreateLogFile();
            using var writer = logFile.OpenWrite();
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
            }
            Log.AppendErrorLine($"[*] End Operation: {type.ToDescription()}");
            await writer.WriteAsync(Encoding.UTF8.GetBytes(Log.Text));
        }

        #region Operations

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
                Log.AppendLine(PlayStation5NotFound, WarningStatus.Error);
                return;
            }
            cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            using var serial = new SerialPort(device.Port);
            serial.Open();
            List<(string Slot, string LogLine)> Lines = [];
            var noErrors = "FFFFFFFF";
            var isNoError = false;
            for (byte i = 0; i <= count; i++)
            {
                if (isNoError)
                {
                    break;
                }
                var command = $"errlog {i:X2}";
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
                    if (!SerialPort.IsEchoCommand(command, line))
                    {
                        //ignore the echo'd command capture everything else. 
                        //todo: parse error codes here, break on NG or No Error Codes instead.                         
                        Lines.Add((Slot: $"{i:X2}", LogLine: line));
                        var split = line.Split(' ');
                        if (split.Length == 0) continue;
                        switch (split[0])
                        {
                            case NgStr:
                                //isNoError = true;
                                //NG for this command keep going just in case though.
                                continue;
                            case OkStr:
                                try
                                {
                                    var errorCode = split[2];
                                    isNoError = string.Equals(errorCode, noErrors, StringComparison.InvariantCultureIgnoreCase);
                                }catch(Exception ex)
                                {
                                    Debug.WriteLine(ex);
                                }
                                break;
                        }
                    }
                } while (serial.BytesToRead != 0 && !isNoError);
            }
            if (Lines.Count == 0)
            {
                return;
            }
            PrintLineDetails(Lines);
        }

        private void PrintLineDetails(List<(string slot, string logLine)> lines)
        {
            Log.AppendLine("[Slot #]\t[Date Time]\t\t[Error Code]\t[Priority]\t\t[Error Message]");
            var firstErrorTimeStamp = 0L;
            var dateTimeNow = DateTime.Now;
            var logForeColor = Log.ForeColor;
            foreach (var (slot, logLine) in lines)
            {
                var split = logLine.Split(' ');
                if (split.Length == 0) continue;                
                switch (split[0])
                {
                    case NgStr:
                        Log.AppendLine("Failed to read data");
                        break;
                    case OkStr:
                        var errorCode = split[2];
                        var timeStamp = split[3].ToLong();
                        if (firstErrorTimeStamp == 0)
                        {
                            firstErrorTimeStamp = timeStamp;
                        }
                        timeStamp = -1 * (timeStamp - firstErrorTimeStamp);
                        var pastStamp = dateTimeNow.AddSeconds(-timeStamp);
                   
                        var errorLookup = errorCodeList?.PlayStation5?.ErrorCodes.FirstOrDefault(x => x.ID == errorCode);
                        if (errorLookup == default)
                        {
                            Log.Append($"{slot}\t{pastStamp}\t{errorCode}\t");
                            Log.Append($"{Priority.High}\t\t", Priority.High);
                            Log.AppendLine($"Not found in list. Report Findings.");
                            Log.InsertFriendlyNameHyperLink("Click Here To Report", "{{report}}");
                        }
                        else
                        {                          
                            Log.Append($"{slot}\t{pastStamp}\t{errorLookup.ID}\t");
                            Log.Append($"{errorLookup.Priority}\t\t", errorLookup.Priority);
                            Log.AppendLine($"{errorLookup.Message}");

                            if (errorLookup.Priority == Priority.Severe && HighlightSevereLines.Checked)
                            {
                                Log.HighlightLastLine(Priority.Severe);
                            }
                        }
                        if (ShowErrorLine.Checked)
                        {
                            Log.AppendLine($"\t |-({logLine})");
                        }
                        Log.Append("\t");
                        Log.InsertFriendlyNameHyperLink("Click for TSB Information", $"{OnlineTsbUrl}{errorCode}");
                        Log.AppendLine(string.Empty);
                        break;
                }
            }
            Log.AppendLine("End of errors.");
            Log.AppendLine("Low: Nothing to concern about first.", Priority.Low);
            Log.AppendLine("Medium: Everything appears fine.", Priority.Medium);
            Log.AppendLine("High: Console may boot but freeze or other issues.", Priority.High);
            Log.AppendLine("Severe: Prevents console from booting.", Priority.Severe);
            Log.AppendLine("Ignore Priority Status For Now. They are being updated!");
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
                Log.AppendLine(PlayStation5NotFound, WarningStatus.Error);
                return;
            }
            cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            using var serial = new SerialPort(device.Port);
            serial.Open();
            Log.Append("[+]\tClearing Logs...", WarningStatus.Information);
            var command = "errlog clear";
            await serial.WriteLineAsync(command, cancellationTokenSource.Token);
            string? response = default;
            do
            {
                var line = await serial.ReadLineAsync(cancellationTokenSource.Token);
                if (!SerialPort.IsEchoCommand(command, line))
                {
                    //ignore the echo'd command capture everything else. 
                    response = line;
                }
            } while (serial.BytesToRead != 0);
            var split = response?.Split(' ');
            if (split == default || split.Length != 0)
            {
                Log.Okay();
                return;
            }
            switch (split[0])
            {
                case NgStr:
                    Log.Fail();
                    break;
                case OkStr:
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
                Log.AppendLine(PlayStation5NotFound, WarningStatus.Error);
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
                Log.AppendLine(PlayStation5NotFound, WarningStatus.Error);
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
                Log.AppendLine(PlayStation5NotFound, WarningStatus.Error);
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
        
        private async Task RunCodeLookupAsync()
        {
            Log.Clear();
            var errorCode = TextBoxRawCommand.Text.ToUpperInvariant().Trim();
            TextBoxRawCommand.Clear();
            if (string.IsNullOrEmpty(errorCode)) return;
            var errors = errorCodeList?.PlayStation5?.ErrorCodes?.Where(x => x.ID.StartsWith(errorCode, StringComparison.InvariantCultureIgnoreCase)).ToList();
            if (errors == default || errors.Count == 0)
            {
                Log.AppendLine($"Error Code: {errorCode} - Not found in list.{Environment.NewLine}" +
                    $"If you'd like you can report your findings and we will update our list with more information.", Priority.High);
                Log.InsertFriendlyNameHyperLink("Click for TSB Information", $"https://consoleservicetool.com/tsb/codenotfound?errorId={errorCode}");
                return;
            }
            await Task.Run(() =>
            {
                foreach (var code in errors)
                {
                    Log.AppendLine($"Found the following information.{Environment.NewLine}" +
                        $"Source: Internal Database{Environment.NewLine}" +
                        $"Error Code: {code.ID}");
                    Log.Append("Priroity Level: ");
                    Log.AppendLine(code.Priority.ToString(), code.Priority);
                    Log.AppendLine($"Message: {code.Message}");
                    Log.InsertFriendlyNameHyperLink("Click for TSB Information", $"{OnlineTsbUrl}{code.ID}");
                    Log.AppendLine(string.Empty);
                }
            });
            
        }

        #endregion

        private async void TextBoxRawCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TextBoxRawCommand.Text.Length == 0) return; // dont send empty commands
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (ComboBoxOperationType.SelectedValue is OperationType type && type == OperationType.CodeLookUp)
                {
                    await RunCodeLookupAsync();
                    return;
                }
                AutoResetEventRawCommand.Set();
            }
        }

        private FileInfo CreateLogFile()
        {
            CreateLogDirectory();
            CleanUpOldLogFiles();
            return CreateNewLogFile();
        }

        private void CleanUpOldLogFiles()
        {
            LogsDirectory.GetFiles()
                .Where(f => f.LastWriteTime < DateTime.Now.AddMonths(-3))
                .ToList()
                .ForEach(f => f.Delete());
        }

        private void CreateLogDirectory()
        {
            if (!LogsDirectory.Exists)
            {
                try
                {
                    LogsDirectory.Create();
                }
                catch(UnauthorizedAccessException)
                {
                    //hmm some reason we're in a directory with no permissiosn to write. Lets store in appdata\roaming\product_name instead. 
                    LogsDirectory = new($"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\{Application.ProductName}\\logs");
                    CreateLogDirectory();
                    return;
                }
            }
        }

        private FileInfo CreateNewLogFile()
        {
            var dateTime = DateTime.Now.ToString("yyyy_MM_dd__HH_mm_ss");
            return new FileInfo($"{LogsDirectory}\\cst_{dateTime}.txt");
        }
    }
}