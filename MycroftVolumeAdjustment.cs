using AudioSwitcher.AudioApi.CoreAudio;
using System;
using System.Speech.Synthesis;
using System.IO;

namespace Mycroft
{
    class MycroftVolumeAdjustment
    {
        // Speech Synthesizer Engine Constructor:
        SpeechSynthesizer Synthesizer = new SpeechSynthesizer();

        // MediaPlayer Library:
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

        // Random Respond Options:
        Random Random = new Random();

        // Set Custome Volume:
        public void Respond(double Value)
        {
            CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
            defaultPlaybackDevice.Volume = Value;
            Volume_Announcement(Value); // Announcement
        }

        // Increase Volume Automatic:
        public void Volume_Increasement()
        {
            switch (Random.Next(0, 2))
            {
                case 0:
                    if (File.Exists(@"Data\46.mp3") == true)
                    {
                        wplayer.URL = @"Data\46.mp3"; wplayer.controls.play();
                    }
                    else Synthesizer.SpeakAsync("Done"); break;
                case 1:
                    if (File.Exists(@"Data\47.mp3") == true)
                    {
                        wplayer.URL = @"Data\47.mp3"; wplayer.controls.play();
                    }
                    else Synthesizer.SpeakAsync("Okay"); break;
            }
            CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
            defaultPlaybackDevice.Volume += 20;

            Volume_Announcement(defaultPlaybackDevice.Volume); // Announcement
        }

        // Decrease Volume Automatic:
        public void Volume_Decreasement()
        {
            switch (Random.Next(0, 2))
            {
                case 0:
                    if (File.Exists(@"Data\46.mp3") == true)
                    {
                        wplayer.URL = @"Data\46.mp3"; wplayer.controls.play();
                    }
                    else Synthesizer.SpeakAsync("Done"); break;
                case 1:
                    if (File.Exists(@"Data\47.mp3") == true)
                    {
                        wplayer.URL = @"Data\47.mp3"; wplayer.controls.play();
                    }
                    else Synthesizer.SpeakAsync("Okay"); break;
            }
            CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
            defaultPlaybackDevice.Volume -= 20;

            Volume_Announcement(defaultPlaybackDevice.Volume); // Announcement
        }

        // Mute Volume:
        public void Volume_Mute()
        {
            CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
            defaultPlaybackDevice.Volume = 0;
        }

        // Announcing The Current Costume Volume:
        public void Volume_Announcement(double Value)
        {
            // Local PlayList:
            var PlayList = wplayer.newPlaylist("My playlist", "");

            if (File.Exists(@"Data\46.mp3") == true)
            {
                PlayList.appendItem(wplayer.newMedia(@"Data\46.mp3"));

                for (int i = 1; i <= 100; i++)
                {
                    if (i == Value && File.Exists(@"Data\Numerics\Numerics (" + i + ").mp3") == true)
                    {
                        PlayList.appendItem(wplayer.newMedia(@"Data\Numerics\Numerics (" + i + ").mp3"));
                        PlayList.appendItem(wplayer.newMedia(@"Data\47.mp3"));
                        wplayer.currentPlaylist = PlayList;
                        wplayer.controls.play();
                        break;
                    }
                }
            }
            else
                Synthesizer.SpeakAsync("Current Volume Level Is Now " + Value + " Percent");
        }
    }
}