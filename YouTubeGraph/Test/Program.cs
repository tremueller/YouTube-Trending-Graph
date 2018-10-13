using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeLibrary;

namespace Test
{
    class Program
    {
        static void CommonTags()
        {
            //Print Most Common Tags
            List<Video> vids = Find.retrieveVideos();
            Dictionary<string, int> tagCount = new Dictionary<string, int>();

            foreach (Video vid in vids)
            {
                if (vid.Tags != null)
                {
                    foreach (string tag in vid.Tags)
                    {
                        if (tagCount.ContainsKey(tag))
                        {
                            tagCount[tag]++;
                        }
                        else
                        {
                            tagCount.Add(tag, 1);
                        }
                    }
                }
            }

            SortedDictionary<int, string> sortedTagCount = new SortedDictionary<int, string>();
            foreach (string tag in tagCount.Keys)
            {
                if (sortedTagCount.ContainsKey(tagCount[tag]))
                {
                    sortedTagCount[tagCount[tag]] += ", " + tag;
                }
                else
                {
                    sortedTagCount.Add(tagCount[tag], tag);
                }
            }
            foreach (var count in sortedTagCount.Reverse())
            {
                if (count.Key > 1)
                {
                    Console.WriteLine(count);
                }
            }
        }
        static void CommonCategories()
        {
            
        }
        static void Main(string[] args)
        {
            CommonTags();
        }
    }
}
