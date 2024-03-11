using Microsoft.Web.WebView2.Core;
using System.Diagnostics;

namespace ConsoleServiceTool.Controls
{
    internal partial class InfoViewer : UserControl
    {
        private static readonly Uri _uriRef = new("https://consoleservicetool.com");
        internal InfoViewer()
        {
            InitializeComponent();
        }

        internal void GotoPage(Uri uri)
        {
            LabelLoading.Visible = true;
            WebViewMain.Source = uri;
            Visible = true;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            WebViewMain.CoreWebView2?.NavigateToString(string.Empty);
            Visible = false;
        }

        private void WebViewMain_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            WebViewMain.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;
            WebViewMain.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
            WebViewMain.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
            WebViewMain.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = false;
            WebViewMain.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            WebViewMain.CoreWebView2.Settings.AreDevToolsEnabled = false;
            WebViewMain.CoreWebView2.Settings.IsStatusBarEnabled = false;
            WebViewMain.CoreWebView2.Profile.PreferredTrackingPreventionLevel = CoreWebView2TrackingPreventionLevel.Basic;
        }

        private void CoreWebView2_NavigationStarting(object? sender, CoreWebView2NavigationStartingEventArgs e)
        {
            if (e.NavigationKind == CoreWebView2NavigationKind.BackOrForward
                || e.IsRedirected)
            {
                e.Cancel = true;
                return;
            }
            if (e.Uri.StartsWith(@"data:text/html;charset=utf-8;base64", StringComparison.InvariantCultureIgnoreCase) ||
                e.Uri.StartsWith(_uriRef.ToString(), StringComparison.InvariantCultureIgnoreCase)) return;
            e.Cancel = true;
            Process.Start(new ProcessStartInfo(e.Uri) { UseShellExecute = true });
        }

        private void CoreWebView2_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            LabelLoading.Visible = false;
        }

        private void CoreWebView2_NewWindowRequested(object? sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            e.Handled = false;
            Process.Start(new ProcessStartInfo(e.Uri) { UseShellExecute = false });
        }


        private void ButtonClose_MouseEnter(object sender, EventArgs e)
        {
            ButtonClose.Image = Properties.Resources.close_red_icon;
        }

        private void ButtonClose_MouseLeave(object sender, EventArgs e)
        {
            ButtonClose.Image = Properties.Resources.close_black_icon;
        }

        private void ButtonClose_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonClose.Image = Properties.Resources.close_fade_icon;
        }

        private void LabelLoading_VisibleChanged(object sender, EventArgs e)
        {
            WebViewMain.Visible = !LabelLoading.Visible;
        }
    }
}
