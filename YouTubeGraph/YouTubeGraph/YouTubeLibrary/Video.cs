using System;
using System.Collections.Generic;
using System.Text;

namespace YouTubeLibrary
{
    public class Video
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public List<string> Tags { get; set; }
        public string Category { get; set; }

        public Video (string title, TimeSpan duration, List<string> tags, string category)
        {
            Title = title;
            Duration = duration;
            Tags = tags;
            Category = category;
        }
    }
}
