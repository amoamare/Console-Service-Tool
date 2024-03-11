using Microsoft.Web.WebView2.Core;

namespace ConsoleServiceTool.Views
{
    internal partial class HomeView : UserControl, IUserControl
    {
        public string FriendlyName => @"Home";

        public HomeView()
        {
            InitializeComponent();
        }

        private void WebViewMain_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            WebViewMain.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
            WebViewMain.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
            WebViewMain.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = false;
            WebViewMain.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            WebViewMain.CoreWebView2.Settings.AreDevToolsEnabled = false;
            WebViewMain.CoreWebView2.Settings.IsStatusBarEnabled = false;
        }

        private void CoreWebView2_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            // WebViewMain.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;
        }

        private void CoreWebView2_NavigationStarting(object? sender, CoreWebView2NavigationStartingEventArgs e)
        {
            e.Cancel = true;
        }

        private void CoreWebView2_NewWindowRequested(object? sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            e.Handled = true;
        }
    }
}
