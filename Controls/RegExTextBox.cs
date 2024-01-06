using System.Text.RegularExpressions;

namespace ConsoleServiceTool
{
    public partial class RegExTextBox : TextBox
    {

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

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Back:
                    break;
                default:
                    if (RegEx != default)
                    {
                        e.Handled = ValidateKeyPress(e.KeyChar);
                    }
                    break;
            }
            base.OnKeyPress(e);
        }

        private bool ValidateKeyPress(char c)
        {
            if (RegEx == default) return true; 
            var expression = new Regex(RegEx);
            return !expression.IsMatch(new char[] {c});
        }
    }
}
