using System;
using System.Speech.Synthesis;
using System.IO;

namespace Mycroft
{
    class MycroftDateAnnouncement
    {
        // Speech Synthesizer Engine Constructor:
        SpeechSynthesizer Synthesizer = new SpeechSynthesizer();

        // MediaPlayer Library:
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

        public void Respond()
        {
            bool VoiceExists = true;

            // Local PlayList:
            var PlayList = wplayer.newPlaylist("My playlist", "");

            // Day:
            switch (DateTime.Now.Day)
            {
                case 1:
                    if (File.Exists(@"Data\66.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\66.mp3"));
                    else
                        VoiceExists = false; break;
                case 2:
                    if (File.Exists(@"Data\67.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\67.mp3"));
                    else
                        VoiceExists = false; break;
                case 3:
                    if (File.Exists(@"Data\68.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\68.mp3"));
                    else
                        VoiceExists = false; break;
                case 4:
                    if (File.Exists(@"Data\69.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\69.mp3"));
                    else
                        VoiceExists = false; break;
                case 5:
                    if (File.Exists(@"Data\70.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\70.mp3"));
                    else
                        VoiceExists = false; break;
                case 6:
                    if (File.Exists(@"Data\71.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\71.mp3"));
                    else
                        VoiceExists = false; break;
                case 7:
                    if (File.Exists(@"Data\72.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\72.mp3"));
                    else
                        VoiceExists = false; break;
                case 8:
                    if (File.Exists(@"Data\73.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\73.mp3"));
                    else
                        VoiceExists = false; break;
                case 9:
                    if (File.Exists(@"Data\74.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\74.mp3"));
                    else
                        VoiceExists = false; break;
                case 10:
                    if (File.Exists(@"Data\75.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\75.mp3"));
                    else
                        VoiceExists = false; break;
                case 11:
                    if (File.Exists(@"Data\76.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\76.mp3"));
                    else
                        VoiceExists = false; break;
                case 12:
                    if (File.Exists(@"Data\77.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\77.mp3"));
                    else
                        VoiceExists = false; break;
                case 13:
                    if (File.Exists(@"Data\78.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\78.mp3"));
                    else
                        VoiceExists = false; break;
                case 14:
                    if (File.Exists(@"Data\79.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\79.mp3"));
                    else
                        VoiceExists = false; break;
                case 15:
                    if (File.Exists(@"Data\80.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\80.mp3"));
                    else
                        VoiceExists = false; break;
                case 16:
                    if (File.Exists(@"Data\81.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\81.mp3"));
                    else
                        VoiceExists = false; break;
                case 17:
                    if (File.Exists(@"Data\82.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\82.mp3"));
                    else
                        VoiceExists = false; break;
                case 18:
                    if (File.Exists(@"Data\83.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\83.mp3"));
                    else
                        VoiceExists = false; break;
                case 19:
                    if (File.Exists(@"Data\84.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\84.mp3"));
                    else
                        VoiceExists = false; break;
                case 20:
                    if (File.Exists(@"Data\85.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\85.mp3"));
                    else
                        VoiceExists = false; break;
                case 21:
                    if (File.Exists(@"Data\86.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\86.mp3"));
                    else
                        VoiceExists = false; break;
                case 22:
                    if (File.Exists(@"Data\87.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\87.mp3"));
                    else
                        VoiceExists = false; break;
                case 23:
                    if (File.Exists(@"Data\88.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\88.mp3"));
                    else
                        VoiceExists = false; break;
                case 24:
                    if (File.Exists(@"Data\89.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\89.mp3"));
                    else
                        VoiceExists = false; break;
                case 25:
                    if (File.Exists(@"Data\90.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\90.mp3"));
                    else
                        VoiceExists = false; break;
                case 26:
                    if (File.Exists(@"Data\91.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\91.mp3"));
                    else
                        VoiceExists = false; break;
                case 27:
                    if (File.Exists(@"Data\92.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\92.mp3"));
                    else
                        VoiceExists = false; break;
                case 28:
                    if (File.Exists(@"Data\93.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\93.mp3"));
                    else
                        VoiceExists = false; break;
                case 29:
                    if (File.Exists(@"Data\94.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\66.mp3"));
                    else
                        VoiceExists = false; break;
                case 30:
                    if (File.Exists(@"Data\95.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\95.mp3"));
                    else
                        VoiceExists = false; break;
                case 31:
                    if (File.Exists(@"Data\96.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\96.mp3"));
                    else
                        VoiceExists = false; break;
            }

            // Month:
            switch (DateTime.Now.Month)
            {
                case 1:
                    if (File.Exists(@"Data\97.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\97.mp3"));
                    else
                        VoiceExists = false; break;
                case 2:
                    if (File.Exists(@"Data\98.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\98.mp3"));
                    else
                        VoiceExists = false; break;
                case 3:
                    if (File.Exists(@"Data\99.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\99.mp3"));
                    else
                        VoiceExists = false; break;
                case 4:
                    if (File.Exists(@"Data\100.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\100.mp3"));
                    else
                        VoiceExists = false; break;
                case 5:
                    if (File.Exists(@"Data\101.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\101.mp3"));
                    else
                        VoiceExists = false; break;
                case 6:
                    if (File.Exists(@"Data\102.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\102.mp3"));
                    else
                        VoiceExists = false; break;
                case 7:
                    if (File.Exists(@"Data\103.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\103.mp3"));
                    else
                        VoiceExists = false; break;
                case 8:
                    if (File.Exists(@"Data\104.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\104.mp3"));
                    else
                        VoiceExists = false; break;
                case 9:
                    if (File.Exists(@"Data\105.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\105.mp3"));
                    else
                        VoiceExists = false; break;
                case 10:
                    if (File.Exists(@"Data\106.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\106.mp3"));
                    else
                        VoiceExists = false; break;
                case 11:
                    if (File.Exists(@"Data\107.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\107.mp3"));
                    else
                        VoiceExists = false; break;
                case 12:
                    if (File.Exists(@"Data\108.mp3"))
                        PlayList.appendItem(wplayer.newMedia(@"Data\108.mp3"));
                    else
                        VoiceExists = false; break;
            }

            if (!VoiceExists)
                switch (DateTime.Now.Month)
                {
                    case 1: Synthesizer.SpeakAsync("It's " + DateTime.Now.Day + "Of January " + DateTime.Now.Year); break;
                    case 2: Synthesizer.SpeakAsync("It's " + DateTime.Now.Day + "Of February " + DateTime.Now.Year); break;
                    case 3: Synthesizer.SpeakAsync("It's " + DateTime.Now.Day + "Of March " + DateTime.Now.Year); break;
                    case 4: Synthesizer.SpeakAsync("It's " + DateTime.Now.Day + "Of April " + DateTime.Now.Year); break;
                    case 5: Synthesizer.SpeakAsync("It's " + DateTime.Now.Day + "Of May " + DateTime.Now.Year); break;
                    case 6: Synthesizer.SpeakAsync("It's " + DateTime.Now.Day + "Of June " + DateTime.Now.Year); break;
                    case 7: Synthesizer.SpeakAsync("It's " + DateTime.Now.Day + "Of July " + DateTime.Now.Year); break;
                    case 8: Synthesizer.SpeakAsync("It's " + DateTime.Now.Day + "Of August " + DateTime.Now.Year); break;
                    case 9: Synthesizer.SpeakAsync("It's " + DateTime.Now.Day + "Of September " + DateTime.Now.Year); break;
                    case 10: Synthesizer.SpeakAsync("It's " + DateTime.Now.Day + "Of October " + DateTime.Now.Year); break;
                    case 11: Synthesizer.SpeakAsync("It's " + DateTime.Now.Day + "Of November " + DateTime.Now.Year); break;
                    case 12: Synthesizer.SpeakAsync("It's " + DateTime.Now.Day + "Of December " + DateTime.Now.Year); break;
                }
            else
            {
                wplayer.currentPlaylist = PlayList;
                wplayer.controls.play();
            }
        }
    }
}
