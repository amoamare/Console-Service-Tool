using ConsoleServiceTool.Consoles.Sony.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServiceTool.Utils
{
    internal unsafe static class Extensions
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
    }
}
