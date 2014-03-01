using System;

namespace EPSILab.SolarSystem.Earth.Common
{
    public class Show
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start_DateTime { get; set; }
        public DateTime End_DateTime { get; set; }
        public string Place { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public string Url { get; set; }
    }
}