using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Mycroft
{
    public partial class MycroftDashBoard : Form
    {
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

        //Declararation of all variables, vectors and haarcascades
        Image<Bgr, Byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> NamePersons = new List<string>();
        List<string> Announced_Names = new List<string>();
        private int CountTrain, t;
        private string name;
        private bool Grabbing_Frames = true;

        // Objects & Constructors:
        MycroftRemoveDirectory RemoveDirectory = new MycroftRemoveDirectory();
        MycroftCommandCenter CommandCenter = new MycroftCommandCenter();

        public MycroftDashBoard()
        {
            InitializeComponent();

            // Rounded Corners
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            // Initialize UserInformation Panel
            UserInformation.Dock = DockStyle.Fill;
            UserInformation.Visible = true;
            Favorites.Visible = false;
            FaceTrainer.Visible = false;
            SecurityProtocols.Visible = false;
            ShellCommands.Visible = false;

            // Initialize Primary Inputs
            TextBox1.Text = Database.Default.Firstname;
            TextBox2.Text = Database.Default.Lastname;
            if (Database.Default.Gender == "Male")
                radioButton1.Checked = true;
            else if (Database.Default.Gender == "Female")
                radioButton2.Checked = true;
            TextBox3.Text = Database.Default.Email;
            TextBox4.Text = Database.Default.Username;
            TextBox5.Text = Database.Default.Password;
            TextBox6.Text = Database.Default.Password;
            TextBox7.Text = Database.Default.Country;
            TextBox9.Text = Database.Default.City;
            TextBox10.Text = Database.Default.WeatherAPI;

            // User Image
            if (File.Exists(@"Data\User Image\User_Image.PNG"))
                UserImage.Image = Image.FromFile(@"Data\User Image\User_Image.PNG");

            if (TextBox2.Text == string.Empty)
                panel9.BackColor = Color.Red;
            else
                panel9.BackColor = Color.White;
            if (TextBox1.Text == string.Empty)
                panel16.BackColor = Color.Red;
            else
                panel16.BackColor = Color.White;
            if (TextBox3.Text == string.Empty)
                panel8.BackColor = Color.Red;
            else
                panel8.BackColor = Color.White;
            if (TextBox4.Text == string.Empty)
                panel11.BackColor = Color.Red;
            else
                panel11.BackColor = Color.White;
            if (TextBox5.Text != TextBox6.Text || TextBox5.Text == string.Empty)
                panel10.BackColor = Color.Red;
            else
            {
                panel10.BackColor = Color.White;
                panel12.BackColor = Color.White;
            }
            if (TextBox5.Text != TextBox6.Text || TextBox6.Text == string.Empty)
                panel12.BackColor = Color.Red;
            else
            {
                panel12.BackColor = Color.White;
                panel10.BackColor = Color.White;
            }
            if (TextBox7.Text == string.Empty)
                panel14.BackColor = Color.Red;
            else
                panel14.BackColor = Color.White;
            if (TextBox9.Text == string.Empty)
                panel15.BackColor = Color.Red;
            else
                panel15.BackColor = Color.White;
            if (TextBox10.Text == string.Empty)
                panel30.BackColor = Color.Red;
            else
                panel30.BackColor = Color.White;
        }

        private void MycroftDashBoard_Load(object sender, EventArgs e)
        {
            //Load Haarcascades For Face Detection:
            face = new HaarCascade("haarcascade_frontalface_default.xml");

            try
            {
                //Load Previous trained Faces & Labels For Each Image:
                string[] Labels = File.ReadAllText("TrainedFaces/TrainedLabels.txt").Split('%');

                // Extact Number Of Previous Trained Faces:
                CountTrain = Convert.ToInt32(Labels[0]);
                string LoadFaces;

                for (int i = 1; i < CountTrain + 1; i++)
                {
                    LoadFaces = "face" + i + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[i]);
                }
            }
            catch
            {
                // Remove Directory And Subfolders:
                RemoveDirectory.RemoveDirectory();
            }

            //Initialize The Capture Device (Only One Device Is To Be Found):
            try
            {
                grabber = new Capture();
                grabber.QueryFrame();

                //Initialize The FrameGraber Event:
                Application.Idle += new EventHandler(FrameGrabber);
            }
            catch
            {
                MessageBox.Show("It seems your machine does not have a webcam, or your webcam is not set to use. Make sure your webcam is running properly.\n" +
                    "If you are still facing this problem, contact the support team for more information.", "No Webcam Detected", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                Grabbing_Frames = false;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure about resetting all your information?\nThis action will remove all the trained faces as well.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Database.Default.Firstname = string.Empty;
                Database.Default.Lastname = string.Empty;
                Database.Default.Email = string.Empty;
                Database.Default.Country = string.Empty;
                Database.Default.City = string.Empty;
                Database.Default.WeatherAPI = string.Empty;
                Database.Default.Gender = string.Empty;
                Database.Default.Username = string.Empty;
                Database.Default.Password = string.Empty;
                Database.Default.Monitoring_Sensitivity = 80;
                Database.Default.RecognizeFace = true;
                for (int i = 0; i < this.Controls.Count; i++)
                    if (this.Controls[i] is TextBox)
                        this.Controls[i].Text = string.Empty;

                for (int i = 0; i < UserInformation.Controls.Count; i++)
                    if (UserInformation.Controls[i] is TextBox)
                        UserInformation.Controls[i].Text = string.Empty;

                Database.Default.Save();
            }
        }

        // User Information

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult Result = MessageBox.Show("In order to use weather forecast services, you need an API Key. Get a free Key By Signing at \"openweathermap.org\". From there, copy the auto-generated API Key and paste it here.\nWould you like me to take you to the website?", "Help", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (Result == DialogResult.Yes)
                Process.Start("https://home.openweathermap.org/users/sign_in");
        }

        private void AddImage_Click(object sender, EventArgs e)
        {
            // Add User Image:            
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                // Remove User Ex-Image:            
                ImageRemoval();

                if (!Directory.Exists(@"Data\User Image"))
                    Directory.CreateDirectory(@"Data\User Image");

                if (!File.Exists(@"Data\User Image\User_Image.PNG"))
                    File.Copy(OFD.FileName, @"Data\User Image\User_Image.PNG", true);

                UserImage.Image = new Bitmap(OFD.FileName);
            }
        }

        private void RemoveImage_Click(object sender, EventArgs e)
        {
            // Remove User Image:            
            ImageRemoval();
        }

        private void ImageRemoval()
        {
            // Ex-Image Removal Fnction:
            try
            {
                if ((Directory.Exists(@"Data\User Image")))
                {
                    string[] files = Directory.GetFiles(@"Data\User Image");
                    foreach (string file in files)
                    {
                        File.SetAttributes(file, FileAttributes.Normal);
                        File.Delete(file);
                    }
                }
                else
                {
                    Directory.CreateDirectory(@"Data\User Image");
                    File.Copy(OFD.FileName, @"Data\User Image\User_Image.PNG", true);
                }
                Directory.CreateDirectory(@"Data\User Image");
                UserImage.Image = null;
            }
            catch
            {

                if (MessageBox.Show("An Error occured while removing following:\nUser Image.\n\nError Info: Unauthorized attempt to make changes in hard disk.\nSolution: I can open the directory for manual removal. Do you authorize that?", "Error (Code 101)", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    this.WindowState = FormWindowState.Minimized;
                    Process.Start(@"Data\User Image");
                }
            }
        }

        private void SaveUserInformation_Click(object sender, EventArgs e)
        {
            // Save
            if (TextBox5.Text == TextBox6.Text)
            {
                Database.Default.Firstname = TextBox1.Text;
                Database.Default.Lastname = TextBox2.Text;
                Database.Default.Email = TextBox3.Text;
                Database.Default.Username = TextBox4.Text;
                Database.Default.Password = TextBox5.Text;
                Database.Default.Country = TextBox7.Text;
                Database.Default.City = TextBox9.Text;
                Database.Default.WeatherAPI = TextBox10.Text;
                if (radioButton1.Checked)
                    Database.Default.Gender = "Male";
                else
                    Database.Default.Gender = "Female";

                Database.Default.Save();
                MessageBox.Show("All changes applied successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
                MessageBox.Show("Confirmation password does not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        // Buttons List

        private void UserInformationButton_Click(object sender, EventArgs e)
        {
            // Disable Other Panels
            Hide_FaceTrainer();
            Hide_Favorites();
            Hide_ShellCommands();
            Hide_SecurityProtocols();

            // Enable Targeted Panel
            Show_UserInformation();
        }

        private void FaceTrainerButton_Click(object sender, EventArgs e)
        {
            // Disable Other Panels
            Hide_UserInformation();
            Hide_Favorites();
            Hide_SecurityProtocols();
            Hide_ShellCommands();

            // Enable Targeted Panel
            Show_FaceTrainer();
        }

        private void FavoritesButton_Click(object sender, EventArgs e)
        {
            // Disable Other Panels
            Hide_UserInformation();
            Hide_FaceTrainer();
            Hide_ShellCommands();
            Hide_SecurityProtocols();

            // Enable Targeted Panel
            Show_Favorites();
        }

        private void ShellCommandsButton_Click(object sender, EventArgs e)
        {
            // Disable Other Panels
            Hide_UserInformation();
            Hide_FaceTrainer();
            Hide_Favorites();
            Hide_SecurityProtocols();

            // Enable Targeted Panel
            Show_ShellCommands();
        }

        private void SecurityProtocolsButton_Click(object sender, EventArgs e)
        {
            // Disable Other Panels
            Hide_UserInformation();
            Hide_FaceTrainer();
            Hide_Favorites();
            Hide_ShellCommands();

            // Enable Targeted Panel
            Show_SecurityProtocols();
        }

        // Face Trainer

        private void FrameGrabber(object sender, EventArgs e)
        {
            if (Grabbing_Frames == true)
            {
                label26.Text = "0";
                NamePersons.Add("");
                //Get The Current Frame Form Capture Device:
                currentFrame = grabber.QueryFrame().Resize(385, 317, INTER.CV_INTER_CUBIC);
                //Convert It To Grayscale:
                gray = currentFrame.Convert<Gray, Byte>();
                //Face Detector:
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(face, 1.2, 10, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));

                // Focus On The imagebox:
                Add_Face_ID_Click.Enabled = false;

                //Action For Each Element Detected:
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    // Focus On The Button:
                    Add_Face_ID_Click.Enabled = true;
                    Add_Face_ID_Click.Focus();

                    t = t + 1;
                    result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(180, 180, INTER.CV_INTER_CUBIC);
                    //Draw The Face detected In The 0th (Gray) Channel With Blue Color:
                    currentFrame.Draw(f.rect, new Bgr(Color.Blue), 2);

                    if (trainingImages.ToArray().Length != 0)
                    {
                        //TermCriteria For Face Recognition With Numbers Of Trained Images Like MaxIteration:
                        MCvTermCriteria termCrit = new MCvTermCriteria(CountTrain, 0.001);

                        //Eigen Face Recognizer:
                        EigenObjectRecognizer recognizer = new EigenObjectRecognizer(trainingImages.ToArray(), labels.ToArray(), 3000, ref termCrit);                        

                        name = recognizer.Recognize(result);
                        //Draw The Label For Each Face Detected And Recognized:
                        currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.Blue));
                    }
                    NamePersons[t - 1] = name;
                    NamePersons.Add("");

                    //Set The Number Of Faces Detected On The Screen:
                    label26.Text = Convert.ToString(facesDetected[0].Length);

                    TrainerTextBox.Focus();
                }
                t = 0;

                //Names Concatenation Of Peaple Recognized:
                label44.Text = string.Empty;
                for (int i = 0; i < facesDetected[0].Length; i++)
                {
                    bool Exists = false;
                    for (int j = 0; j < Announced_Names.Count; j++)
                        if (Announced_Names[j] == NamePersons[i])
                            Exists = true;

                    if (Exists == false)
                    {
                        Announced_Names.Add(NamePersons[i]);
                    }

                    label44.Text += NamePersons[i] + " , ";
                }
                //Show the faces procesed and recognized
                imageBox1.Image = currentFrame;
                //Clear the list(vector) of names
                NamePersons.Clear();
            }
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Add_Face_ID_Click_Click(object sender, EventArgs e)
        {
            if (TrainerTextBox.Text != string.Empty)
            {
                try
                {
                    //Trained face counter
                    CountTrain++;
                    //Get A Gray Frame From The Capture Device
                    gray = grabber.QueryGrayFrame().Resize(385, 317, INTER.CV_INTER_CUBIC);
                    //Face Detector:
                    MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(face, 1.2, 10, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));

                    //Action For Each Element Detected
                    foreach (MCvAvgComp f in facesDetected[0])
                    {
                        TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                        break;
                    }

                    //Resize The Detected Image In Order To Force The Application To Compare The Same Size With The Test Image With Cubic Interpolation Type Method:
                    TrainedFace = result.Resize(180, 180, INTER.CV_INTER_CUBIC);
                    trainingImages.Add(TrainedFace);
                    labels.Add(TrainerTextBox.Text);
                    //Show Face Added In Gray Scale:
                    imageBox2.Image = TrainedFace;
                    //Write The Number Of Triained Faces In A Text File For Further Loads:
                    File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", Convert.ToString(trainingImages.ToArray().Length) + "%");
                    //Write The Labels Of Each Triained Faces In A Text File For Further Loads:
                    for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                    {
                        trainingImages.ToArray()[i - 1].Save("TrainedFaces/face" + i + ".bmp");
                        File.AppendAllText("TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                    }
                    MessageBox.Show(TrainerTextBox.Text + "'s face was scanned and saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    TrainerTextBox.Text = string.Empty;
                    imageBox2.Image = null;
                }
                catch
                {
                    MessageBox.Show("An Error occurred while scanning your face.\n\nError Info: Face could not be detected.\nSolution: Change location and lighting.", "Error (Code 105)", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
                MessageBox.Show("Set your name in order to continue.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        // Security Protocol

        private void Sensitivity_ScrollBar_Scroll(object sender, EventArgs e)
        {
            // Adjust Sensitivity Using A Scroll:
            ScrollBarValue.Text = "value: " + Convert.ToString(Sensitivity_ScrollBar.Value);
            Database.Default["MonitoringSensitivity"] = Sensitivity_ScrollBar.Value;
            Database.Default.Save();
        }

        // Visual

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (TextBox2.Text == string.Empty)
                panel9.BackColor = Color.Red;
            else
                panel9.BackColor = Color.White;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextBox1.Text == string.Empty)
                panel16.BackColor = Color.Red;
            else
                panel16.BackColor = Color.White;
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (TextBox3.Text == string.Empty)
                panel8.BackColor = Color.Red;
            else
                panel8.BackColor = Color.White;

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (TextBox4.Text == string.Empty)
                panel11.BackColor = Color.Red;
            else
                panel11.BackColor = Color.White;
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            if (TextBox5.Text != TextBox6.Text || TextBox5.Text == string.Empty)
                panel10.BackColor = Color.Red;
            else
            {
                panel10.BackColor = Color.White;
                panel12.BackColor = Color.White;
            }
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            if (TextBox5.Text != TextBox6.Text || TextBox6.Text == string.Empty)
                panel12.BackColor = Color.Red;
            else
            {
                panel12.BackColor = Color.White;
                panel10.BackColor = Color.White;
            }
        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {
            if (TextBox7.Text == string.Empty)
                panel14.BackColor = Color.Red;
            else
                panel14.BackColor = Color.White;
        }

        private void TextBox9_TextChanged(object sender, EventArgs e)
        {
            if (TextBox9.Text == string.Empty)
                panel15.BackColor = Color.Red;
            else
                panel15.BackColor = Color.White;
        }

        private void TextBox10_TextChanged(object sender, EventArgs e)
        {
            if (TextBox10.Text == string.Empty)
                panel30.BackColor = Color.Red;
            else
                panel30.BackColor = Color.White;
        }

        public void Show_UserInformation()
        {
            UserInformation.Dock = DockStyle.Fill;
            UserInformation.Visible = true;
            SectionName.Text = "Section: User Information";
        }

        public void Hide_UserInformation()
        {
            UserInformation.Dock = DockStyle.None;
            UserInformation.Visible = false;
            UserInformation.Size = Size.Empty;
        }

        public void Show_FaceTrainer()
        {
            FaceTrainer.Dock = DockStyle.Fill;
            FaceTrainer.Visible = true;
            SectionName.Text = "Section: Face Trainer";
        }

        public void Hide_FaceTrainer()
        {
            FaceTrainer.Dock = DockStyle.None;
            FaceTrainer.Visible = false;
            FaceTrainer.Size = Size.Empty;
        }

        public void Show_Favorites()
        {
            Favorites.Dock = DockStyle.Fill;
            Favorites.Visible = true;
            SectionName.Text = "Section: Favorites";

            // User's Favorite Apps, Music List:
            if (!Directory.Exists(@"Data\Favorite Music List"))
                Directory.CreateDirectory(@"Data\Favorite Music List");
            if (!Directory.Exists(@"Data\Instant Apps List"))
                Directory.CreateDirectory(@"Data\Instant Apps List");

            FavMusicAddress.Text = Application.StartupPath + @"\Data\Favorite Music List";
            FavAppsAddress.Text = Application.StartupPath + @"\Data\Instant Apps List";
        }

        public void Hide_Favorites()
        {
            Favorites.Dock = DockStyle.None;
            Favorites.Visible = false;
            Favorites.Size = Size.Empty;
        }

        public void Show_ShellCommands()
        {
            ShellCommands.Dock = DockStyle.Fill;
            ShellCommands.Visible = true;
            SectionName.Text = "Section: Shell Commands";

            // Shell Commands Setup
            int Command_Count = 0;
            string[] Commands = CommandCenter.Commands().ToGrammarBuilder().DebugShowPhrases.Replace("[", "").Replace("]", "").Split(',');
            CommandList.Items.Clear();
            foreach (string Item in Commands)
            {
                try
                {
                    int Int_Records = Convert.ToInt32(Item.Substring(1, Item.Length - 2));
                }
                catch
                {
                    if (Item.Contains("Increase Volume To"))
                        CommandList.Items.Add("'Increase Volume To [1-100]'");
                    else if (Item.Contains("Decrease Volume To"))
                        CommandList.Items.Add("'Decrease Volume To [1-100]'");
                    else
                        CommandList.Items.Add(Item);
                    Command_Count++;
                }
            }
            ShellCommandsCount.Text = "Number Of Commands: " + Convert.ToString(Command_Count);
        }

        public void Hide_ShellCommands()
        {
            ShellCommands.Dock = DockStyle.None;
            ShellCommands.Visible = false;
            ShellCommands.Size = Size.Empty;
        }

        private void LinkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult Result = MessageBox.Show("In order to use weather forecast services, you need an API Key. Get a free Key By Signing at \"openweathermap.org\". From there, copy the auto-generated API Key and paste it here.\nWould you like me to take you to the website?", "Help", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (Result == DialogResult.Yes)
                Process.Start("https://home.openweathermap.org/users/sign_in");
        }

        public void Show_SecurityProtocols()
        {
            SecurityProtocols.Dock = DockStyle.Fill;
            SecurityProtocols.Visible = true;
            SectionName.Text = "Section: Security Protocol";

            // Monitoring Mode ScrollBar Value Setup
            Sensitivity_ScrollBar.Value = Database.Default.Monitoring_Sensitivity;
            ScrollBarValue.Text = "Value: " + Convert.ToString(Database.Default.Monitoring_Sensitivity);
        }

        public void Hide_SecurityProtocols()
        {
            SecurityProtocols.Dock = DockStyle.None;
            SecurityProtocols.Visible = false;
            SecurityProtocols.Size = Size.Empty;
        }
    }
}
