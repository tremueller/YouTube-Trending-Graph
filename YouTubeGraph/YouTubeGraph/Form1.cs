using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouTubeLibrary;

namespace YouTubeGraph
{
    public partial class Form1 : Form
    {
        public static Dictionary<int, int> createHistogram(List<Video> vids)
        {
            Dictionary<int, int> histogram = new Dictionary<int, int>();
            foreach (Video v in vids)
            {
                //Truncate vid length to the minute
                int durationMin = (int)v.Duration.TotalMinutes;
                //Add vid to histogram dictionary
                if (histogram.ContainsKey(durationMin))
                {
                    histogram[durationMin]++;
                }
                else
                {
                    histogram[durationMin] = 1;
                }
            }
            return histogram;
        }
        public static TimeSpan getAvgLength(List<Video> vids)
        {
            TimeSpan totalTime = new TimeSpan(0, 0, 0);
            int count = 0;
            foreach (Video vid in vids)
            {
                //Only get avg of videos below 60 mins
                if (vid.Duration.TotalMinutes < 60)
                {
                    totalTime += vid.Duration;
                    count++;
                }
            }
            TimeSpan avgTime = new TimeSpan(0, 0, (int)totalTime.TotalSeconds / count);
            return avgTime;
        }
        public Form1()
        {
            InitializeComponent();
            List<Video> vids = Find.retrieveVideos();
            Dictionary<int, int> histogram = createHistogram(vids);
            //Plot histogram data points
            foreach (int key in histogram.Keys)
            {
                if (key < 60)
                {
                    chart1.Series["Series1"].Points.AddXY(key, histogram[key]);
                }
            }
            TimeSpan avgTime = getAvgLength(vids);
            textBox1.AppendText("Average = " + avgTime.ToString("mm\\:ss"));
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
