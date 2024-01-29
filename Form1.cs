using ConsoleServiceTool.Console.Sony.PlayStation5.Views;
using System.Reflection;

namespace ConsoleServiceTool
{
    internal partial class Form1 : Form
    {
        private readonly PS5UartView _ps5UartView = new() { Dock = DockStyle.Fill };
        private readonly PS5NorView _ps5NorView = new () { Dock = DockStyle.Fill };

        internal Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = $"{Text} - {Assembly.GetExecutingAssembly().GetName().Version}";
            LoadViews();
        }

        private void LoadViews()
        {
            TabPagePS5Nor.Controls.Add(_ps5NorView);
            TabPagePS5Uart.Controls.Add(_ps5UartView);
        }
    }
}