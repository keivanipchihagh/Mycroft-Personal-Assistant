using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using AudioSwitcher.AudioApi.CoreAudio;

namespace Mycroft
{
    public partial class MycroftFaceRecognizer : Form
    {
        // Classess, Engines, Contructors:
        MycroftRemoveDirectory RD = new MycroftRemoveDirectory();

        // Media Player:
        static WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        // PlayList Object:
        WMPLib.IWMPPlaylist PlayList = wplayer.newPlaylist("My playlist", "");

        // Variables, Vectors and Haarcascades:
        Image<Bgr, Byte> currentFrame;
        Image<Gray, byte> result;
        Image<Gray, byte> gray = null;
        public Image<Bgr, byte> PreviousFrame;
        Capture grabber;
        HaarCascade face;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        public Mycroft MyCroft;
        string name = null;
        bool Grabbing_Frames = true;
        public bool MonitoringMode = false;  // It's Value Can Be Changed Only From Jarvis Form
        public int Sensitivity = 50;   // For Monitoring
        int CountTrain = 0, t;
        float DifferentPixels = 0;
        public List<Image<Gray, byte>> FaceTrainingSet = new List<Image<Gray, byte>>();    // Face Training List
        bool DetectionIsRecognized = false;

        public MycroftFaceRecognizer()
        {
            InitializeComponent();

            //Load Haarcascades For Face Detection:
            face = new HaarCascade("haarcascade_frontalface_default.xml");

            try
            {
                //Load Previous trained Faces & Labels For Each Image:
                string[] Labels = File.ReadAllText("TrainedFaces/TrainedLabels.txt").Split('%');

                // Extact Number Of Previous Trained Faces:
                for (int i = 1; i < Convert.ToInt32(Labels[0]) + 1; i++)
                {
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + "face" + i + ".bmp"));
                    labels.Add(Labels[i]);
                }
            }
            catch
            {
                // Remove Directory And Subfolders:
                RD.RemoveDirectory();
            }

            //Initialize The Capture Device (Only One Device Is To Be Found):
            try
            {
                if (Convert.ToBoolean(Database.Default["RecognizeFace"]) == true)
                {
                    grabber = new Capture();
                    grabber.QueryFrame();

                    //Initialize The FrameGraber Event:
                    Application.Idle += new EventHandler(FrameGrabber);
                }
            }
            catch
            {
                MessageBox.Show("An Error occurred while setting up the following:\nWebcam\n\nError Info: Problem with webcam. Solution: Reinstall webcam drivers.", "Error (Coe 103)", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        public void GetFrame()
        {
            // Sets Frame:
            PreviousFrame = currentFrame;
        }

        private void FrameGrabber(object sender, EventArgs e)
        {
            if (Grabbing_Frames == true)
            {
                // Show Webcam Status In Parent Form:
                MyCroft.label6.Text = "Online";
                MyCroft.label6.ForeColor = Color.Lime;

                // Get The Current Frame Form Capture Device:                
                currentFrame = grabber.QueryFrame().Resize(638, 381, INTER.CV_INTER_CUBIC);

                // Monitoring Mode:
                if (MonitoringMode == true)
                    MonitoringProtocal(currentFrame);

                DetectionIsRecognized = false;

                // Convert It To Grayscale:
                gray = currentFrame.Convert<Gray, Byte>();

                // Face Detector Constructor:
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(face, 1.2, 10, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));

                // Take Action For Each Element Detected:
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    t = t + 1;
                    result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(180, 180, INTER.CV_INTER_CUBIC);

                    // Draw The Face detected In The 0th (Gray) Channel With Blue Color:
                    currentFrame.Draw(f.rect, new Bgr(Color.Blue), 2);

                    if (trainingImages.ToArray().Length != 0)
                    {
                        // TermCriteria For Face Recognition With Numbers Of Trained Images Like MaxIteration:
                        MCvTermCriteria termCrit = new MCvTermCriteria(CountTrain, 0.001);

                        // Eigen Face Recognizer:
                        EigenObjectRecognizer recognizer = new EigenObjectRecognizer(trainingImages.ToArray(), labels.ToArray(), 3000, ref termCrit);
                        name = recognizer.Recognize(result);

                        // Draw The Label For Each Face Detected And Recognized:
                        currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.Blue));

                        // Display 'Online':
                        DetectionIsRecognized = true;
                        MyCroft.IsAwake();

                        if (timer.Enabled == false)
                        {
                            //Greetings_Respond();
                            // Set 30-Minute Timer:
                            timer.Enabled = true;
                        }
                    }

                    // Set the region of interest on the faces                
                    gray.ROI = f.rect;
                }
                t = 0;
                // Show the faces procesed and recognized
                imageBoxFrameGrabber.Image = currentFrame;
            }
            else
            {
                // Show Webcam Status In Parent Form:
                MyCroft.label6.Text = "Offline";
                MyCroft.label6.ForeColor = Color.Red;
            }
        }

        private void ImageBoxFrameGrabber_MouseDown(object sender, MouseEventArgs e) => this.Visible = false;

        public void MonitoringProtocal(Image<Bgr, byte> Frame)
        {
            // Set The Value To 'True', so it can be accesible through the 'FrameGrabber' function
            MonitoringMode = true;

            // Diffence In Pixels:
            DifferentPixels = 0;

            // Converting Image<Bgr, Byte> Into Bitmap:
            Bitmap FirstFrame = PreviousFrame.Resize(400, 300, INTER.CV_INTER_CUBIC).ToBitmap();
            Bitmap SecondFrame = Frame.Resize(400, 300, INTER.CV_INTER_CUBIC).ToBitmap();

            // Comparing:
            for (int y = 0; y < FirstFrame.Height; y++)
                for (int x = 0; x < FirstFrame.Width; x++)
                {
                    Application.DoEvents();
                    DifferentPixels += ((float)(Math.Abs(FirstFrame.GetPixel(x, y).R - SecondFrame.GetPixel(x, y).R) + Math.Abs(FirstFrame.GetPixel(x, y).G - SecondFrame.GetPixel(x, y).G) + Math.Abs(FirstFrame.GetPixel(x, y).B - SecondFrame.GetPixel(x, y).B))) / 255;
                }

            if ((DifferentPixels * 100 / (400 * 300)) < (100 - Convert.ToInt32(Database.Default["Monitoring_Sensitivity"])))
                PreviousFrame = Frame;
            else
            {
                // Intruder Alert:
                // Max Volume:
                if (!DetectionIsRecognized)
                {
                    CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
                    defaultPlaybackDevice.Volume = 100;

                    wplayer.URL = @"Data\63.mp3";
                    wplayer.controls.play();
                }
            }
        }
    }
}
