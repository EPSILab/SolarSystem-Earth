using System.Collections.Generic;
using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Readers;

namespace SolarSystem.Earth.WCF
{
    public partial class ReadersService : IMembreReader
    {
        public Membre GetMembre(int code)
        {
            IReader<Membre> business = new MembreBusiness();
            return business.Get(code);
        }

        public IEnumerable<Membre> GetMembresNotInBureauByVille(Ville ville)
        {
            IMembreReader<Membre, Ville> business = new MembreBusiness();
            return business.GetMembresActives(ville);
        }

        public IEnumerable<Membre> GetMembresInBureau()
        {
            IMembreReader<Membre, Ville> business = new MembreBusiness();
            return business.GetBureau();
        }

        public IEnumerable<Membre> GetMembresInBureauByVille(Ville ville)
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