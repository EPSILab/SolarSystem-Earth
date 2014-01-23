using System.Collections.Generic;
using EPSILab.SolarSystem.Earth.Business;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ReadersService : IMembreReader
    {
        public Membre GetMembre(int code)
        {
            IReader<Membre> business = new MembreBusiness();
            return business.Get(code);
        }

        public IEnumerable<Membre> GetMembres()
        {
            IMembreReader<Membre, Ville> business = new MembreBusiness();
            return business.GetBureauAndMembresActives();
        }

        public IEnumerable<Membre> GetMembresByVille(Ville ville)
        {
            IMembreReader<Membre, Ville> business = new MembreBusiness();
            return business.GetBureauAndMembresActives(ville);
        }

        public IEnumerable<Membre> GetMembresBureau()
        {
            IMembreReader<Membre, Ville> business = new MembreBusiness();
            return business.GetBureau();
        }

        public IEnumerable<Membre> GetMembresBureauByVille(Ville ville)
        {
            IMembreReader<Membre, Ville> business = new MembreBusiness();
            return business.GetBureau(ville);
        }

        public IEnumerable<Membre> GetMembresAlumnis(Ville ville)
        {
            IMembreReader<Membre, Ville> business = new MembreBusiness();
            return business.GetAlumnis(ville);
        }

        public int GetMembreLastInsertedId()
        {
            IReader<Membre> business = new MembreBusiness();
            return business.GetLastInsertedId();
        }

        public IEnumerable<Membre> SearchMembres(string keywords)
        {
            ISearchable<Membre> business = new MembreBusiness();
            return business.Search(keywords);
        }
    }
}