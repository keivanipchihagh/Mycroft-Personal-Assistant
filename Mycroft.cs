using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace Mycroft
{
    public partial class Mycroft : Form
    {
        // Classess, Engines, Contructors:
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer Synthesizer = new SpeechSynthesizer();
        MycroftCommandCenter CommandsCenter = new MycroftCommandCenter();
        MycroftFaceRecognizer FaceRecognizer = new MycroftFaceRecognizer();
        MycroftVolumeAdjustment VolumeAdjustment = new MycroftVolumeAdjustment();
        MycroftGreetings Greetings = new MycroftGreetings();
        MycroftStaticCommands StaticCommands = new MycroftStaticCommands();
        MycroftTimeAnnouncement TimeAnnouncement = new MycroftTimeAnnouncement();
        MycroftMediaPlayerControls MediaPlayer = new MycroftMediaPlayerControls();
        MycroftDateAnnouncement DateAnnouncement = new MycroftDateAnnouncement();
        MycroftWeatherForecast WeatherForecast = new MycroftWeatherForecast();
        MycroftMediaPlayerControls MediaPlayerControls = new MycroftMediaPlayerControls();
        MycroftBatteryStatsReport BatteryStatsReport = new MycroftBatteryStatsReport();
        MycroftEncryption MycroftEncryption = new MycroftEncryption();
        MycroftDecryption MycroftDecryption = new MycroftDecryption();

        // MediaPlayer Library:
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

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

        // Variables
        private new bool Move = false;
        private bool RecognizeVoice = true;
        public bool Wake = false;
        private bool BatteryCharging = false;
        private int Mouse_X = 0;
        private int Mouse_Y = 0;

        // Dialog Variables:
        bool ShutdownPermission = false;
        bool RestartPermission = false;

        public Mycroft()
        {
            InitializeComponent();

            // Application's Main Exception Handler Thread Setup:
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandeledExceptionHandler);

            // Rounded Corners
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            // Primary Location
            this.Top = 5;
            this.Left = (SystemInformation.VirtualScreen.Width - this.Width) / 2;

            // Recognition Engine Setup
            Choices Commands = CommandsCenter.Commands();
            GrammarBuilder gBuiler = new GrammarBuilder();
            gBuiler.Append(Commands);
            Grammar grammer = new Grammar(gBuiler);
            recEngine.LoadGrammarAsync(grammer);
            recEngine.SpeechRecognized += RecEngine_SpeechRecognized;

            // Activation
            RecognitionAvtivationPrototype();

            // initialize Face Recognizer (Hidden Mode On By Default)
            FaceRecognizer.MyCroft = this;
            FaceRecognizer.Show();
            FaceRecognizer.Visible = false;
        }

        private void Mycroft_Load(object sender, EventArgs e)
        {
            // Initializing Primary Battery Stats:
            if (Convert.ToString(SystemInformation.PowerStatus.BatteryChargeStatus).ToLower().Contains("charging"))
                BatteryCharging = true;

            // Run on startup
            if (!File.Exists(@"C:\Users\Keivan\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\Mycroft.lnk"))
                if (DialogResult.Yes == MessageBox.Show("Would you like Mycroft to run on startup?", "Run On Stratup", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                {
                    var startupFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    var shell = new IWshRuntimeLibrary.WshShell();
                    var windowsApplicationShortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(@"C:\Users\Keivan\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\Mycroft.lnk");
                    windowsApplicationShortcut.Description = "Mycroft AI";
                    windowsApplicationShortcut.WorkingDirectory = Application.StartupPath;
                    windowsApplicationShortcut.TargetPath = Application.ExecutablePath;
                    windowsApplicationShortcut.Save();
                }

            Service.Tick += Service_Tick;
        }

        public void IsAwake()
        {
            Wake = true;
            Listen.Enabled = true;
            label3.Text = "Online";
            label3.ForeColor = Color.Lime;
        }

        // Instant Loadup

        private string[] Instant_Apps_Loadup()
        {
            // Re-Create Folder Incase Folder Is Removed
            if (!Directory.Exists(@"Data\Instant Apps List"))
            {
                Directory.CreateDirectory(@"Data\Instant Apps List");
                return null;    // If Folder Does Not Exists, Then No Actions Will Be Excecuted For This Dictioanry
            }
            else
            {
                // Gets The Full List Of Application Which Exist In The Following Directory
                string[] Instant_Apps_Names = Directory.GetFiles(@"Data\Instant Apps List");

                // Get The Name Of The Application
                for (int i = 0; i < Instant_Apps_Names.Length; i++)
                {
                    Instant_Apps_Names[i] = Instant_Apps_Names[i].Replace(@"Data\Instant Apps List\", "");
                    Instant_Apps_Names[i] = "Open " + Instant_Apps_Names[i].Remove(Instant_Apps_Names[i].IndexOf('.'));
                }
                return Instant_Apps_Names;  // Returns The Actions
            }
        }

        private void Instant_Musics_Loadup()
        {
            // Re-Create Folder Incase Folder Is Removed
            if (!Directory.Exists(@"Data\Favorite Music List"))
            {
                Directory.CreateDirectory(@"Data\Favorite Music List");
                DialogResult Result = MessageBox.Show("No favorite playlist was found in:\n" + Application.StartupPath + @"\Data\Favorite Music List" + "\nYou must add atleast one music to continue...\nWould you like me to open the directory for you?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (DialogResult.Yes == Result)
                    Process.Start(Application.StartupPath + @"\Data\Favorite Music List");
            }
            else
            {
                // Gets The Full List Of Application Which Exists In The Following Directory
                MediaPlayerControls.LoadPlaylist(Directory.GetFiles(@"Data\Favorite Music List"));
            }
        }

        // Exception Handler

        private void UnhandeledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            // Creating Log Files:
            File.AppendAllText(@"Data\Log Info\Log.txt", "- Jarvis:Unhandled Thread Exception:\"" + DateTime.Now.ToString() + "\":MESSAGE:" + (e.ExceptionObject as Exception).Message + ":STACKTRACE:" + (e.ExceptionObject as Exception).StackTrace + "\n\n\n");

            DialogResult Result = MessageBox.Show("An Unhandled Thread Exception occurred during runtime. Here is the info:\n" + (e.ExceptionObject as Exception).Message + "\nStackTrace: " + (e.ExceptionObject as Exception).StackTrace + "\n\nLog files can be found in: " + Application.StartupPath + @"Data\Log Info\Log.txt", "Unhandled Thread Exception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            if (Result == DialogResult.OK)
                Application.Restart();
        }

        // Voice Recognition

        private void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            try
            {
                if (RecognizeVoice)
                {
                    // Deactivate Recognition Temporarily
                    recEngine.RecognizeAsyncCancel();
                    recEngine.RecognizeAsyncStop();

                    // Wake Mycroft
                    if (e.Result.Text == "Mycroft" || e.Result.Text == "My Croft")
                        IsAwake();

                    // In Case Jarvis Is Listening
                    if (Wake == true)
                    {
                        if (e.Result.Text.Contains("Open") == true)
                        {
                            // Gets The Full Name & The Location
                            string[] Instant_Apps_Names = Directory.GetFiles(@"Data\Instant Apps List");
                            for (int i = 0; i < Instant_Apps_Names.Length; i++)
                                if (Instant_Apps_Names[i].Contains(e.Result.Text.Replace("Open ", "")) == true)
                                    Process.Start(Instant_Apps_Names[i]);
                        }
                        else
                        {
                            // If Command Is To 'Volume Change' Manually
                            if (e.Result.Text.Contains("Increase Volume To") == true || e.Result.Text.Contains("Decrease Volume To") == true)
                            {
                                VolumeAdjustment.Respond(Convert.ToDouble(e.Result.Text.Substring(e.Result.Text.Length - 2, 2)));
                            }
                            else
                            {
                                switch (e.Result.Text.Replace("Will You", "").Replace("Please", ""))
                                {
                                    // Encryption or Decryption
                                    case "Encrypt Selected Text":
                                        SendKeys.SendWait("^(c)");
                                        Clipboard.SetText(MycroftEncryption.getResult(Clipboard.GetText()));                                        
                                        SendKeys.SendWait("^(v)");
                                        Clipboard.Clear();
                                        break;
                                    case "Decrypt Selected Text":
                                        SendKeys.SendWait("^(c)");
                                        Clipboard.SetText(MycroftDecryption.getResult(Clipboard.GetText()));
                                        SendKeys.SendWait("^(v)");
                                        Clipboard.Clear();
                                        break;
                                    
                                    // Greetings Class
                                    case "Hi":
                                    case "Hello":
                                    case "Hey": Greetings.Respond(); break;
                                    case "Quit":
                                    case "Exit": Application.Exit(); break;

                                    // Get To Know
                                    case "Who Are You": wplayer.URL = @"Data\60.mp3"; wplayer.controls.play(); break;

                                    // Dialog
                                    case "Yes":
                                        Response.Enabled = false;   // Terminate The Abort-Countdown
                                        if (ShutdownPermission == true)
                                            StaticCommands.Shutdown();
                                        if (RestartPermission == true)
                                            StaticCommands.Restart();
                                        break;

                                    // Dialog
                                    case "No":
                                    case "Cancel":
                                        Response.Enabled = false;   // Terminate The Abort-Countdown
                                        if (ShutdownPermission == true)
                                        {
                                            ShutdownPermission = false;
                                            if (File.Exists(@"Data\110.mp3") == true)
                                            {
                                                wplayer.URL = @"Data\110.mp3"; wplayer.controls.play();
                                            }
                                            else Synthesizer.SpeakAsync("Operation Is Canceled"); break;
                                        }
                                        if (RestartPermission == true)
                                        {
                                            RestartPermission = false;
                                            if (File.Exists(@"Data\110.mp3") == true)
                                            {
                                                wplayer.URL = @"Data\110.mp3"; wplayer.controls.play();
                                            }
                                            else Synthesizer.SpeakAsync("Operation Is Canceled"); break;
                                        }
                                        break;

                                    // Time Announcement Class
                                    case "What Time Is It": TimeAnnouncement.Respond(); break;

                                    // Date Announcement Class
                                    case "Which Day Is It":
                                    case "What Date is It": DateAnnouncement.Respond(); break;

                                    // Weather Forcast
                                    case "How Is The Weather":
                                    case "How Is The Weather Today":
                                    case "How Is The Weather For Today":
                                    case "Weather Forcast":
                                    case "Show Weather Forcast":
                                    case "Show Me Weather Forcast":
                                    case "Show Me The Weather Forcast":
                                        WeatherForecast.DesktopLocation = new Point(this.DesktopLocation.X + (this.Width / 2) - (WeatherForecast.Width / 2), this.DesktopLocation.Y + this.Height + 5);
                                        WeatherForecast.ShowDialog(); break;

                                    // Volume Increasement & Decreasement Class
                                    case "Increase Volume": VolumeAdjustment.Volume_Increasement(); break;
                                    case "Decrease Volume": VolumeAdjustment.Volume_Decreasement(); break;
                                    case "Mute Volume": VolumeAdjustment.Volume_Mute(); break;

                                    // Static Commands Class
                                    case "Shutdown The Computer":
                                    case "Power Off":
                                        if (File.Exists(@"Data\111.mp3") == true)
                                        {
                                            wplayer.URL = @"Data\111.mp3"; wplayer.controls.play();
                                        }
                                        else Synthesizer.SpeakAsync("Are You Sure About Shutting Down The Computer?");
                                        ShutdownPermission = true; Response.Enabled = true; break;
                                    case "Restart The Computer":
                                        if (File.Exists(@"Data\112.mp3") == true)
                                        {
                                            wplayer.URL = @"Data\112.mp3"; wplayer.controls.play();
                                        }
                                        else Synthesizer.SpeakAsync("Are You Sure About Restarting Down The Computer?");
                                        RestartPermission = true; Response.Enabled = true; break;
                                    case "Lock The Computer": StaticCommands.LockDown(); break;
                                    case "Abort": StaticCommands.Abort(); break;

                                    // Voice Control
                                    case "Disable Voice Control":
                                    case "Diactivate Voice Control":
                                        label3.ForeColor = Color.Red; Listen.Enabled = false; label3.Text = "Offline"; RecognizeVoice = false;
                                        if (MessageBox.Show("Voice control has been deactivated.\nWould you like me to reboot the Voice Recognition Engine?", "VRE Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                        {
                                            recEngine.RecognizeAsyncCancel(); recEngine.RecognizeAsyncStop();
                                            if (File.Exists(@"Data\114.mp3") == true)
                                            {
                                                wplayer.URL = @"Data\114.mp3"; wplayer.controls.play();
                                            }
                                            else Synthesizer.SpeakAsync("Voice Control Is Now Activated");

                                            // Importing The Dictionary
                                            Choices Commands = CommandsCenter.Commands();
                                            if (Instant_Apps_Loadup() != null)
                                                Commands.Add(Instant_Apps_Loadup());

                                            // Recognition Engine Configurations
                                            GrammarBuilder gBuiler = new GrammarBuilder();
                                            gBuiler.Append(Commands);
                                            Grammar grammer = new Grammar(gBuiler);
                                            recEngine.LoadGrammarAsync(grammer);

                                            label3.ForeColor = Color.Lime; label3.Text = "Online";
                                        }
                                        break;

                                    // Battery Stats Report
                                    case "How Is My Battery Stats":
                                    case "Battery States Report":
                                    case "Battery Stats":
                                        BatteryStatsReport.batteryStatsReport(); break;

                                    // Music Player
                                    case "Play My Favorite Music PlayList":
                                    case "Play My Favorite Playlist":
                                    case "Play My Favorite Music List":
                                        Instant_Musics_Loadup(); break;
                                    case "Add Playlist":
                                    case "Select PlayList":
                                    case "Select Music":
                                        if (PlaylistSelector.ShowDialog() == DialogResult.OK)
                                            MediaPlayer.LoadPlaylist(PlaylistSelector.FileNames); break;
                                    case "Resume": MediaPlayer.PlayPlayList(); break;
                                    case "Pause": MediaPlayer.PausePlayList(); break;
                                    case "Next Track": MediaPlayer.NextTrack(); break;
                                    case "Previous Track": MediaPlayer.PreviousTrack(); break;

                                    // KeyStrokes
                                    case "Enter": SendKeys.Send("{ENTER}"); break;
                                    case "Delete File": SendKeys.SendWait("{DELETE}"); break;
                                    case "Select All": SendKeys.SendWait("^(a)"); break;

                                    // Greetings
                                    case "Thanks":
                                    case "Thank You":
                                        if (File.Exists(@"Data\113.mp3") == true)
                                        {
                                            wplayer.URL = @"Data\113.mp3"; wplayer.controls.play();
                                        }
                                        else Synthesizer.SpeakAsync("It's A Pleasure"); break;

                                    // Security Protocol          
                                    case "Activate Gods Eyes":
                                    case "Activate Monitoring Mode":
                                    case "Turn On Monitoring Mode":
                                    case "Turn Monitoring Mode On":
                                        if (File.Exists(@"Data\61.mp3") == true)
                                        {
                                            wplayer.URL = @"Data\61.mp3"; wplayer.controls.play();
                                        }
                                        else
                                            Synthesizer.SpeakAsync("Activating Monitoring Protocol");
                                        FaceRecognizer.GetFrame(); FaceRecognizer.MonitoringProtocal(FaceRecognizer.PreviousFrame); break;

                                    case "DeActivate Monitoring Mode":
                                    case "Turn Off Monitoring Mode":
                                    case "Turn Monitoring Mode Off":
                                        if (File.Exists(@"Data\62.mp3") == true)
                                        {
                                            wplayer.URL = @"Data\62.mp3"; wplayer.controls.play();
                                        }
                                        else
                                            Synthesizer.SpeakAsync("DeActivating Monitoring Protocol");
                                        FaceRecognizer.MonitoringMode = false; break;
                                }
                            }
                        }
                    }
                    // Recognition Engine Activation Prototype
                    recEngine.RecognizeAsync(RecognizeMode.Multiple);
                }
            }
            catch
            {
                MessageBox.Show("An Error occurred while doing the following operation:\nVoice Recognition\n\nError Info: Confusion by the engine.\nSolution: Restart the application", "Error (Code 102)", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void RecEngine_Controller_Click(object sender, EventArgs e)
        {
            if (RecognizeVoice)
            {
                Listen.Enabled = false;
                RecognizeVoice = false;
                label3.Text = "Offline";
                label3.ForeColor = Color.Red;
            }
            else
            {
                Listen.Enabled = true;
                RecognizeVoice = true;
                label3.Text = "Waiting";
                label3.ForeColor = Color.Yellow;
            }
        }

        private void RecognitionAvtivationPrototype()
        {
            // Recognition Engine Activation Prototype
            try
            {
                recEngine.SetInputToDefaultAudioDevice();
                recEngine.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch
            {
                RecognizeVoice = false;
                label3.Text = "Offline";
                Listen.Enabled = false;
                label3.ForeColor = Color.Red;
                MessageBox.Show("An Error occurred while acessing the following:\nMicrophone\n\nError Info: Cannot configure the microphone.\nSolution: Check whether your microphone is working properly.", "Error (Code 106)", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        // Buttons

        private void Exit_Click(object sender, EventArgs e) => Application.Exit();

        private void Minimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void List_Click(object sender, EventArgs e) => MenuStrip.Show(Cursor.Position.X, Cursor.Position.Y);

        // Movement Functions

        private void Mycroft_MouseUp(object sender, MouseEventArgs e)
        {
            // When Unclicked
            Move = false;
        }

        private void Mycroft_MouseDown(object sender, MouseEventArgs e)
        {
            // When Clicked
            Move = true;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void Mycroft_MouseMove(object sender, MouseEventArgs e)
        {
            // Set Movements
            if (Move == true)
                this.DesktopLocation = new Point(e.X + this.Left - Mouse_X, e.Y + this.Top - Mouse_Y);
        }

        // Menu Strip

        private void FullscreenSnipMenuItem_Click(object sender, EventArgs e)
        {
            // Fullscreen ScreenShot 
            var bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            var bitmapgraph = Graphics.FromImage(bitmap);
            bitmapgraph.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

            SaveFileDialog SaveDialog = new SaveFileDialog();
            SaveDialog.Filter = "JPG | .jpg | PNG | .png";
            SaveDialog.FileName = "Capture";
            SaveDialog.Title = "Save Screenshot";
            if (SaveDialog.ShowDialog() == DialogResult.OK)
                bitmap.Save(SaveDialog.FileName);
        }

        private void RectangularSnipMenuItem_Click(object sender, EventArgs e)
        {
            // Partial ScreenShot
            MycroftRectanguralSnip RS = new MycroftRectanguralSnip();
            RS.ShowDialog();
        }

        private void FacialRecognizerMenuStrip_Click(object sender, EventArgs e)
        {
            // Face Recognizer
            FaceRecognizer.DesktopLocation = new Point(this.DesktopLocation.X + (this.Width / 2) - (FaceRecognizer.Width / 2), this.DesktopLocation.Y + this.Height + 5);
            if (!FaceRecognizer.Visible)
                FaceRecognizer.Visible = true;
            else
                FaceRecognizer.Visible = false;
        }

        private void DashBoardMenuStrip_Click(object sender, EventArgs e)
        {
            MycroftDashBoard DashBoard = new MycroftDashBoard();
            DashBoard.ShowDialog();
        }

        private void WeahterForecast_Click(object sender, EventArgs e)
        {
            MycroftWeatherForecast weatherForecast = new MycroftWeatherForecast();
            weatherForecast.ShowDialog();
        }

        private void NewsFinderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MycroftNewsScraper newsScraper = new MycroftNewsScraper();
            newsScraper.ShowDialog();
        }

        // Timers

        private void Listen_Tick(object sender, EventArgs e)
        {
            // Listen Timer
            Wake = false;
            Listen.Enabled = false;
            label3.Text = "Waiting";
            label3.ForeColor = Color.Yellow;
        }

        private void Response_Tick(object sender, EventArgs e)
        {
            // No Response Terms
            ShutdownPermission = false;
            RestartPermission = false;

            if (File.Exists(@"Data\120.mp3") == true)
            {
                wplayer.URL = @"Data\120.mp3"; wplayer.controls.play();
            }
            else Synthesizer.SpeakAsync("I didn't get any answer, so canceled your request");

            Response.Enabled = false;
        }

        private void Service_Tick(object sender, EventArgs e)
        {
            // Battery Stats Report
            if (Convert.ToString(SystemInformation.PowerStatus.BatteryChargeStatus).ToLower().Contains("charging") == false && (BatteryCharging) == true)
                BatteryStatsReport.UnpluggedStatsReport();
            if (Convert.ToString(SystemInformation.PowerStatus.BatteryChargeStatus).ToLower().Contains("charging") == true && (BatteryCharging) == false)
                BatteryStatsReport.PluggedStatsReport();

            if (Convert.ToString(SystemInformation.PowerStatus.BatteryChargeStatus).ToLower().Contains("charging"))
                BatteryCharging = true;
            else
                BatteryCharging = false;
        }

        // Notify Icon

        private void notifyIcon_BalloonTipClosed(object sender, EventArgs e)
        {
            // Manual Removal Of NotifyIcon Configurations:
            var thisIcon = (NotifyIcon)sender; thisIcon.Visible = false; thisIcon.Dispose();
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            // Resize To Normal:
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            NotifyIcon.Visible = false;
        }
    }
}