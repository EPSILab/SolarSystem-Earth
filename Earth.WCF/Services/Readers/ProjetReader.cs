using System.Collections.Generic;
using EPSILab.SolarSystem.Earth.Business;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers;

namespace EPSILab.SolarSystem.Earth.WCF
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