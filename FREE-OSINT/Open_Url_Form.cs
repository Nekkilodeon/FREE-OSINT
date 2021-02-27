using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FREE_OSINT
{
    public partial class Open_Url_Form : Form
    {
        private ChromiumWebBrowser browser;

        public Open_Url_Form()
        {
            InitializeComponent();
            browser = new ChromiumWebBrowser("");
            browser.Dock = DockStyle.Fill;
            panelBrowser.Controls.Add(browser);
            browser.LoadingStateChanged += OnLoadingStateChanged;
            browser.ConsoleMessage += OnBrowserConsoleMessage;
            browser.StatusMessage += OnBrowserStatusMessage;
            browser.TitleChanged += OnBrowserTitleChanged;
            browser.AddressChanged += OnBrowserAddressChanged;
        }
        public Open_Url_Form(string url)
        {
            InitializeComponent();
            browser = new ChromiumWebBrowser(url);
            browser.Dock = DockStyle.Fill;
            panelBrowser.Controls.Add(browser);
            browser.LoadingStateChanged += OnLoadingStateChanged;
            browser.ConsoleMessage += OnBrowserConsoleMessage;
            browser.StatusMessage += OnBrowserStatusMessage;
            browser.TitleChanged += OnBrowserTitleChanged;
            browser.AddressChanged += OnBrowserAddressChanged;
        }
        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs e)
        {
            txtURL.Invoke((MethodInvoker)delegate
            {
                // Running on the UI thread
                txtURL.Text = e.Address;

            });
            //throw new NotImplementedException();
        }

        private void Open_Url_Form_Load(object sender, EventArgs e)
        {

        }

        private void panelBrowser_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {
            SetCanGoBack(args.CanGoBack);
            SetCanGoForward(args.CanGoForward);
            SetIsLoading(args.CanReload);
        }

        private void SetIsLoading(bool v)
        {
            btnReload.Invoke((MethodInvoker)delegate
            {
                // Running on the UI thread
                btnReload.Enabled = v;

            });
        }

        private void SetCanGoForward(bool canGoForward)
        {
            btnForward.Invoke((MethodInvoker)delegate
            {
                // Running on the UI thread
                btnForward.Enabled = canGoForward;

            });
        }

        private void SetCanGoBack(bool canGoBack)
        {
            btnBack.Invoke((MethodInvoker)delegate
            {
                // Running on the UI thread
                btnBack.Enabled = canGoBack;

            });
        }
        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs e)
        {
            labelURLTitle.Invoke((MethodInvoker)delegate
            {
                // Running on the UI thread
                labelURLTitle.Text = e.Title;

            });
            //txtURL.Text = e.Title;
        }

        private void OnBrowserStatusMessage(object sender, StatusMessageEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void OnBrowserConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void onFormClosing(object sender, FormClosingEventArgs e)
        {
            browser.Dispose();
        }
    }
}
