using ConsoleServiceTool.Communication;
using ConsoleServiceTool.Console.Sony.Shared.Models;
using ConsoleServiceTool.Models;
using System.ComponentModel;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleServiceTool.Utils
{
    internal static class Extensions
    {
        internal static unsafe double Entropy(byte[] data)
        {
            int* rgi = stackalloc int[0x100], pi = rgi + 0x100;

            for (int i = data.Length; --i >= 0;)
                rgi[data[i]]++;

            double H = 0.0, cb = data.Length;
            while (--pi >= rgi)
                if (*pi > 0)
                    H += *pi * Math.Log(*pi / cb, 2.0);

            return -H / cb;
        }

        private static readonly IReadOnlyDictionary<WarningStatus, Color> WarningStatusColorMap = new Dictionary<WarningStatus, Color>()
        {
            { WarningStatus.Success,  Color.FromArgb(0, 172, 70) },
            { WarningStatus.Information, Color.DarkOrange }, //Color.FromArgb(253, 197, 0) },
            { WarningStatus.Error,   Color.FromArgb(220, 0, 0)  },
            { WarningStatus.Unknown, Color.Black }
        };
        private static readonly IReadOnlyDictionary<Priority, Color> PriorityColorMap = new Dictionary<Priority, Color>()
        { 
            { Priority.Low,  Color.FromArgb(0, 172, 70) },
            { Priority.Medium,       Color.FromArgb(253, 197, 0) },
            { Priority.High,   Color.FromArgb(120, 0, 0)  },
            { Priority.Severe,   Color.FromArgb(220, 0, 0)  },
            { Priority.Unknown, Color.Black }
        };


        internal static Color ToColor(this Priority priority)
        {
            if(!Enum.IsDefined(typeof(Priority), priority))
            {
                return PriorityColorMap[Priority.Unknown];
            }
            return PriorityColorMap[priority];
        }

        internal static Color ToColor(this WarningStatus warningStatus)
        {
            if (!Enum.IsDefined(typeof(WarningStatus), warningStatus))
            {
                return PriorityColorMap[Priority.Unknown];
            }
            return WarningStatusColorMap[warningStatus];
        }


        /// <summary>
        /// Reads a C style null terminated ASCII string
        /// </summary>
        /// <param name="reader">The binary reader</param>
        /// <returns>A string as read from the stream</returns>
        internal static string ReadSZString(this BinaryReader reader)
        {
            var result = new StringBuilder();
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                byte b = reader.ReadByte();
                if (0 == b)
                    break;
                result.Append((char)b);
            }
            return result.ToString();
        }

        /// <summary>
        /// Reads a C style null terminated ASCII string
        /// </summary>
        /// <param name="reader">The binary reader</param>
        /// <returns>A string as read from the stream</returns>
        internal static string ReadStringUntilChar(this BinaryReader reader, byte until)
        {
            var result = new StringBuilder();
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                byte b = reader.ReadByte();
                if (until == b)
                    break;
                result.Append((char)b);
            }
            return result.ToString();
        }

        /// <summary>
        /// Reads a fixed size ASCII string
        /// </summary>
        /// <param name="reader">The binary reader</param>
        /// <param name="count">The number of characters</param>
        /// <returns>A string as read from the stream</returns>
        internal static string ReadFixedString(this BinaryReader reader, int count)
        {
            return Encoding.ASCII.GetString(reader.ReadBytes(count));
        }

        internal static string ReadCString(this byte[] str)
        {
            var index = Array.FindIndex(str, 0, x => x == 0);
            if (index < 0)
                return Encoding.ASCII.GetString(str);
            return Encoding.ASCII.GetString(str, 0, index);
        }
        internal static string ToHexString(this byte[] bytes)
        {
            return Convert.ToHexString(bytes);
        }

        internal static byte[] FromHexString(this string str)
        {
            return Convert.FromHexString(str);
        }

        internal static long ToLong(this string str, long defaultValue = 0)
        {           
            if (long.TryParse(str, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out long i))
            {
                return i;      
            }
            return defaultValue;
        }

        internal static void EnumForComboBox<EnumType>(this ComboBox comboBox) => comboBox.DataSource = Enum.GetValues(typeof(EnumType))
         .Cast<Enum>()
         .Select(Value =>
         {
             var Description = string.Empty;
             var fieldInfo = Value.GetType().GetField(Value.ToString());
             if (fieldInfo != null)
             {
                 var attribute = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute)) as DescriptionAttribute;
                 Description = attribute?.Description;
             }
             return new
             {
                 Description,
                 Value
             };
         }
         )
         .OrderBy(item => item.Value)
         .ToList();

        internal static string CalculateMd5Sum(this FileInfo input)
        {
            using var stream = input.OpenRead();
            using var md5 = MD5.Create();
            return md5.ComputeHash(stream).ToHexString();
        }

        internal static string FormattedByteSize(this long l, UnitOfSize unit = UnitOfSize.MB)
        {
            return $"{l.ToSize(unit)} ({l:n0}) bytes.";
        }

        internal enum UnitOfSize
        {
            Byte, KB, MB, GB, TB, PB, EB, ZB, YB
        }

        internal static string ToSize(this long value, UnitOfSize unit) =>
            $"{value / Math.Pow(1000, (long)unit):F2} {unit}";

        internal static string ToSize(this ulong value, UnitOfSize unit) => ToSize((long)value, unit);
       
        internal static byte[] Align(this byte[] buf, int size = 1024)
        {
            Array.Resize(ref buf, size);
            return buf;
        }

        internal static byte[] Align(this List<byte> buffer, int size = 1024) => Align(buffer.ToArray(), size);


        internal static async Task<byte[]> ReadAsync(this SerialPort serialPort, CancellationToken cancellationToken)
        {
            _ = cancellationToken.Register(x =>
            {
                if (x is not SerialPort port || !port.IsOpen) return;
                port.DiscardInBuffer();
                port.DiscardOutBuffer();
            }, serialPort);
            var buffer = new byte[4096];
            int readBytes = 0;
            using var memoryStream = new MemoryStream();

            while ((readBytes = await serialPort.BaseStream.ReadAsync(buffer.AsMemory(), cancellationToken).ConfigureAwait(false)) > 0)
            {
                await memoryStream.WriteAsync(buffer.AsMemory(0, readBytes), cancellationToken).ConfigureAwait(false);
            }

            return memoryStream.ToArray();

        }

        internal static async Task<string> ReadLineAsync(this SerialPort serialPort)
        {
            var sb = new StringBuilder();
            var buffer = new byte[1];
            string? response;
            while (true)
            {
                await serialPort.BaseStream.ReadAsync(buffer.AsMemory()).ConfigureAwait(false);
                sb.Append(serialPort.Encoding.GetString(buffer));
                var newLine = StringBuilderEndsWith(sb, serialPort.NewLine);
                if (newLine)
                {
                    response = sb.ToString()[..^serialPort.NewLine.Length];
                    break;
                }
            }
            return response;
        }

        internal static async Task<string> ReadLineAsync(this SerialPort serialPort, CancellationToken cancellationToken)
        {
            var sb = new StringBuilder();
            var buffer = new byte[1];
            string? response;
            _ = cancellationToken.Register(x =>
            {
                if (x is not SerialPort port || !port.IsOpen) return;
                port.DiscardInBuffer();
                port.DiscardOutBuffer();
            }, serialPort);
            while (true)
            {
                await serialPort.BaseStream.ReadAsync(buffer.AsMemory(), cancellationToken).ConfigureAwait(false);
                sb.Append(serialPort.Encoding.GetString(buffer));
                var newLine = StringBuilderEndsWith(sb, serialPort.NewLine);
                if (newLine)
                {
                    response = sb.ToString()[..^serialPort.NewLine.Length];
                    break;
                }
            }
            return response;
        }

        internal static async Task WriteLineAsync(this SerialPort serialPort, string str, CancellationToken cancellationToken)
        {
            var data = serialPort.Encoding.GetBytes($"{str}{serialPort.NewLine}");
            await serialPort.BaseStream.WriteAsync(data, cancellationToken).ConfigureAwait(false);
            await serialPort.BaseStream.FlushAsync(cancellationToken).ConfigureAwait(false);
            await Task.Delay(10, cancellationToken).ConfigureAwait(false);
        }

        internal static async Task WriteLineAsync(this SerialPort serialPort, string str) => await WriteLineAsync(serialPort, str, CancellationToken.None);

        internal static async Task<string> RequestResponseAsync(this SerialPort serialPort, string str)
        {
            await WriteLineAsync(serialPort, str).ConfigureAwait(false);
            var response = await ReadLineAsync(serialPort).ConfigureAwait(false);
            return response;
        }

        internal static async Task<string> RequestResponseAsync(this SerialPort serialPort, string str, CancellationToken cancellationToken)
        {
            await WriteLineAsync(serialPort, str, cancellationToken).ConfigureAwait(false);
            var response = await ReadLineAsync(serialPort, cancellationToken).ConfigureAwait(false);
            return response;
        }

        private static bool StringBuilderEndsWith(StringBuilder sb, string str)
        {
            if (sb.Length < str.Length) return false;
            var end = sb.ToString(sb.Length - str.Length, str.Length);
            return end.Equals(str);
        }

        internal static string? ToDescription(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            if (name == null) return null;
            var field = type.GetField(name);
            if (field == null) return null;
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute descriptionAttribute)
                return descriptionAttribute.Description;
            return name;
        }

        internal static string TrimAllWithInplaceCharArray(this string str)
        {
            var len = str.Length;
            var src = str.ToCharArray();
            int dstIdx = 0;

            for (int i = 0; i < len; i++)
            {
                var ch = src[i];

                switch (ch)
                {
                    case '\u0020':
                    case '\u00A0':
                    case '\u1680':
                    case '\u2000':
                    case '\u2001':

                    case '\u2002':
                    case '\u2003':
                    case '\u2004':
                    case '\u2005':
                    case '\u2006':

                    case '\u2007':
                    case '\u2008':
                    case '\u2009':
                    case '\u200A':
                    case '\u202F':

                    case '\u205F':
                    case '\u3000':
                    case '\u2028':
                    case '\u2029':
                    case '\u0009':

                    case '\u000A':
                    case '\u000B':
                    case '\u000C':
                    case '\u000D':
                    case '\u0085':
                        continue;

                    default:
                        src[dstIdx++] = ch;
                        break;
                }
            }
            return new string(src, 0, dstIdx);
        }
    }
}
