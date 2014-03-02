using System;

namespace EPSILab.SolarSystem.Earth.Common
{
    public class News
    {
        public int Id { get; set; }
        public Member Member { get; set; }
        public string Title { get; set; }
        public string ShortText { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public string ImageUrl { get; set; }
        public string Keywords { get; set; }
        public bool IsPublished { get; set; }
        public string Url { get; set; }
    }
}