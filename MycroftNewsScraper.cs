using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mycroft
{
    public partial class MycroftNewsScraper : Form
    {
        // 3D Rounded-Corners DLL (RunTime-Import):
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public MycroftNewsScraper()
        {
            InitializeComponent();

            // Rounded Corners:
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Headline_Click(object sender, EventArgs e) => Process.Start("https://news.google.com/?hl=en-US&gl=US&ceid=US%3Aen");

        private void Exit_Click(object sender, EventArgs e) => this.Close();

        private void Minimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void TopStories_Fetch()
        {
            RemoveOldHeadlines();

            // Initialize
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            // Download Web Content
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://news.google.com/?hl=en-US&gl=US&ceid=US%3Aen");
            var HeaderNames = doc.DocumentNode.SelectNodes("//h3[@class='ipQwMb ekueJc RD0gLb']").ToList();
            foreach (var item in HeaderNames)
            {
                // Create new Headline Object
                Label Headline = new Label();
                // Headline Object Attributes
                Headline.Parent = panel1;
                Headline.Width = this.Width;
                Headline.Height = 40;
                Headline.Dock = DockStyle.Top;
                Headline.Font = new Font("Cambria", 10, FontStyle.Bold);
                Headline.TextAlign = ContentAlignment.BottomCenter;
                Headline.Cursor = Cursors.Hand;
                // Formatted InnerHTML
                Headline.Text = "\" " + item.InnerText.Replace("#39;", "") + " \"";
                Headline.Click += Headline_Click;
            }
            panel1.Show();
            Cursor.Current = Cursors.Default;
        }

        private void World_Fetch()
        {
            RemoveOldHeadlines();

            // Initialize
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            // Download Web Content
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://news.google.com/topics/CAAqJggKIiBDQkFTRWdvSUwyMHZNRGx1YlY4U0FtVnVHZ0pWVXlnQVAB?hl=en-US&gl=US&ceid=US%3Aen");
            var HeaderNames = doc.DocumentNode.SelectNodes("//h3[@class='ipQwMb ekueJc RD0gLb']").ToList();
            foreach (var item in HeaderNames)
            {
                // Create new Headline Object
                Label Headline = new Label();
                // Headline Object Attributes
                Headline.Parent = panel1;
                Headline.Width = this.Width;
                Headline.Height = 40;
                Headline.Dock = DockStyle.Top;
                Headline.Font = new Font("Cambria", 10, FontStyle.Bold);
                Headline.TextAlign = ContentAlignment.BottomCenter;
                Headline.Cursor = Cursors.Hand;
                // Formatted InnerHTML
                Headline.Text = "\" " + item.InnerText.Replace("#39;", "") + " \"";
                Headline.Click += Headline_Click;
            }
            panel1.Show();
            Cursor.Current = Cursors.Default;
        }

        private void Custom_Fetch()
        {
            RemoveOldHeadlines();            

            // Initialize
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            // Download Web Content
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://news.google.com/search?q=" + textBox2.Text.Trim().ToLower().Replace(" ", "%20") + "&hl=en-US&gl=US&ceid=US%3Aen");
            try
            {
                var HeaderNames = doc.DocumentNode.SelectNodes("//h3[@class='ipQwMb ekueJc RD0gLb']").ToList();
                foreach (var item in HeaderNames)
                {
                    // Create new Headline Object
                    Label Headline = new Label();
                    // Headline Object Attributes
                    Headline.Parent = panel1;
                    Headline.Width = this.Width;
                    Headline.Height = 40;
                    Headline.Dock = DockStyle.Top;
                    Headline.Font = new Font("Cambria", 10, FontStyle.Bold);
                    Headline.TextAlign = ContentAlignment.BottomCenter;
                    Headline.Cursor = Cursors.Hand;
                    // Formatted InnerHTML
                    Headline.Text = "\" " + item.InnerText.Replace("#39;", "") + " \"";
                    Headline.Click += Headline_Click;
                }

                // Adjust Costume Query
                string CustomUrl;
                CustomUrl = textBox2.Text.Trim().ToLower().Replace(" ", "%20");
            }
            catch
            {
                MessageBox.Show("No results were found for this search.\n" + "Error Info: 0 results fetched for the query", "Error (Code 158)", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            panel1.Show();
            Cursor.Current = Cursors.Default;
        }

        private void MostRecent_Fetch()
        {
            // Adjust Costume Query
            textBox2.Text = Database.Default.MostRecentWebSearch.Replace("%20", " ");
            this.Refresh();
            RemoveOldHeadlines();
            // Initialize
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            // Download Web Content
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://news.google.com/search?q=" + Database.Default.MostRecentWebSearch + "&hl=en-US&gl=US&ceid=US%3Aen");
            var HeaderNames = doc.DocumentNode.SelectNodes("//h3[@class='ipQwMb ekueJc RD0gLb']").ToList();
            foreach (var item in HeaderNames)
            {
                // Create new Headline Object
                Label Headline = new Label();
                // Headline Object Attributes
                Headline.Parent = panel1;
                Headline.Width = this.Width;
                Headline.Height = 40;
                Headline.Dock = DockStyle.Top;
                Headline.Font = new Font("Cambria", 10, FontStyle.Bold);
                Headline.TextAlign = ContentAlignment.BottomCenter;
                Headline.Cursor = Cursors.Hand;
                // Formatted InnerHTML
                Headline.Text = "\" " + item.InnerText.Replace("#39;", "") + " \"";
                Headline.Click += Headline_Click;
            }
            panel1.Show();
            Cursor.Current = Cursors.Default;
        }

        private void RemoveOldHeadlines()
        {
            panel1.Hide();
            Cursor.Current = Cursors.WaitCursor;
            for (int i = 0; i < panel1.Controls.Count; i++)
                if (panel1.Controls[i] is Label && panel1.Controls[i] != label1)
                    panel1.Controls.Remove(panel1.Controls[i]);
        }

        private void TopStories_Click(object sender, EventArgs e) => TopStories_Fetch();

        private void World_Click(object sender, EventArgs e) => World_Fetch();
        
        private void MostRecent_Click(object sender, EventArgs e) => MostRecent_Fetch();

        private void Search_Click(object sender, EventArgs e)
        {
            // Save Most Recent Search To Local Database
            Database.Default.MostRecentWebSearch = textBox2.Text.Trim().ToLower().Replace(" ", "%20");
            Database.Default.Save();
            
            //Task.Factory.StartNew(() => Custom_Fetch());
            Custom_Fetch();
        }
    }
}