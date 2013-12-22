using System;

namespace SolarSystem.Earth.Common
{
    public class Salon
    {
        public int Code_Salon { get; set; }
        public string Nom { get; set; }
        public DateTime Date_Heure_Debut { get; set; }
        public DateTime Date_Heure_Fin { get; set; }
        public string Lieu { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool Publie { get; set; }
        public string URL { get; set; }
    }
}
