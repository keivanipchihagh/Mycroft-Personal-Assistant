using System;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.Drawing;
using System.IO;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Mycroft
{
    public partial class MycroftWeatherForecast : Form
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

        // Weather API Key
        private static string API_KEY = Convert.ToString(Database.Default["WeatherAPI"]);

        // Query codes
        private string[] QueryCodes = { "q" };

        // Query URLs. Replace @LOC@ with the location.
        private static string CurrentUrl =
            "http://api.openweathermap.org/data/2.5/weather?" +
            "@QUERY@=" + Database.Default["City"] + "&mode=xml&units=imperial&APPID=" + API_KEY;
        private static string ForecastUrl =
            "http://api.openweathermap.org/data/2.5/forecast?" +
            "@QUERY@=" + Database.Default["City"] + "&mode=xml&units=imperial&APPID=" + API_KEY;

        public MycroftWeatherForecast()
        {
            InitializeComponent();

            // Rounded Corners:
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            if (Convert.ToString(Database.Default["City"]) != string.Empty)
            {
                label1.Text = "Default City: " + (string)Database.Default["City"];
                CustomLocation.Text = (string)Database.Default["City"];
            }
            else
                label1.Text = "Default City: UNKNOWN";
        }

        private void WeatherForcast_Load(object sender, EventArgs e)
        {
            // Load Default Country, City
            CustomLocation.Text = Convert.ToString(Database.Default["City"]);
            QueryCodes[0] = CustomLocation.Text;
        }

        // Get a forecast.
        private void BtnForecast_Click(object sender, EventArgs e)
        {
            // Replace With Costume If Entered
            if (CustomLocation.Text != string.Empty)
            {
                ForecastUrl = "http://api.openweathermap.org/data/2.5/forecast?" + "@QUERY@=" + CustomLocation.Text + "&mode=xml&units=imperial&APPID=" + API_KEY;
                CurrentUrl = "http://api.openweathermap.org/data/2.5/weather?" + "@QUERY@=" + CustomLocation.Text + "&mode=xml&units=imperial&APPID=" + API_KEY;
            }

            // Compose the query URL.
            string url = ForecastUrl;
            url = url.Replace("@QUERY@", "q");

            // Create a web client.
            using (WebClient client = new WebClient())
            {
                // Get the response string from the URL.
                try
                {
                    DisplayForecast(client.DownloadString(url));
                }
                catch (WebException ex)
                {
                    DisplayError(ex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An Error occurred while getting the following:\nWeather Forecast Information\n\nError Info: " + ex.Message.ToString() + ".\nSolution: No solution found. Report the problem.", "Error Code 104", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        // Display the forecast.
        private void DisplayForecast(string xml)
        {
            // Load the response into an XML document.
            XmlDocument xml_doc = new XmlDocument();
            xml_doc.LoadXml(xml);

            // Get the city, country, latitude, and longitude.
            XmlNode loc_node = xml_doc.SelectSingleNode("weatherdata/location");
            txtCity.Text = loc_node.SelectSingleNode("name").InnerText;
            txtCountry.Text = loc_node.SelectSingleNode("country").InnerText;
            XmlNode geo_node = loc_node.SelectSingleNode("location");
            txtLat.Text = geo_node.Attributes["latitude"].Value;
            txtLong.Text = geo_node.Attributes["longitude"].Value;
            txtId.Text = geo_node.Attributes["geobaseid"].Value;

            lvwForecast.Items.Clear();
            char degrees = (char)176;

            foreach (XmlNode time_node in xml_doc.SelectNodes("//time"))
            {
                // Get the time in UTC.
                DateTime time =
                    DateTime.Parse(time_node.Attributes["from"].Value,
                        null, DateTimeStyles.AssumeUniversal);

                // Get the temperature.
                XmlNode temp_node = time_node.SelectSingleNode("temperature");
                string temp = temp_node.Attributes["value"].Value;

                ListViewItem item = lvwForecast.Items.Add(time.DayOfWeek.ToString());
                item.SubItems.Add(time.ToShortTimeString());
                item.SubItems.Add(temp + degrees);
            }
        }

        // Display an error message.
        private void DisplayError(WebException exception)
        {
            try
            {
                StreamReader reader = new StreamReader(exception.Response.GetResponseStream());
                XmlDocument response_doc = new XmlDocument();
                response_doc.LoadXml(reader.ReadToEnd());
                XmlNode message_node = response_doc.SelectSingleNode("//message");
                MessageBox.Show(message_node.InnerText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occurred while getting the following:\nWeather Forecast Information\n\nError Info: " + ex.Message.ToString() + ".\nSolution: No solution found. Report the problem.", "Error Code 104", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            // Exit Thread
            this.Close();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://openweathermap.org/appid#get");
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
