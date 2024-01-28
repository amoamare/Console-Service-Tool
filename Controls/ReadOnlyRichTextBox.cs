using ConsoleServiceTool.Console.Sony.Shared.Models;
using ConsoleServiceTool.Models;
using ConsoleServiceTool.Utils;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleServiceTool.Controls
{
    public partial class ReadOnlyRichTextBox : RichTextBox
    {
        [LibraryImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool HideCaret(nint hWnd);

        public ReadOnlyRichTextBox()
        {
            ReadOnly = true;
            TabStop = false;
            _ = HideCaret(Handle);
            LinkClicked += ReadOnlyRichTextBox_LinkClicked;
            DetectUrls = true;
        }

        private void ReadOnlyRichTextBox_LinkClicked(object? sender, LinkClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.LinkText)) { return; }
            //verify we are opening a real web url and not a file path.
            if (!Uri.TryCreate(e.LinkText, UriKind.Absolute, out var uriResult)
                || uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps)
            {
                return;
            }
            Process.Start(new ProcessStartInfo { FileName = uriResult.ToString(), UseShellExecute = true });
        }

        public override Color BackColor => Color.White;

        internal void AppendText(string text, Color color)
        {
            if (InvokeRequired)
            {
                _ = Invoke(new MethodInvoker(() => AppendText(text, color)));
                return;
            }

            SelectionStart = TextLength;
            SelectionLength = 0;
            SelectionColor = color;
            base.AppendText(text);
            SelectionColor = ForeColor;
            Select(Text.Length, 0);
            SelectionStart = Text.Length;
            SelectionLength = 0;
            ScrollToCaret();
        }


        internal new void AppendText(string text)
        {
            AppendText(text, ForeColor);
        }

        internal void Append(string text)
        {
            AppendText(text);
        }
        internal void AppendLine(string text)
        {
            AppendText($"{text}{Environment.NewLine}");
        }

        internal void Okay()
        {
            AppendLine("OK", WarningStatus.Success);
        }

        internal void Fail()
        {
            AppendLine("Fail", WarningStatus.Error);
        }
 
        internal void Fail(string reason)
        {
            AppendLine("Fail", WarningStatus.Error);
            AppendLine(reason, WarningStatus.Error);
        }

        
        private void AppendLine(string text, Color color)
        {
            AppendText($"{text}{Environment.NewLine}", color);
        }

        internal void AppendLine(string text, WarningStatus warning) => AppendLine(text, warning.ToColor());

        internal void AppendLine(string text, Priority priority) => AppendLine(text, priority.ToColor());

        internal void Append(string text, Color color)
        {
            AppendText(text, color);
        }

        internal void Append(string text, Priority priority) => Append(text, priority.ToColor());
        internal void Append(string text, WarningStatus warning) => Append(text, warning.ToColor());

        internal void AppendWarningLine(string text)
        {
            AppendLine(text, WarningStatus.Information);
        }

        internal void AppendErrorLine(string text)
        {
            AppendLine(text, WarningStatus.Error);
        }
       
        internal void ApppendOkLine(string text)
        {
            AppendLine(text, WarningStatus.Success);
        }


        internal void HighlightLastLine(Priority priority)
        {
            var start = GetFirstCharIndexFromLine(Lines.Length - 2);
            var length = Lines[^2].Length;
            Select(start, length);
            SelectionColor = priority.ToColor();            
        }


        private const string fieldHyper = @"{\cf0{\field{\*\fldinst{HYPERLINK ";
         private const string fieldFriendlyName = @" }}{\fldrslt{";
        private const string closeFields = @"\ul0\cf0}}}}\f0\fs18\par";

        internal void InsertFriendlyNameHyperLink(string friendlyName, string hyperLink)
        {
            AppendText("@replaceurl@");
            var link = new StringBuilder();
            link.Append(fieldHyper);
            link.Append(hyperLink);
            link.Append(fieldFriendlyName);
            link.Append(friendlyName);
            link.Append(closeFields);
            Rtf = Rtf.Replace("@replaceurl@", link.ToString());
        }
    }
}
