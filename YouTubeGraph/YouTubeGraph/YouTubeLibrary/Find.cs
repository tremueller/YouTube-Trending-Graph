using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Xml;


namespace YouTubeLibrary
{
    public class Find
    {
        public static List<Video> retrieveVideos()
        {
            List<VideoList> data = new List<VideoList>();
            string key = "AIzaSyAW9NUrBJaeWEMshzokeVM-v6HDN_EkRIQ";
            string nextPageToken = null;
            using (WebClient wc = new WebClient())
            {
                do
                {
                    var response = wc.DownloadString("https://www.googleapis.com/youtube/v3/videos?part=snippet%2CcontentDetails%2Cstatistics&chart=mostPopular" + nextPageToken + "&regionCode=US&key=" + key);
                    VideoList videoChunk = JsonConvert.DeserializeObject<VideoList>(response);
                    nextPageToken = "&pageToken=" + videoChunk.nextPageToken;
                    data.Add(videoChunk);
                } while (nextPageToken != "&pageToken=");
            }
            //Get the keys for converting category numbers to actual categories
            CategoriesList categoryResponse;
            using (WebClient wc = new WebClient())
            {
                var response = wc.DownloadString("https://www.googleapis.com/youtube/v3/videoCategories?part=snippet&regionCode=US&key=" + key);
                categoryResponse = JsonConvert.DeserializeObject<CategoriesList>(response);
            }
            //Dict to convert category numbers to category names
            Dictionary<string, string> categoryConversion = new Dictionary<string, string>();
            categoryConversion.Add("0", "No Category");
            foreach (Item c in categoryResponse.items)
            {
                categoryConversion.Add(c.id, c.snippet.title);
            }

            //Convert to video objects
            List<Video> allVids = new List<Video>();
            foreach (VideoList videos in data)
            {
                foreach (Item video in videos.items)
                {
                    String title = video.snippet.title;
                    TimeSpan duration = XmlConvert.ToTimeSpan(video.contentDetails.duration);

                    //Make sure video has a category ID
                    string categoryID;
                    if (video.snippet.category == null)
                    {
                        categoryID = "0";
                    }  else
                    {
                        categoryID = video.snippet.category;
                    }

                    allVids.Add(new Video(title, duration, video.snippet.tags, categoryConversion[categoryID]));
                }
            }
            return allVids;
        }
    }
}
