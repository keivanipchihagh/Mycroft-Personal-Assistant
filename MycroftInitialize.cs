using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Mycroft
{
    public partial class MycroftInitialize : Form
    {
        // Rounded Corners Configurations
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // X-Coordinate Of Upper-Left Corner
            int nTopRect,      // Y-Coordinate Of Upper-Left Corner
            int nRightRect,    // X-Coordinate Of Lower-Right Corner
            int nBottomRect,   // Y-Coordinate Of Lower-Right Corner
            int nWidthEllipse, // Height Of Ellipse
            int nHeightEllipse // Width Of Ellipse
        );

        List<string> MissingFiles = new List<string>();
        string[] Required_Files = new string[28]
            {
                "cvaux110.dll",
                "cvextern.dll",
                "Emgu.CV.dll",
                "Emgu.CV.GPU.dll",
                "Emgu.CV.ML.dll",
                "Emgu.CV.UI.dll",
                "Emgu.CV.UI.xml",
                "Emgu.CV.xml",
                "Gdi32.dll",
                "Emgu.Util.dll",
                "wininet.dll",
                "Emgu.Util.xml",
                "haarcascade_frontalface_default.xml",
                "haarcascade_eye.xml",
                "highgui110.dll",
                "opencv_calib3d220.dll",
                "opencv_contrib220.dll",
                "opencv_core220.dll",
                "opencv_features2d220.dll",
                "opencv_ffmpeg220.dll",
                "opencv_flann220.dll",
                "opencv_gpu220.dll",
                "opencv_highgui220.dll",
                "opencv_imgproc220.dll",
                "opencv_legacy220.dll",
                "opencv_ml220.dll",
                "opencv_objdetect220.dll",
                "opencv_video220.dll",
            };
        string[] Current_Files = Directory.GetFiles(Application.StartupPath);
        int Step = 0;

        public MycroftInitialize()
        {
            InitializeComponent();

            //Sets the scaling mode
            this.AutoScaleMode = AutoScaleMode.Dpi;

            // Rounded Corners
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 80, 80));
        }

        private void CheckSystemFiles()
        {
            for (int i = 0; i < Current_Files.Length; i++)
                Current_Files[i] = Current_Files[i].Replace(Application.StartupPath + "\\", "");

            for (int i = 0; i < Required_Files.Length; i++)
            {
                if (!Current_Files.Contains(Required_Files[i]))
                    MissingFiles.Add(Required_Files[i]);
            }

            if (MissingFiles.Count != 0)
            {
                string MissingFileNames = null;
                foreach (string Item in MissingFiles)
                    MissingFileNames += Item + "\n";

                // Error Message:
                MessageBox.Show("An Error occured while loading the following files from file directory:\n" + MissingFileNames + "\n\nError Info: Could not initialize program due to lack of resources.\nSolution: Add the missing files to program directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                // Terminate Application:
                Process.GetCurrentProcess().Kill();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Step += 10;
            if (Step == 100)
            {
                LoadingPanel.Width = 150;
                Thread.Sleep(200);
                LoadingPanel.Width += 40;
                CheckSystemFiles();
            }
            if (Step == 150)
                LoadingPanel.Width = 400;
            if (Step == 250)
            {
                LoadingPanel.Width = 600;
                Thread.Sleep(50);
                LoadingPanel.Width += 10;
                Thread.Sleep(50);
                LoadingPanel.Width += 10;
            }
            if (Step == 270)
                LoadingPanel.Width = 650;
            if (Step == 300)
            {
                LoadingPanel.Width = 700;
                Thread.Sleep(10);
                LoadingPanel.Width += 10;
                Thread.Sleep(50);
                LoadingPanel.Width += 30;
            }
            if (Step == 350)
                LoadingPanel.Width = 800;

            if (LoadingPanel.Width == 800)
            {
                Timer.Enabled = false;
                this.Hide();
                Mycroft mycroft = new Mycroft();
                mycroft.Show();
            }
        }
    }
}