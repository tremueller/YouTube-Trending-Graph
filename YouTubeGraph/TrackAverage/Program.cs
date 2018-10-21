using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeLibrary;

namespace TrackAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Video> vids = Utility.retrieveVideos();
            TimeSpan avg = Utility.getAvgLength(vids);

            //Find current file path
            string path = AppDomain.CurrentDomain.BaseDirectory + "test.csv";
            //Get the current time
            string currentTime = DateTime.Now.GetDateTimeFormats('g')[0];
            
            //If file doesn't exist add column headings
            if (!File.Exists(path))
            {
                File.AppendAllText(path, "Date,Average Video Length" + Environment.NewLine);
            }       

            //Add the current information
            File.AppendAllText(path, currentTime + "," + avg.ToString() + Environment.NewLine);
        }
    }
}
