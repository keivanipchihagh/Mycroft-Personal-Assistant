using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.IO;

namespace Mycroft
{
    class MycroftStaticCommands
    {
        [DllImport("user32")]
        public static extern void LockWorkStation();

        // Objects & Constructors:
        SpeechSynthesizer Synthesizer = new SpeechSynthesizer();
        // MediaPlayer Library For Mp3 File Playing:
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

        // Random Respond Options:
        Random Random = new Random();

        public void Shutdown()
        {
            // Shutdown:
            switch (Random.Next(0, 3))
            {
                case 0:
                    if (File.Exists(@"Data\35.mp3") == true)
                    {
                        wplayer.URL = @"Data\35.mp3"; wplayer.controls.play();
                    }
                    else Synthesizer.SpeakAsync("Shutting Down Your Computer In T Mines 30 Seconds"); break;
                case 1:
                    if (File.Exists(@"Data\36.mp3") == true)
                    {
                        wplayer.URL = @"Data\36.mp3"; wplayer.controls.play();
                    }
                    else Synthesizer.SpeakAsync("Shutdown Countdown Started. 30 Seconds To sequence Shutdown"); break;
                case 2:
                    if (File.Exists(@"Data\37.mp3") == true)
                    {
                        wplayer.URL = @"Data\37.mp3"; wplayer.controls.play();
                    }
                    else Synthesizer.SpeakAsync("Your Computer Will Be Shutted Down In T Mines 30 seconds"); break;
            }
            Process.Start("shutdown", "/s /t 30");
        }

        public void Restart()
        {
            // Restart:
            switch (Random.Next(0, 3))
            {
                case 0:
                    if (File.Exists(@"Data\38.mp3") == true)
                    {
                        wplayer.URL = @"Data\38.mp3"; wplayer.controls.play();
                    }
                    else Synthesizer.Speak("Restarting Your Computer In T Mines 30 Seconds"); break;
                case 1:
                    if (File.Exists(@"Data\39.mp3") == true)
                    {
                        wplayer.URL = @"Data\39.mp3"; wplayer.controls.play();
                    }
                    else Synthesizer.Speak("Restart Countdown Started. 30 Seconds Left"); break;
                case 2:
                    if (File.Exists(@"Data\40.mp3") == true)
                    {
                        wplayer.URL = @"Data\40.mp3"; wplayer.controls.play();
                    }
                    else Synthesizer.Speak("Your Computer Will Be Restarted In T Mines 30 seconds"); break;
            }
            Process.Start("shutdown", "/r /t 30");
        }

        public void LockDown()
        {
            // LockDown:
            switch (Random.Next(0, 2))
            {
                case 0:
                    if (File.Exists(@"Data\42.mp3") == true)
                    {
                        wplayer.URL = @"Data\42.mp3"; wplayer.controls.play();
                    }
                    else Synthesizer.SpeakAsync("Your Computer Has Been LockedDown"); break;
                case 1:
                    if (File.Exists(@"Data\41.mp3") == true)
                    {
                        wplayer.URL = @"Data\41.mp3"; wplayer.controls.play();
                    }
                    else Synthesizer.SpeakAsync("Done"); break;
                case 2:
                    if (File.Exists(@"Data\43.mp3") == true)
                    {
                        wplayer.URL = @"Data\43.mp3"; wplayer.controls.play();
                    }
                    else Synthesizer.SpeakAsync("Roger That"); break;
            }
            LockWorkStation();
        }

        public void Abort()
        {
            // Abort:
            Process.Start("shutdown", "/a");
            switch (Random.Next(0, 2))
            {
                case 0:
                    if (File.Exists(@"Data\44.mp3") == true)
                    {
                        wplayer.URL = @"Data\44.mp3"; wplayer.controls.play();
                    }
                    else Synthesizer.SpeakAsync("Shutdown Sequence Aborted"); break;
                case 1:
                    if (File.Exists(@"Data\45.mp3") == true)
                    {
                        wplayer.URL = @"Data\45.mp3"; wplayer.controls.play();
                    }
                    else Synthesizer.SpeakAsync("Shutdown Sequence Canceled"); break;
            }
        }
    }
}
