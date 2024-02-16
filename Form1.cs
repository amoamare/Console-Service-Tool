using ConsoleServiceTool.Console.Sony.PlayStation5.Views;
using Squirrel;
using System.Diagnostics;
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


        private async void Form1_Load(object sender, EventArgs e)
        {
            Text = $"{Text} - {Assembly.GetExecutingAssembly().GetName().Version}";
            LoadViews();
            try
            {
                await CheckForUpdatesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private static async Task CheckForUpdatesAsync()
        {
            Uri updatePath;
#if DEBUG
            updatePath = new Uri("");
#else
            updatePath = "";
#endif
            using var mgr = new UpdateManager(updatePath.AbsolutePath);
            await mgr.UpdateApp();
        }

        private void LoadViews()
        {
            TabPagePS5Nor.Controls.Add(_ps5NorView);
            TabPagePS5Uart.Controls.Add(_ps5UartView);
        }
    }
}