using System.Collections.Generic;
using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Readers;

namespace SolarSystem.Earth.WCF
{
    public partial class ReadersService : IProjetReader
    {
        public Projet GetProjet(int code)
        {
            IReader<Projet> business = new ProjetBusiness();
            return business.Get(code);
        }

        public IEnumerable<Projet> GetProjets()
        {
            IReader<Projet> business = new ProjetBusiness();
            return business.Get();
        }

        public IEnumerable<Projet> GetProjetsLimited(int indexFirstElement, int numberOfResults)
        {
            IReaderLimit<Projet> business = new ProjetBusiness();
            return business.Get(indexFirstElement, numberOfResults);
        }

        public IEnumerable<Projet> GetProjetsByVille(Ville ville)
        {
            IReader1Filter<Projet, Ville> business = new ProjetBusiness();
            return business.Get(ville);
        }

        public IEnumerable<Projet> GetProjetsByVilleLimited(Ville ville, int indexFirstElement, int numberOfResults)
        {
            IReader1Filter<Projet, Ville> business = new ProjetBusiness();
            return business.Get(ville, indexFirstElement, numberOfResults);
        }

        public int GetProjetLastInsertedId()
        {
            IReaderLimit<Projet> business = new ProjetBusiness();
            return business.GetLastInsertedId();
        }
    }
}