using ConsoleServiceTool.Utils;
using ConsoleServiceTool.Views;

namespace ConsoleServiceTool.Console.Sony.PlayStation5.Views
{
    public partial class PlayStation5MainView : UserControl, IUserControl
    {
        public string FriendlyName => @"PlayStation 5";

        private readonly UserControlFactory controlFactory = UserControlFactory.Instance;

        public PlayStation5MainView()
        {
            InitializeComponent();
            DoubleBuffered = true;
            AddControlTab<PS5UartView>(tabPage1);
            AddControlTab<PS5NorView>(tabPage2);
        }

        private void AddControlTab<T>(TabPage page) where T : UserControl
        {
            var control = controlFactory.Get<T>();
            page.Controls.Clear();
            page.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }
    }
}
