using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            webView21.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = false;
            webView21.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            webView21.CoreWebView2.Settings.AreDevToolsEnabled = false;
        }
    }
}
