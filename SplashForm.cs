using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minecraft_Bedrock_Launcher
{
    public class SplashForm : Form
    {
        private System.Windows.Forms.Timer timer;

        public SplashForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.Black;

            Image splashImage = Image.FromFile("SplashScreen.png");
            this.Width = splashImage.Width;
            this.Height = splashImage.Height;

            PictureBox logo = new PictureBox()
            {
                Image = splashImage,
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill
            };

            this.Controls.Add(logo);

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 2000; // 2秒
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            this.Close(); // ★ Hide() → Close() に変更
        }
    }
}
