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
            if (!IsSquirrelInstall()) return;
#if DEBUG
            using var mgr = new UpdateManager(@"\ConsoleServiceTool\bin\Releases");
            await mgr.UpdateApp();
#else
            using var mgr = await UpdateManager.GitHubUpdateManager(@"https://github.com/amoamare/Console-Service-Tool");
            await mgr.UpdateApp();
#endif
        }

        private static bool IsSquirrelInstall()
        {
            var assembly = Assembly.GetEntryAssembly();
            if (assembly == default || assembly.Location == default) return false;
            var assemblyLocation = Path.GetDirectoryName(assembly.Location);
            if (assemblyLocation == default) return false;
            var updateDotExe = Path.Combine(assemblyLocation, "..", "Update.exe");
            return File.Exists(updateDotExe);
        }

        private void LoadViews()
        {
            TabPagePS5Nor.Controls.Add(_ps5NorView);
            TabPagePS5Uart.Controls.Add(_ps5UartView);
        }
    }
}