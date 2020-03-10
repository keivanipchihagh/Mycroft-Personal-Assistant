using System;
using System.IO;
using System.Speech.Synthesis;

namespace Mycroft
{
    class MycroftTimeAnnouncement
    {
        // Speech Synthesizer Engine Constructor:
        SpeechSynthesizer Synthesizer = new SpeechSynthesizer();

        // MediaPlayer Library:
        static WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

        // PlayList Object:
        WMPLib.IWMPPlaylist PlayList = wplayer.newPlaylist("My playlist", "");

        public void Respond()
        {
            // Hour:
            int HourFormat;
            switch (DateTime.Now.Hour)
            {
                case 13: HourFormat = 1; break;
                case 14: HourFormat = 2; break;
                case 15: HourFormat = 3; break;
                case 16: HourFormat = 4; break;
                case 17: HourFormat = 5; break;
                case 18: HourFormat = 6; break;
                case 19: HourFormat = 7; break;
                case 20: HourFormat = 8; break;
                case 21: HourFormat = 9; break;
                case 22: HourFormat = 10; break;
                case 23: HourFormat = 11; break;
                default: HourFormat = DateTime.Now.Hour; break;
            }

            // Hour:
            if (File.Exists(@"Data\Numerics\Numerics (" + HourFormat + ").mp3") == true && File.Exists(@"Data\Numerics\Numerics (" + DateTime.Now.Minute + ").mp3") == true && (File.Exists(@"Data\121.mp3") == true))
            {
                PlayList.appendItem(wplayer.newMedia(@"Data\121.mp3"));
                PlayList.appendItem(wplayer.newMedia(@"Data\Numerics\Numerics (" + HourFormat + ").mp3"));
                PlayList.appendItem(wplayer.newMedia(@"Data\Numerics\Numerics (" + DateTime.Now.Minute + ").mp3"));
                wplayer.currentPlaylist = PlayList;
            }
            else Synthesizer.SpeakAsync("It's " + HourFormat + " , " + DateTime.Now.Minute);
        }
    }
}