using System;
using System.Collections.Generic;

namespace YouTubeLibrary
{
    public class VideoList
    {
        public string nextPageToken { get; set; }
        public string test { get; set; }
        public List<Item> items { get; set; }
    }
    public class Item
    {
        public Snippet snippet { get; set; }
        public string id { get; set; }
        public ContentDetails contentDetails { get; set; }
    }
    public class Snippet
    {
        public string title { get; set; }
        public List<string> tags { get; set; }
        public string category { get; set; }
    }
    public class ContentDetails
    {
        public string duration { get; set; }
    }
}

