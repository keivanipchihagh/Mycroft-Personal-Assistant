using System.IO;

namespace Mycroft
{
    class MycroftRemoveDirectory
    {
        public void RemoveDirectory()
        {
            // Removes The Folder 'TrainedFaces' and all the files(.btm) inside:
            if ((Directory.Exists("TrainedFaces")))
            {
                string[] files = Directory.GetFiles("TrainedFaces");
                string[] dirs = Directory.GetDirectories("TrainedFaces");
                foreach (string file in files)
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }
                foreach (string dir in dirs)
                    Directory.Delete(dir);
                File.CreateText(@"TrainedFaces/TrainedLabels.txt");
            }
            else
            {
                Directory.CreateDirectory("TrainedFaces");
                File.CreateText(@"TrainedFaces/TrainedLabels.txt");
            }
        }
    }
}
