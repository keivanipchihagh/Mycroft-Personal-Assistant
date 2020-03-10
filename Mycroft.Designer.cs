namespace Mycroft
{
    partial class Mycroft
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mycroft));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.RecEngine_Controller = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Exit = new System.Windows.Forms.Panel();
            this.Minimize = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.List = new System.Windows.Forms.Panel();
            this.MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.FacialRecognizerMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.DashBoardMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.WeahterForecast = new System.Windows.Forms.ToolStripMenuItem();
            this.newsFinderStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.snippingToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FullscreenSnipMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RectangularSnipMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Listen = new System.Windows.Forms.Timer(this.components);
            this.Response = new System.Windows.Forms.Timer(this.components);
            this.PlaylistSelector = new System.Windows.Forms.OpenFileDialog();
            this.Service = new System.Windows.Forms.Timer(this.components);
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TabControlTitleName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RecEngine_Controller)).BeginInit();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.panel1.Location = new System.Drawing.Point(257, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 17);
            this.panel1.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label3.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(200, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 31;
            this.label3.Text = "Waiting";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(264, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 16);
            this.label5.TabIndex = 32;
            this.label5.Text = "FR:";
            this.toolTip.SetToolTip(this.label5, "Face Recognition");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(290, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 33;
            this.label6.Text = "Offline";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label2.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(175, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 16);
            this.label2.TabIndex = 30;
            this.label2.Text = "VR:";
            this.toolTip.SetToolTip(this.label2, "Voice Recognition");
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.panel2.Location = new System.Drawing.Point(171, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 17);
            this.panel2.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(59, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "Systems:";
            this.toolTip.SetToolTip(this.label4, "Systems");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Lime;
            this.label7.Location = new System.Drawing.Point(118, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 16);
            this.label7.TabIndex = 28;
            this.label7.Text = "Online";
            // 
            // RecEngine_Controller
            // 
            this.RecEngine_Controller.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RecEngine_Controller.Image = ((System.Drawing.Image)(resources.GetObject("RecEngine_Controller.Image")));
            this.RecEngine_Controller.Location = new System.Drawing.Point(3, 4);
            this.RecEngine_Controller.Name = "RecEngine_Controller";
            this.RecEngine_Controller.Size = new System.Drawing.Size(50, 50);
            this.RecEngine_Controller.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RecEngine_Controller.TabIndex = 35;
            this.RecEngine_Controller.TabStop = false;
            this.toolTip.SetToolTip(this.RecEngine_Controller, "Turn Voice Recognition On/Off");
            this.RecEngine_Controller.Click += new System.EventHandler(this.RecEngine_Controller_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel3.Location = new System.Drawing.Point(62, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(90, 25);
            this.panel3.TabIndex = 37;
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Black;
            this.Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Exit.BackgroundImage")));
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit.Location = new System.Drawing.Point(326, 9);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(12, 12);
            this.Exit.TabIndex = 38;
            this.toolTip.SetToolTip(this.Exit, "Exit");
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Minimize
            // 
            this.Minimize.BackColor = System.Drawing.Color.Black;
            this.Minimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Minimize.BackgroundImage")));
            this.Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Minimize.Location = new System.Drawing.Point(308, 9);
            this.Minimize.Name = "Minimize";
            this.Minimize.Size = new System.Drawing.Size(12, 12);
            this.Minimize.TabIndex = 39;
            this.toolTip.SetToolTip(this.Minimize, "Minimize");
            this.Minimize.Click += new System.EventHandler(this.Minimize_Click);
            // 
            // List
            // 
            this.List.BackColor = System.Drawing.Color.Black;
            this.List.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("List.BackgroundImage")));
            this.List.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.List.Cursor = System.Windows.Forms.Cursors.Hand;
            this.List.Location = new System.Drawing.Point(286, 8);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(14, 14);
            this.List.TabIndex = 40;
            this.toolTip.SetToolTip(this.List, "List");
            this.List.Click += new System.EventHandler(this.List_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FacialRecognizerMenuStrip,
            this.DashBoardMenuStrip,
            this.WeahterForecast,
            this.newsFinderStripMenuItem,
            this.toolStripSeparator1,
            this.toolBoxToolStripMenuItem});
            this.MenuStrip.Name = "contextMenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(194, 130);
            // 
            // FacialRecognizerMenuStrip
            // 
            this.FacialRecognizerMenuStrip.Name = "FacialRecognizerMenuStrip";
            this.FacialRecognizerMenuStrip.Size = new System.Drawing.Size(210, 24);
            this.FacialRecognizerMenuStrip.Text = "Facial Recognizer";
            this.FacialRecognizerMenuStrip.Click += new System.EventHandler(this.FacialRecognizerMenuStrip_Click);
            // 
            // DashBoardMenuStrip
            // 
            this.DashBoardMenuStrip.Name = "DashBoardMenuStrip";
            this.DashBoardMenuStrip.Size = new System.Drawing.Size(210, 24);
            this.DashBoardMenuStrip.Text = "DashBoard";
            this.DashBoardMenuStrip.Click += new System.EventHandler(this.DashBoardMenuStrip_Click);
            // 
            // WeahterForecast
            // 
            this.WeahterForecast.Name = "WeahterForecast";
            this.WeahterForecast.Size = new System.Drawing.Size(210, 24);
            this.WeahterForecast.Text = "Weahter Forecast";
            this.WeahterForecast.Click += new System.EventHandler(this.WeahterForecast_Click);
            // 
            // newsFinderStripMenuItem
            // 
            this.newsFinderStripMenuItem.Name = "newsFinderStripMenuItem";
            this.newsFinderStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.newsFinderStripMenuItem.Text = "News Finder";
            this.newsFinderStripMenuItem.Click += new System.EventHandler(this.NewsFinderToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // toolBoxToolStripMenuItem
            // 
            this.toolBoxToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.snippingToolMenuItem});
            this.toolBoxToolStripMenuItem.Name = "toolBoxToolStripMenuItem";
            this.toolBoxToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.toolBoxToolStripMenuItem.Text = "ToolBox";
            // 
            // snippingToolMenuItem
            // 
            this.snippingToolMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FullscreenSnipMenuItem,
            this.RectangularSnipMenuItem});
            this.snippingToolMenuItem.Name = "snippingToolMenuItem";
            this.snippingToolMenuItem.Size = new System.Drawing.Size(224, 26);
            this.snippingToolMenuItem.Text = "Snipping Tool";
            // 
            // FullscreenSnipMenuItem
            // 
            this.FullscreenSnipMenuItem.Name = "FullscreenSnipMenuItem";
            this.FullscreenSnipMenuItem.Size = new System.Drawing.Size(224, 26);
            this.FullscreenSnipMenuItem.Text = "Fullscreen Snip";
            this.FullscreenSnipMenuItem.Click += new System.EventHandler(this.FullscreenSnipMenuItem_Click);
            // 
            // RectangularSnipMenuItem
            // 
            this.RectangularSnipMenuItem.Name = "RectangularSnipMenuItem";
            this.RectangularSnipMenuItem.Size = new System.Drawing.Size(224, 26);
            this.RectangularSnipMenuItem.Text = "Rectangular Snip";
            this.RectangularSnipMenuItem.Click += new System.EventHandler(this.RectangularSnipMenuItem_Click);
            // 
            // Listen
            // 
            this.Listen.Enabled = true;
            this.Listen.Interval = 10000;
            this.Listen.Tick += new System.EventHandler(this.Listen_Tick);
            // 
            // Response
            // 
            this.Response.Interval = 10000;
            this.Response.Tick += new System.EventHandler(this.Response_Tick);
            // 
            // PlaylistSelector
            // 
            this.PlaylistSelector.FileName = "PlaylistSelector";
            this.PlaylistSelector.Filter = "Mp3 File (.mp3) | *.mp3";
            this.PlaylistSelector.Multiselect = true;
            // 
            // Service
            // 
            this.Service.Enabled = true;
            this.Service.Interval = 1000;
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.NotifyIcon.BalloonTipText = "Running In System Tray";
            this.NotifyIcon.BalloonTipTitle = "Mycroft AI";
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "Mycroft AI";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.BalloonTipClosed += new System.EventHandler(this.notifyIcon_BalloonTipClosed);
            this.NotifyIcon.Click += new System.EventHandler(this.NotifyIcon_Click);
            // 
            // TabControlTitleName
            // 
            this.TabControlTitleName.AutoSize = true;
            this.TabControlTitleName.Font = new System.Drawing.Font("Segoe UI Semibold", 5F, System.Drawing.FontStyle.Bold);
            this.TabControlTitleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(157)))), ((int)(((byte)(174)))));
            this.TabControlTitleName.Location = new System.Drawing.Point(154, 15);
            this.TabControlTitleName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TabControlTitleName.Name = "TabControlTitleName";
            this.TabControlTitleName.Size = new System.Drawing.Size(77, 12);
            this.TabControlTitleName.TabIndex = 175;
            this.TabControlTitleName.Text = "Personal Assistant";
            this.TabControlTitleName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mycroft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(352, 60);
            this.Controls.Add(this.TabControlTitleName);
            this.Controls.Add(this.List);
            this.Controls.Add(this.Minimize);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.RecEngine_Controller);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Mycroft";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Mycroft AI";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Mycroft_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mycroft_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mycroft_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Mycroft_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.RecEngine_Controller)).EndInit();
            this.MenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.PictureBox RecEngine_Controller;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel Exit;
        private System.Windows.Forms.Panel Minimize;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel List;
        private System.Windows.Forms.ContextMenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem DashBoardMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FacialRecognizerMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem snippingToolMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FullscreenSnipMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RectangularSnipMenuItem;
        public System.Windows.Forms.Timer Listen;
        private System.Windows.Forms.Timer Response;
        private System.Windows.Forms.OpenFileDialog PlaylistSelector;
        private System.Windows.Forms.Timer Service;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem WeahterForecast;
        public System.Windows.Forms.Label TabControlTitleName;
        private System.Windows.Forms.ToolStripMenuItem newsFinderStripMenuItem;
    }
}