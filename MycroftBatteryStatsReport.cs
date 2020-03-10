using System;
using System.IO;
using System.Speech.Synthesis;
using System.Windows.Forms;


namespace Mycroft
{
    class MycroftBatteryStatsReport
    {
        // Speech Synthesizer Engine Constructor:
        SpeechSynthesizer Synthesizer = new SpeechSynthesizer();

        // MediaPlayer Library:
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

        // Variables:
        bool FileFound = false;

        public void UnpluggedStatsReport()
        {
            // Local PlayList:
            var PlayList = wplayer.newPlaylist("My playlist", "");

            if (File.Exists(@"Data\64.mp3") == true && File.Exists(@"Data\65.mp3") == true)
            {
                PlayList.appendItem(wplayer.newMedia(@"Data\64.mp3"));

                for (int i = 1; i <= 100; i++)
                {
                    if (i == (SystemInformation.PowerStatus.BatteryLifePercent * 100) && File.Exists(@"Data\Numerics\Numerics (" + i + ").mp3") == true)
                    {
                        PlayList.appendItem(wplayer.newMedia(@"Data\Numerics\Numerics (" + i + ").mp3"));
                        PlayList.appendItem(wplayer.newMedia(@"Data\65.mp3"));
                        FileFound = true;
                        break;
                    }
                }
            }
            else
                FileFound = false;

            if (!FileFound)
                Synthesizer.SpeakAsync("The Device Has Been Unplugged From The Charger. You Have " + (100 - (SystemInformation.PowerStatus.BatteryLifePercent * 100) + "Percent Battery Life Remaining"));
            else
            {
                wplayer.currentPlaylist = PlayList;
                wplayer.controls.play();
            }
        }

        public void PluggedStatsReport()
        {
            // Local PlayList:
            var PlayList = wplayer.newPlaylist("My playlist", "");

            if (File.Exists(@"Data\115.mp3") == true)
            {
                PlayList.appendItem(wplayer.newMedia(@"Data\115.mp3"));

                for (int i = 1; i <= 100; i++)
                {
                    if (i == (SystemInformation.PowerStatus.BatteryLifePercent * 100) && File.Exists(@"Data\Numerics\Numerics (" + i + ").mp3") == true)
                    {
                        PlayList.appendItem(wplayer.newMedia(@"Data\Numerics\Numerics (" + (100 - i) + ").mp3"));
                        PlayList.appendItem(wplayer.newMedia(@"Data\116.mp3"));
                        FileFound = true;
                        break;
                    }
                }
            }
            else
                FileFound = false;

            if (!FileFound)
                Synthesizer.SpeakAsync("The Device Is Now Set To Charged.");
            else
            {
                wplayer.currentPlaylist = PlayList;
                wplayer.controls.play();
            }
        }

        public void batteryStatsReport()
        {
            // Local PlayList:
            var PlayList = wplayer.newPlaylist("My playlist", "");

            // Calculate Remaining Battery Stats
            string StatsReport = Convert.ToString(SystemInformation.PowerStatus.BatteryLifePercent).Remove(0, 2);

            // Charging Stats:
            if (Convert.ToString(SystemInformation.PowerStatus.BatteryChargeStatus).ToLower().Contains("charging"))
            {
                if (File.Exists(@"Data\119.mp3") && File.Exists(@"Data\65.mp3"))
                {
                    PlayList.appendItem(wplayer.newMedia(@"Data\119.mp3"));

                    // Adding Numerics:
                    for (int i = 1; i <= 100; i++)
                        if (i == Convert.ToInt32(StatsReport) && File.Exists(@"Data\Numerics\Numerics (" + i + ").mp3") == true)
                        {
                            PlayList.appendItem(wplayer.newMedia(@"Data\Numerics\Numerics (" + i + ").mp3"));
                            break;
                        }

                    PlayList.appendItem(wplayer.newMedia(@"Data\65.mp3"));
                    wplayer.currentPlaylist = PlayList;
                    wplayer.controls.play();
                }
                else
                    Synthesizer.SpeakAsync("The Device Is Currently Being Charged, And You Have " + StatsReport + "Percent Battery Life Remaining");
            }
            else
            {
                if (File.Exists(@"Data\118.mp3") && File.Exists(@"Data\65.mp3"))
                {
                    PlayList.appendItem(wplayer.newMedia(@"Data\118.mp3"));

                    // Adding Numerics:
                    for (int i = 1; i <= 100; i++)
                        if (i == Convert.ToInt32(StatsReport) && File.Exists(@"Data\Numerics\Numerics (" + i + ").mp3") == true)
                        {
                            PlayList.appendItem(wplayer.newMedia(@"Data\Numerics\Numerics (" + i + ").mp3"));
                            break;
                        }

                    PlayList.appendItem(wplayer.newMedia(@"Data\65.mp3"));
                    wplayer.currentPlaylist = PlayList;
                    wplayer.controls.play();
                }
                else
                    Synthesizer.SpeakAsync("The Device Is Currently Not Being Charged, And You Have " + StatsReport + "Percent Battery Life Remaining");
            }
        }
    }
}
