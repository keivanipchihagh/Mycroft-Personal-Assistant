using System.IO;
using System.Speech.Synthesis;

namespace Mycroft
{
    class MycroftMediaPlayerControls
    {
        // MediaPlayer Library:
        static WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        // PlayList Object:
        WMPLib.IWMPPlaylist PlayList = wplayer.newPlaylist("My playlist", "");
        // Classess, Engines, Contructors:
        SpeechSynthesizer Synthesizer = new SpeechSynthesizer();

        public void LoadPlaylist(string[] List)
        {
            if (List.Length != 0)
            {
                // Load & Initialize Playlist:
                foreach (string Item in List)
                    PlayList.appendItem(wplayer.newMedia(Item));

                // Load Playlist (Automatically Played):
                wplayer.currentPlaylist = PlayList;
            }
            else
            {
                if (File.Exists(@"Data\122.mp3") == true)
                {
                    wplayer.URL = @"Data\122.mp3"; wplayer.controls.play();
                }
                else Synthesizer.SpeakAsync("Sir, you do not have any favorite playlist at the time.");
            }
        }

        public void PlayPlayList()
        {
            wplayer.controls.play();
        }

        public void PausePlayList()
        {
            // Pause The Current Track:
            wplayer.controls.pause();
        }

        public void NextTrack()
        {
            // Goes To Next Track In Order:
            wplayer.controls.next();
        }

        public void PreviousTrack()
        {
            // Goes To Previous Track In Order:
            wplayer.controls.previous();
        }
    }
}
