using System;

namespace SolarSystem.Earth.Common
{
    public class Conference
    {
        public int Code_Conference { get; set; }
        public Ville Ville { get; set; }
        public string Nom { get; set; }
        public DateTime Date_Heure_Debut { get; set; }
        public DateTime Date_Heure_Fin { get; set; }
        public string Lieu { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool Publiee { get; set; }
        public string URL { get; set; }
    }
}
