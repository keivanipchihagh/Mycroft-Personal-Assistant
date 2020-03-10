namespace Mycroft
{
    class MycroftDecryption
    {

        public string getResult(string text)
        {
            string primaryResult = "";
            string key = "xpmH7kn6c&b6R6_=aE6Y*&&NC6s-cH76JFL7KmN$ZBZutRa36aY&3dY&*^%F@rncg37qN4KpTv_mW7+C!NznmgMR7umjSu2bX?2s4z$UFygZ6T=E$Akmc8yguBURjAxu";
            int KeyLength = 0;
            for (int i = 0; i < text.Length; i++)
            {
                primaryResult += (char)(text[i] - key[KeyLength]);
                KeyLength++;
                if (KeyLength == key.Length)
                    KeyLength = 0;
            }

            string secondaryResult = "";
            for (int i = 0; i < primaryResult.Length; i++)
                secondaryResult += (char)(primaryResult[i] - (i % 10));

            return secondaryResult;
        }
    }
}
