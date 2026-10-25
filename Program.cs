using System;
using System.Windows.Forms;

namespace Minecraft_Bedrock_Launcher
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // スプラッシュ画面を表示
            using (SplashForm splash = new SplashForm())
            {
                splash.Show();
                Application.DoEvents(); // スプラッシュを描画

                System.Threading.Thread.Sleep(2000); // 2秒待つ
            }

            // スプラッシュが閉じた後に Form1 を起動
            Application.Run(new Form1());
        }
    }
}
