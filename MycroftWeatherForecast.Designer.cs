namespace Mycroft
{
    partial class MycroftWeatherForecast
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MycroftWeatherForecast));
            this.btnForecast = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.lvwForecast = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Minimize = new System.Windows.Forms.Panel();
            this.Exit = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.CustomLocation = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtLong = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txtId = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnForecast
            // 
            this.btnForecast.AutoSize = true;
            this.btnForecast.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnForecast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnForecast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnForecast.FlatAppearance.BorderSize = 0;
            this.btnForecast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForecast.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.btnForecast.ForeColor = System.Drawing.Color.Black;
            this.btnForecast.Location = new System.Drawing.Point(354, 122);
            this.btnForecast.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnForecast.Name = "btnForecast";
            this.btnForecast.Size = new System.Drawing.Size(71, 26);
            this.btnForecast.TabIndex = 169;
            this.btnForecast.Text = "Forecast";
            this.btnForecast.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnForecast.UseVisualStyleBackColor = false;
            this.btnForecast.Click += new System.EventHandler(this.BtnForecast_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(5, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 9, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 16);
            this.label2.TabIndex = 171;
            this.label2.Text = "Custom City Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(36, 378);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 16);
            this.label7.TabIndex = 167;
            this.label7.Text = "ID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(36, 306);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 165;
            this.label5.Text = "Longtitude:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(36, 232);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 161;
            this.label4.Text = "Country:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(36, 268);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 159;
            this.label3.Text = "City:";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Temperature";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 105;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Time";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 105;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Day";
            this.columnHeader1.Width = 105;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(36, 341);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 163;
            this.label6.Text = "Latitude:";
            // 
            // lvwForecast
            // 
            this.lvwForecast.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvwForecast.AllowColumnReorder = true;
            this.lvwForecast.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwForecast.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.lvwForecast.FullRowSelect = true;
            this.lvwForecast.GridLines = true;
            this.lvwForecast.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwForecast.HideSelection = false;
            this.lvwForecast.Location = new System.Drawing.Point(449, 76);
            this.lvwForecast.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.lvwForecast.MultiSelect = false;
            this.lvwForecast.Name = "lvwForecast";
            this.lvwForecast.Size = new System.Drawing.Size(341, 360);
            this.lvwForecast.TabIndex = 158;
            this.lvwForecast.UseCompatibleStateImageBehavior = false;
            this.lvwForecast.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(5, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 9, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 176;
            this.label1.Text = "Default City:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(7, 419);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(253, 16);
            this.label8.TabIndex = 177;
            this.label8.Text = "Get an API for weather forecast in here:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(259, 418);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(176, 16);
            this.linkLabel1.TabIndex = 178;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.openweathermap.org";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.Minimize);
            this.panel1.Controls.Add(this.Exit);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 69);
            this.panel1.TabIndex = 179;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(153)))), ((int)(((byte)(186)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 67);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(800, 2);
            this.panel4.TabIndex = 184;
            // 
            // Minimize
            // 
            this.Minimize.BackColor = System.Drawing.Color.Transparent;
            this.Minimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Minimize.BackgroundImage")));
            this.Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Minimize.Location = new System.Drawing.Point(713, 15);
            this.Minimize.Name = "Minimize";
            this.Minimize.Size = new System.Drawing.Size(30, 30);
            this.Minimize.TabIndex = 183;
            this.Minimize.Click += new System.EventHandler(this.Minimize_Click);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Exit.BackgroundImage")));
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit.Location = new System.Drawing.Point(755, 16);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(30, 30);
            this.Exit.TabIndex = 182;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(157)))), ((int)(((byte)(174)))));
            this.label9.Location = new System.Drawing.Point(204, 35);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 20);
            this.label9.TabIndex = 174;
            this.label9.Text = "Weather Forecast";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel6.BackgroundImage")));
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel6.Location = new System.Drawing.Point(13, 9);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(190, 50);
            this.panel6.TabIndex = 39;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(153)))), ((int)(((byte)(186)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 448);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(800, 2);
            this.panel7.TabIndex = 186;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(5, 199);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 9, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(156, 16);
            this.label10.TabIndex = 187;
            this.label10.Text = "Location Configuration:";
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.White;
            this.panel16.Location = new System.Drawing.Point(130, 145);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(217, 1);
            this.panel16.TabIndex = 214;
            // 
            // CustomLocation
            // 
            this.CustomLocation.BackColor = System.Drawing.Color.Black;
            this.CustomLocation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CustomLocation.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.CustomLocation.ForeColor = System.Drawing.Color.White;
            this.CustomLocation.Location = new System.Drawing.Point(130, 119);
            this.CustomLocation.MaxLength = 30;
            this.CustomLocation.Name = "CustomLocation";
            this.CustomLocation.Size = new System.Drawing.Size(217, 20);
            this.CustomLocation.TabIndex = 213;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(130, 254);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(217, 1);
            this.panel2.TabIndex = 216;
            // 
            // txtCountry
            // 
            this.txtCountry.BackColor = System.Drawing.Color.Black;
            this.txtCountry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCountry.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtCountry.ForeColor = System.Drawing.Color.White;
            this.txtCountry.Location = new System.Drawing.Point(130, 228);
            this.txtCountry.MaxLength = 30;
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(217, 20);
            this.txtCountry.TabIndex = 215;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(130, 290);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(217, 1);
            this.panel3.TabIndex = 218;
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.Color.Black;
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCity.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtCity.ForeColor = System.Drawing.Color.White;
            this.txtCity.Location = new System.Drawing.Point(130, 264);
            this.txtCity.MaxLength = 30;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(217, 20);
            this.txtCity.TabIndex = 217;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(130, 328);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(217, 1);
            this.panel5.TabIndex = 220;
            // 
            // txtLong
            // 
            this.txtLong.BackColor = System.Drawing.Color.Black;
            this.txtLong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLong.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtLong.ForeColor = System.Drawing.Color.White;
            this.txtLong.Location = new System.Drawing.Point(130, 302);
            this.txtLong.MaxLength = 30;
            this.txtLong.Name = "txtLong";
            this.txtLong.Size = new System.Drawing.Size(217, 20);
            this.txtLong.TabIndex = 219;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Location = new System.Drawing.Point(130, 363);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(217, 1);
            this.panel8.TabIndex = 222;
            // 
            // txtLat
            // 
            this.txtLat.BackColor = System.Drawing.Color.Black;
            this.txtLat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLat.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtLat.ForeColor = System.Drawing.Color.White;
            this.txtLat.Location = new System.Drawing.Point(130, 337);
            this.txtLat.MaxLength = 30;
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(217, 20);
            this.txtLat.TabIndex = 221;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Location = new System.Drawing.Point(130, 400);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(217, 1);
            this.panel9.TabIndex = 224;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.Black;
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtId.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtId.ForeColor = System.Drawing.Color.White;
            this.txtId.Location = new System.Drawing.Point(130, 374);
            this.txtId.MaxLength = 30;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(217, 20);
            this.txtId.TabIndex = 223;
            // 
            // MycroftWeatherForecast
            // 
            this.AcceptButton = this.btnForecast;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.txtLat);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.txtLong);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.panel16);
            this.Controls.Add(this.CustomLocation);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnForecast);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lvwForecast);
            this.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MycroftWeatherForecast";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mycroft Weather Forecast";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnForecast;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lvwForecast;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel Minimize;
        private System.Windows.Forms.Panel Exit;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.TextBox CustomLocation;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtLong;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox txtId;
    }
}