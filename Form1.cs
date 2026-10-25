using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace Minecraft_Bedrock_Launcher
{
    public class Form1 : Form
    {
        private WebView2 webView;

        public Form1()
        {
            InitializeLauncherWindow();
            InitializeWebView();
        }

        private void InitializeLauncherWindow()
        {
            this.Text = "Minecraft Bedrock Launcher";

            // ★ここを好きなサイズに変更できる
            this.Width = 800;
            this.Height = 600;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true; // 最大化できるようにする
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private async void InitializeWebView()
        {
            webView = new WebView2
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(webView);

            await webView.EnsureCoreWebView2Async(null);

            string htmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "launcher.html");

            if (!File.Exists(htmlPath))
            {
                MessageBox.Show(
                    "launcher.html が見つかりません。\nEXE と同じフォルダに置いてください。",
                    "ファイルがありません",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            webView.CoreWebView2.Navigate($"file:///{htmlPath.Replace("\\", "/")}");
        }
    }
}
