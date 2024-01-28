using System.Runtime.InteropServices;
using System.Text;
using static Vanara.PInvoke.SetupAPI;
using static Vanara.PInvoke.AdvApi32;
using System.Security.AccessControl;
using Vanara.InteropServices;
using Vanara.PInvoke;
using Vanara.Extensions;
using ConsoleServiceTool.Console.Sony.Shared;
using ConsoleServiceTool.Utils;

namespace ConsoleServiceTool.Communication
{
    internal class SerialPort : System.IO.Ports.SerialPort
    {
        private readonly static int _buadRate = 115200;
        internal SerialPort(string portName)
        {
            PortName = portName;
            BaudRate = _buadRate;
        }

        private static IEnumerable<int> BaudRates => new[]
        {
            268435450,
            921600,
            460800,
            256000,
            230400,
            153600,
            128000,
            115200,
            57600,
            56000,
            38400,
            28800,
            19200,
            14400,
            9600,
            4800,
            2400,
            1200,
            600,
            300,
            110
        };

        internal new void Open()
        {
            base.Open();
            return;

            ///Playstation 5 only supports 115200;
            foreach (var b in BaudRates)
            {
                BaudRate = b;
                try
                {
                    base.Open();
                }
                catch (ArgumentOutOfRangeException ex) when (ex != null && ex.ParamName != null && ex.ParamName.ToLowerInvariant().Contains("baudrate"))
                {
                    var value = new string(ex.Message.Where(char.IsDigit).ToArray());
                    if (int.TryParse(value, out var i))
                    {
                        BaudRate = i;
                        try
                        {
                            base.Open();
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
                catch (IOException ex) when (ex.Message.ToLowerInvariant().Contains("the parameter is incorrect"))
                {
                    if (IsOpen)
                        Close();
                    continue;
                    break;
                    continue;
                }

                if (IsOpen)
                    break;
            }
        }

        internal static IEnumerable<Device> SelectSerial(bool isSorted = true, Func<Device, bool>? filter = null)
        {
            var guid = GetGuidFromClassName(@"Ports");
            var autoDevice = new Device(@"Auto", @"Detect Device Automatically (Auto)");
            var deviceList = new List<Device>();
            deviceList.AddRange(GetDeviceByGuid(guid, filter));
            if (isSorted)
            {
                deviceList = deviceList.OrderBy(x => x.Port.Length).ThenBy(x => x.Port).ToList();
            }
            deviceList.Insert(0, autoDevice);
            return deviceList;
        }

        private static IEnumerable<Device> GetDeviceByGuid(Guid guid, Func<Device, bool>? filter = null)
        {
            var hDevInfo = SetupDiGetClassDevs(guid, Flags: DIGCF.DIGCF_PRESENT);
            if (hDevInfo == IntPtr.Zero)
            {
                throw new Exception(@"Failed to get device information set for the Modem ports");
            }

            try
            {
                var devices = new List<Device>();
                SetupDiEnumDeviceInfo(hDevInfo).ToList()?.ForEach(hDevInfoData =>
                {
                    var name = GetDeviceName(hDevInfo, hDevInfoData);
                    if (string.IsNullOrEmpty(name)) return;
                    var description = GetDeviceDescription(hDevInfo, hDevInfoData);
                    var friendlyName = GetDeviceFriendlyName(hDevInfo, hDevInfoData);
                    var instancePath = GetDeviceInstanceId(hDevInfo, hDevInfoData);
                    devices.Add(new Device(name, friendlyName));

                });
                return devices;
            }
            finally
            {
                SetupDiDestroyDeviceInfoList(hDevInfo);
            }
        }


        internal static Guid GetGuidFromClassName(string name)
        {
            var guidArray = Array.Empty<Guid>();
            var flag = SetupDiClassGuidsFromName(name, guidArray, 0, out var requiredSize);
            if (!flag && requiredSize <= 0) return guidArray.FirstOrDefault();
            Array.Resize(ref guidArray, (int)requiredSize);
            if (guidArray.Length < 1) return guidArray.FirstOrDefault();
            SetupDiClassGuidsFromName(name, guidArray, (uint)guidArray.Length, out _);
            return guidArray.FirstOrDefault();
        }

        private static string? GetDeviceName(SafeHDEVINFO hDevInfo, SP_DEVINFO_DATA hDevInfoData)
        {
            const string name = @"PortName";
            var ptrRegistryKey = SetupDiOpenDevRegKey(hDevInfo, hDevInfoData, DICS_FLAG.DICS_FLAG_GLOBAL, 0u, DIREG.DIREG_DEV, RegistryRights.QueryValues);
            if (ptrRegistryKey.IsInvalid)
                return null;
            try
            {
                var size = 0u;
                RegQueryValueEx(ptrRegistryKey, name, nint.Zero, out _, nint.Zero, ref size);
                using var mem = new SafeHGlobalHandle(size);
                var flag = RegQueryValueEx(ptrRegistryKey, name, nint.Zero, out _, mem, ref size);
                return flag == Win32Error.ERROR_SUCCESS ? mem.ToString(-1, CharSet.Auto) : null;
            }
            catch
            {
                return null;
            }
            finally
            {
                RegCloseKey(ptrRegistryKey);
            }
        }

        private static string? GetDeviceDescription(SafeHDEVINFO hDevInfo, SP_DEVINFO_DATA hDevInfoData)
        {
            SetupDiGetDeviceRegistryProperty(hDevInfo, hDevInfoData, SPDRP.SPDRP_DEVICEDESC, out _, nint.Zero, 0u, out var size);
            using var mem = new SafeHGlobalHandle(size);
            var flag = SetupDiGetDeviceRegistryProperty(hDevInfo, hDevInfoData, SPDRP.SPDRP_DEVICEDESC, out _, mem, mem.Size, out _);
            return flag ? mem.ToString(-1, CharSet.Auto) : string.Empty;

        }

        private static string? GetDeviceFriendlyName(SafeHDEVINFO ptr, SP_DEVINFO_DATA ptrDevInfo)
        {
            SetupDiGetDeviceRegistryProperty(ptr, ptrDevInfo, SPDRP.SPDRP_FRIENDLYNAME, out _, nint.Zero, 0u, out var size);
            using var mem = new SafeHGlobalHandle(size);
            var flag = SetupDiGetDeviceRegistryProperty(ptr, ptrDevInfo, SPDRP.SPDRP_FRIENDLYNAME, out _, mem, mem.Size, out _);
            return flag ? mem.ToString(-1, CharSet.Auto) : string.Empty;
        }


        private static string GetDeviceInstanceId(SafeHDEVINFO ptr, SP_DEVINFO_DATA ptrDevInfo)
        {
            var sb = new StringBuilder();
            SetupDiGetDeviceInstanceId(ptr, ptrDevInfo, sb, 0u, out var size);
            sb = new StringBuilder((int)size);
            var flag = SetupDiGetDeviceInstanceId(ptr, ptrDevInfo, sb, size, out _);
            return flag ? sb.ToString() : string.Empty;
        }

        private static byte CalculateChecksum(string data)
        {
            var checksum = 0;
            checksum = Encoding.ASCII.GetBytes(data).Sum(x => x);
            return (byte)((checksum + 256) % 256);
        }

        internal static bool IsEchoCommand(string command, string refstring)
        {
            var checksum = CalculateChecksum(command);
            return string.Equals($"{command}:{checksum:X2}", refstring, StringComparison.InvariantCultureIgnoreCase);
        }

        internal new void Write(string command)
        {
            var checkSum = CalculateChecksum(command);
            var commandBytes = Encoding.ASCII.GetBytes($"{command}:{checkSum:X2}\r\n");
            Write(commandBytes, 0, commandBytes.Length);
        }

        internal Task WriteLineAsync(string command, CancellationToken cancellationToken = default)
        {
            var checkSum = CalculateChecksum(command);
            return Extensions.WriteLineAsync(this, $"{command}:{checkSum:X2}", cancellationToken); ;
        }


        internal void SendBreak(double timeout = 0.25)
        {
            if (!IsOpen) return;
            BreakState = true;
            Thread.Sleep(TimeSpan.FromMilliseconds(timeout));
            BreakState = false;
        }

        internal async Task SendBreakAsync(double timeout = 0.25, CancellationToken cancellationToken = default)
        {
            if (!IsOpen) return;
            BreakState = true;
            await Task.Delay(TimeSpan.FromMicroseconds(timeout), cancellationToken);
            BreakState = false;
        }

    }
}
