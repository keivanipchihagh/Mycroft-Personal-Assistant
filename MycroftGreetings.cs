using System;
using System.Speech.Synthesis;
using System.IO;

namespace Mycroft
{
    class MycroftGreetings
    {
        // Speech Synthesizer Engine Constructor:
        SpeechSynthesizer Synthesizer = new SpeechSynthesizer();

        // MediaPlayer Library:
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

        // Random Respond Options:
        Random Random = new Random();

        public void Respond()
        {
            string Sentence = "", Question = "";

            // Local PlayList:
            var PlayList = wplayer.newPlaylist("My playlist", "");

            switch (Random.Next(0, 7))
            {
                case 0:
                    if (File.Exists(@"Data\1.mp3") == true)
                        PlayList.appendItem(wplayer.newMedia(@"Data\1.mp3"));
                    else Sentence = "Hello"; break;
                case 1:
                    if (File.Exists(@"Data\4.mp3") == true)
                        PlayList.appendItem(wplayer.newMedia(@"Data\4.mp3"));
                    else Sentence = "Hi"; break;
                case 2:
                    if (File.Exists(@"Data\5.mp3") == true)
                        PlayList.appendItem(wplayer.newMedia(@"Data\5.mp3"));
                    else Sentence = "Hello There"; break;
                case 3:
                    if (File.Exists(@"Data\6.mp3") == true)
                        PlayList.appendItem(wplayer.newMedia(@"Data\6.mp3"));
                    else Sentence = "Hi There"; break;
                case 4:
                    if (File.Exists(@"Data\7.mp3") == true)
                        PlayList.appendItem(wplayer.newMedia(@"Data\7.mp3"));
                    else Sentence = "Greetings"; break;
                case 5:
                    if (File.Exists(@"Data\8.mp3") == true)
                        PlayList.appendItem(wplayer.newMedia(@"Data\8.mp3"));
                    else Sentence = "Hey there"; break;
                case 6:
                    if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour < 12)
                    {
                        if (File.Exists(@"Data\9.mp3") == true)
                            PlayList.appendItem(wplayer.newMedia(@"Data\9.mp3"));
                        else Sentence = "Good Morning";
                    }
                    else
                    {
                        if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 5)
                        {
                            if (File.Exists(@"Data\10.mp3") == true)
                                PlayList.appendItem(wplayer.newMedia(@"Data\10.mp3"));
                            else Sentence = "Good Afternoon";
                        }
                        else
                        {
                            if (DateTime.Now.Hour >= 5 && DateTime.Now.Hour <= 9)
                            {
                                if (File.Exists(@"Data\11.mp3") == true)
                                    PlayList.appendItem(wplayer.newMedia(@"Data\11.mp3"));
                                else Sentence = "Good Evening";
                            }
                            else
                            {
                                if (DateTime.Now.Hour >= 9 && DateTime.Now.Hour < 12)
                                {
                                    if (File.Exists(@"Data\12.mp3") == true)
                                        PlayList.appendItem(wplayer.newMedia(@"Data\12.mp3"));
                                    else Sentence = "Good Night";
                                }
                            }
                        }
                    }
                    break;
            }

            switch (Random.Next(0, 6))
            {
                case 0:
                    if (File.Exists(@"Data\13.mp3") == true)
                        PlayList.appendItem(wplayer.newMedia(@"Data\13.mp3"));
                    else Question = "How are you today"; break;
                case 1:
                    if (File.Exists(@"Data\14.mp3") == true)
                        PlayList.appendItem(wplayer.newMedia(@"Data\14.mp3"));
                    else Question = "How are things"; break;
                case 2:
                    if (File.Exists(@"Data\15.mp3") == true)
                        PlayList.appendItem(wplayer.newMedia(@"Data\15.mp3"));
                    else Question = "What’s new"; break;
                case 3:
                    if (File.Exists(@"Data\16.mp3") == true)
                        PlayList.appendItem(wplayer.newMedia(@"Data\16.mp3"));
                    else Question = "What’s up"; break;
                case 4:
                    if (File.Exists(@"Data\17.mp3") == true)
                        PlayList.appendItem(wplayer.newMedia(@"Data\17.mp3"));
                    else Question = "What's On Your Mind"; break;
                case 5:
                    if (File.Exists(@"Data\18.mp3") == true)
                        PlayList.appendItem(wplayer.newMedia(@"Data\18.mp3"));
                    else Question = "What Do You Have In Your Mind"; break;
            }

            if (Sentence == string.Empty || Question == string.Empty)
            {
                wplayer.currentPlaylist = PlayList;
                wplayer.controls.play();
            }
            else
                Synthesizer.SpeakAsync(Sentence + ". " + Question);
        }
    }
}
