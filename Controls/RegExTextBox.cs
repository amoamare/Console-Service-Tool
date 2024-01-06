using System.ComponentModel;
using System.Text.RegularExpressions;

namespace ConsoleServiceTool
{
    public partial class RegExTextBox : TextBox
    {
        private bool IsCopy = false;
        private bool IsPaste = false;
        private bool IsAll = false;

        public int MinLength { get; set; } = -1;

        public RegExTextBox()
        {
            InitializeComponent();
        }

        public string? RegEx { get; set; } = default;

        public string? OriginalValue { get; set; } = default;

        protected override void OnTextChanged(EventArgs e)
        {
            if (OriginalValue == default)
            {
                OriginalValue = Text;
            }
            else
            {
                Modified = !OriginalValue.Equals(Text, StringComparison.Ordinal);
            }
            base.OnTextChanged(e);
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            if (MinLength >= 0)
            {
                if (TextLength < MinLength)
                {
                    Undo();
                    ClearUndo();
                }
            }
            if (!string.IsNullOrEmpty(RegEx))
            {
                var expression = new Regex(RegEx);
              //  e.Cancel = expression.IsMatch(Text);
                if (!expression.IsMatch(Text))
                {
                    Undo();
                    ClearUndo();
                }
            }
            base.OnValidating(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                IsCopy = true;
            }
            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                IsPaste = true;
            }

            if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
            {
                IsAll = true;
            }

            base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!IsCopy && !IsPaste && !IsAll)
            {
                switch (e.KeyChar)
                {
                    case (char)Keys.Back:
                        break;
                    default:
                        if (!string.IsNullOrEmpty(RegEx))
                        {
                            e.Handled = ValidateKeyPress(e.KeyChar);
                        }
                        break;
                }
            }
            IsCopy = IsAll = IsPaste = false;
            base.OnKeyPress(e);
        }

        private bool ValidateKeyPress(char c)
        {
            if (string.IsNullOrEmpty(RegEx)) return true; 
            var expression = new Regex(RegEx);
            return !expression.IsMatch(new char[] {c});
        }
    }
}
