using System;

namespace EPSILab.SolarSystem.Earth.Common
{
    public class RecupMotDePasse
    {
        public int Id { get; set; }
        public Membre Membre { get; set; }

        public DateTime Date { get; set; }

        public string Cle { get; set; }
    }
}