using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WpfApp1
{
    public class ScannGames
    {

        public  List<string> files = new List<string>();

        public  List<string> GetFiles
        {
            get { return files; }
            set { files = value; }
        }

        public ScannGames() { }

        public  void scanner()
        {
            foreach (DriveInfo d in DriveInfo.GetDrives().Where(x => x.IsReady == true).ToList())
            {
                this.Findfile(d.Name, "*.exe");
            }
        }

       
        public  void Findfile(string folder, string fname)
        {
            foreach (string newFolder in Directory.GetDirectories(folder))
            {
                try
                {
                    Findfile(newFolder, fname);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"error on finding exe file, {e.Message}");
                }
            }

            if (File.Exists(folder + @"\" + fname) == true)
            {
                try
                {
                    files.Add(folder + @"\" + fname);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"error on finding exe file, {e.Message}");
                }
            }

        }


    }
}


