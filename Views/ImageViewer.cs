using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleServiceTool.Views
{
    public partial class ImageViewer : Form
    {
        public ImageViewer(Uri url, string? title = default)
        {
            InitializeComponent();
            LoadPage(url);
            if (title != null)
                Text = title;
        }

        private void LoadPage(Uri url)
        {
            webView21.Source = url;

        }

        private void webView21_ContentLoading(object sender, Microsoft.Web.WebView2.Core.CoreWebView2ContentLoadingEventArgs e)
        {

        }

        private void webView21_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            webView21.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
            webView21.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
            webView21.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = false;
            webView21.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            webView21.CoreWebView2.Settings.AreDevToolsEnabled = false;
        }

        private void CoreWebView2_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            webView21.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;
        }

        private void CoreWebView2_NavigationStarting(object? sender, CoreWebView2NavigationStartingEventArgs e)
        {
            e.Cancel = true; 
            System.Diagnostics.Process.Start("explorer.exe", $"\"{e.Uri}\"");
        }

        private void CoreWebView2_NewWindowRequested(object? sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            e.Handled = true;
            // No need to wait for the launcher to finish sending the URI to the browser
            // before we allow the WebView2 in our app to continue.
            System.Diagnostics.Process.Start(e.Uri);
            // LaunchUriAsync is the WinRT API for launching a URI.
            // Another option not involving WinRT might be System.Diagnostics.Process.Start(args.Uri);
        }
    }
}
