using ConsoleServiceTool.Console.Sony.PlayStation5.Views;
using ConsoleServiceTool.Console.Sony.Shared.Models;
using ConsoleServiceTool.Models;
using ConsoleServiceTool.Utils;
using ConsoleServiceTool.Views;
using System.Runtime.InteropServices;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

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
            //LinkClicked += ReadOnlyRichTextBox_LinkClicked;
            DetectUrls = true;
        }

        //private void ReadOnlyRichTextBox_LinkClicked(object? sender, LinkClickedEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(e.LinkText)) { return; }
        //    if (e.LinkText == "{{report}}")
        //    {
        //    }
        //    //verify we are opening a real web url and not a file path.
        //    if (!Uri.TryCreate(e.LinkText, UriKind.Absolute, out var uriResult)
        //        || uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps)
        //    {
        //        return;
        //    }//
        //    using var image = new ImageViewer(uriResult);
        //    image.ShowDialog();
        //}

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


        private void HighlightLastLine(Priority priority, int start, int length )
        {
            Select(start, length);
            SelectionColor = priority.ToColor();
        }

        internal void LogPlaystationErrorCode(PlayStationErrorCode? errorCode, bool highlightSevereLines = false)
        {
            if (errorCode == default) return;
            Append($"{errorCode.Priority}\t\t", errorCode.Priority);
            var textPosStart = this.TextLength;
            AppendLine($"{errorCode.Message}");
            if (errorCode.Priority == Priority.Severe && highlightSevereLines)
            {
                var textPosEnd = this.TextLength;
                HighlightLastLine(Priority.Severe, textPosStart, textPosEnd - textPosStart);
            }
        }

        private const string fieldHyper = @"{\cf0{\field{\*\fldinst HYPERLINK """;
        private const string fieldFriendlyName = @"""}{\fldrslt ";
        private const string closeFields = @"}}}\f0\fs18\par";

        internal void InsertFriendlyNameHyperLink(string friendlyName, string hyperLink)
        {
            if (InvokeRequired)
            {
                _ = Invoke(new MethodInvoker(() => InsertFriendlyNameHyperLink(friendlyName, hyperLink)));
                return;
            }

            AppendText("@replaceurl@");
            var link = new StringBuilder();
            link.Append(fieldHyper);
            link.Append(hyperLink);
            link.Append(fieldFriendlyName);
            link.Append(friendlyName);
            link.Append(closeFields);
            Rtf = Rtf.Replace("@replaceurl@", link.ToString());
        }
        
        private const string tableStart = @"{\trowd \trgaph180";
        private const string cellFormat = @"\clvertalc\cellx{0}";
        private const string cellContent = @"\pard\intbl {0}\cell";
        private const string cellContentBold = @"\b {0} \b0";
        private const string tableEnd = @"\row\trowd}";

        internal void InsertTableWithSingleRow(string[] cellValues, int[] cellWidths, bool isHeader = false) 
        {
            if (InvokeRequired)
            {
                _ = Invoke(new MethodInvoker(() => InsertTableWithSingleRow(cellValues, cellWidths, isHeader)));
                return;
            }

            AppendText("@replacetable@");

            // Build the RTF table
            var tableBuilder = new StringBuilder();
            tableBuilder.Append(tableStart);
            
            int currentWidth = 0;

            // Add cells and their content
            for (var i = 0; i < cellValues.Length; i++)
            {
                // Define the right boundary of the cell
                currentWidth += cellWidths[i]; // Increment to the next cell's right boundary
                tableBuilder.AppendFormat(cellFormat, currentWidth);
            }

            foreach (var cellValue in cellValues)
            {
                // Add the content to the cell, allowing for new lines
                var formattedCellContent = cellValue;
                if (isHeader)
                     formattedCellContent = String.Format(cellContentBold, cellValue);
                formattedCellContent = formattedCellContent.Replace("\n", @" \line ");

                tableBuilder.AppendFormat(cellContent, formattedCellContent);
            }

            // End the row
            tableBuilder.Append(tableEnd);

            // Wrap the table in a full RTF structure
            var fullRtfBuilder = new StringBuilder();
            fullRtfBuilder.Append(tableBuilder);

            // Replace the placeholder with the table
            Rtf = Rtf.Replace("@replacetable@", fullRtfBuilder.ToString());
        }


    }
}