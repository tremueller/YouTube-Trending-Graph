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
        public Form1()
        {
            InitializeComponent();
            List<Video> vids = Utility.retrieveVideos();
            Dictionary<int, int> histogram = Utility.createHistogram(vids);
            //Plot histogram data points
            foreach (int key in histogram.Keys)
            {
                if (key < 60)
                {
                    chart1.Series["Series1"].Points.AddXY(key, histogram[key]);
                }
            }
            TimeSpan avgTime = Utility.getAvgLength(vids);
            textBox1.AppendText("Average = " + avgTime.ToString("mm\\:ss"));
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
