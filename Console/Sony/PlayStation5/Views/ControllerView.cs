

using Microsoft.Web.WebView2.Core;

namespace ConsoleServiceTool.Console.Sony.PlayStation5.Views
{
    internal partial class ControllerView : UserControl
    {
        private static readonly Uri _uriDualShock = new("https://dualshock-tools.github.io", UriKind.Absolute);
        private static readonly Uri _uriGamePadTester = new("https://hardwaretester.com/gamepad", UriKind.Absolute);
        public ControllerView()
        {
            InitializeComponent();
        }

        private void dualControlWebView_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            dualControlWebView.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = false;
            dualControlWebView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            dualControlWebView.CoreWebView2.Settings.AreDevToolsEnabled = false;
            dualControlWebView.CoreWebView2.Settings.IsStatusBarEnabled = false;
            dualControlWebView.CoreWebView2.Profile.PreferredTrackingPreventionLevel = CoreWebView2TrackingPreventionLevel.Basic;
            dualControlWebView.Source = _uriDualShock;
            dualControlWebView.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            dualControlWebView.Source = _uriDualShock;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dualControlWebView.Source = _uriGamePadTester;
        }

        private void CoreWebView2_NewWindowRequested(object? sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            e.NewWindow = (CoreWebView2)sender!;
            //e.Handled = true;
        }
    }
}
