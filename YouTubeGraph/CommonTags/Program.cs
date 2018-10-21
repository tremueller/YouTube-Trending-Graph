using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeLibrary;

namespace CommonTags
{
    class Program
    {
        //Prints the most common tags with an occurence greater than 1
        static void CommonTags(List<Video> vids)
        {
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
            //Reverse tagCount to show the most common tags
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
        //Print the most common categories
        static void CommonCategories(List<Video> vids)
        {
            Dictionary<String, int> commonCat = new Dictionary<string, int>();
            foreach (Video vid in vids)
            {
                if (commonCat.ContainsKey(vid.Category))
                {
                    commonCat[vid.Category]++;
                }
                else
                {
                    commonCat[vid.Category] = 1;
                }
            }
            foreach (String key in commonCat.Keys)
            {
                Console.WriteLine(key + " " + commonCat[key]);
            }
        }
        static void Main(string[] args)
        {
            List<Video> vids = Utility.retrieveVideos();
            CommonTags(vids);
            CommonCategories(vids);
        }
    }
}
