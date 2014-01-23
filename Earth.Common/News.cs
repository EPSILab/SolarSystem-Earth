using System;

namespace EPSILab.SolarSystem.Earth.Common
{
    public class News
    {
        public int Code_News { get; set; }
        public Membre Membre { get; set; }
        public string Titre { get; set; }
        public string Texte_Court { get; set; }
        public string Texte_Long { get; set; }
        public DateTime Date_Heure { get; set; }
        public string Image { get; set; }
        public string Mots_Cles { get; set; }
        public bool Publiee { get; set; }
        public string URL { get; set; }
    }
}