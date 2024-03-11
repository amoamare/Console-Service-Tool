using ConsoleServiceTool.Console.Sony.PlayStation5.Views;
using ConsoleServiceTool.Utils;
using ConsoleServiceTool.Views;
using System.Diagnostics;
using System.Reflection;
using Velopack;
#if RELEASE
using Velopack.Sources;
#endif

namespace ConsoleServiceTool
{
    internal partial class Form1 : Form
    {
        private readonly UserControlFactory controlFactory = UserControlFactory.Instance;

        internal Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            InitializeControlFactory();
            ShowControl<HomeView>();
            InitializeMenuItems();
        }

        private void InitializeControlFactory()
        {
            controlFactory.Register<HomeView>();
            controlFactory.Register<PlayStation5MainView>();
            controlFactory.Register<PS5NorView>();
            controlFactory.Register<PS5UartView>();
        }

        private void InitializeMenuItems()
        {
            homeToolStripMenuItem.Click += MenuItem_Click<HomeView>;
            playStation5ToolStripMenuItem.Click += MenuItem_Click<PlayStation5MainView>;
        }

        internal static List<int> DecodeErrorToBanks(string id)
        {
            // Remove the prefix to isolate the bank numbers part
            string bankNumbersPart = id[6..];

            // Parse the bank numbers part as hexadecimal
            int bankNumbers = Convert.ToInt32(bankNumbersPart, 16);

            // Initialize a list to store the extracted bank numbers
            List<int> extractedBankNumbers = [];

            // Iterate through each bit position and check if it's set (1)
            for (int i = 0; i < 8; i++)
            {
                // Check if the least significant bit is set
                if ((bankNumbers & 1) == 1)
                {
                    // Add the corresponding bank number to the list
                    extractedBankNumbers.Add(i + 1); // Add 1 to match bank numbering (1-indexed)
                }

                // Right shift the bank numbers to move to the next bit
                bankNumbers >>= 1;
            }

            return extractedBankNumbers;
        }


        private async void Form1_Load(object sender, EventArgs e)
        {
            Text = $"{Text} - {Assembly.GetExecutingAssembly().GetName().Version}";
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
            var mgr = new UpdateManager(@"bin\Releases");
#else
            var source = new GithubSource(@"https://github.com/amoamare/Console-Service-Tool", accessToken: default, prerelease: false);
            var mgr = new UpdateManager(source);
#endif
            var newVersion = await mgr.CheckForUpdatesAsync();
            if (newVersion == null)
                return;            
            await mgr.DownloadUpdatesAsync(newVersion);
            mgr.ApplyUpdatesAndRestart(newVersion);
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

        private void ShowControl<T>() where T : UserControl
        {
            MainPanel.SuspendLayout();
            var control = controlFactory.Get<T>();
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(control);
            if (control is IUserControl inter)
                label1.Text = inter.FriendlyName;
            control.Dock = DockStyle.Fill;
            MainPanel.ResumeLayout();
        }

        private void MenuItem_Click<T>(object? sender, EventArgs e) where T : UserControl
        {
            ShowControl<T>();
        }
    }
}