using System.Speech.Recognition;

namespace Mycroft
{
    class MycroftCommandCenter
    {
        public Choices Commands()
        {
            // Numbers
            Choices Numerics = new Choices(new string[] {
                "1" , "2" , "3" , "4" , "5" , "6" , "7" , "8" , "9" , "10" ,
                "11" , "12" , "13" , "14" , "15" , "16" , "17" , "18" , "19" , "20" ,
                "21" , "22" , "23" , "24" , "25" , "26" , "27" , "28" , "29" , "30" ,
                "31" , "32" , "33" , "34" , "35" , "36" , "37" , "38" , "39" , "40" ,
                "41" , "42" , "43" , "44" , "45" , "46" , "47" , "48" , "49" , "50" ,
                "51" , "52" , "53" , "54" , "55" , "56" , "57" , "58" , "59" , "60" ,
                "61" , "62" , "63" , "64" , "65" , "66" , "67" , "68" , "69" , "70" ,
                "71" , "72" , "73" , "74" , "75" , "76" , "77" , "78" , "79" , "80" ,
                "81" , "82" , "83" , "84" , "85" , "86" , "87" , "88" , "89" , "90" ,
                "91" , "92" , "93" , "94" , "95" , "96" , "97" , "98" , "99" , "100" ,
            });

            // Volume & Numerics Combination:
            GrammarBuilder Volume_Increasement_Element = new GrammarBuilder("Increase Volume To ");
            Volume_Increasement_Element.Append(Numerics);
            GrammarBuilder Volume_Decreasement_Element = new GrammarBuilder("Decrease Volume To ");
            Volume_Decreasement_Element.Append(Numerics);

            Choices Volume = new Choices(Volume_Increasement_Element, Volume_Decreasement_Element, "Increase Volume", "Decrease Volume");
            Choices Call_In = new Choices(new string[] { "Hi", "Hello", "Hey", "Mycroft", "My Croft", "Quit", "Exit", "Who Are You" });
            Choices Date_Time = new Choices(new string[] { "What Time Is It", "Which Day Is It", "What Date Is It" });
            Choices Weather = new Choices(new string[] { "How Is The Weather", "How Is The Weather Today", "How Is The Weather For Today", "Weather Forcast", "Show Weather Forcast", "Show Me Weather Forcast", "Show Me The Weather Forcast", "Show The Weather Forcast" });
            Choices Static_Commands = new Choices(new string[] { "Shutdown The Computer", "Power Off", "Abort", "Restart The Computer", "Lock The Computer" });
            Choices Music_Control = new Choices(new string[] { "Select Music", "Add Playlist", "Select PlayList", "Resume", "Pause", "Next Track", "Previous Track", "Resume", "Play My Favorite Music PlayList", "Play My Favorite Playlist", "Play My Favorite Music List" });
            Choices KeyStrokes = new Choices(new string[] { "Select All", "Delete File", "Enter" });
            Choices Conversation = new Choices(new string[] { "Yes", "No", "Cancel" });
            Choices Power_Control = new Choices(new string[] { "How Is My Battery Stats", "Battery States Report", "Battery Stats" });
            Choices Voice_Control = new Choices(new string[] { "Diactivate Voice Control", "Disable Voice Control" });
            Choices Appriciation = new Choices(new string[] { "Thanks", "Thank You" });
            Choices Security_Protocol = new Choices(new string[] { "Activate Gods Eyes", "Activate Monitoring Mode", "Turn On Monitoring Mode", "Turn Monitoring Mode On", "DeActivate Monitoring Mode", "Turn Off Monitoring Mode", "Turn Monitoring Mode Off" });
            Choices EncryptionOrDycryption_Protocal = new Choices(new string[] { "Encrypt Selected Text", "Decrypt Selected Text" });
            Choices Dictionary = new Choices(new GrammarBuilder[] { EncryptionOrDycryption_Protocal, Music_Control, Power_Control, Voice_Control, Conversation, Call_In, Static_Commands, Security_Protocol, Volume, Date_Time, Weather, KeyStrokes, Appriciation });

            // Output
            return Dictionary;
        }
    }
}
