using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace SolarSystem.Earth.WCF
{
    public partial class ManagersService : IProjetManager
    {
        public Projet GetProjet(int code)
        {
            IReader<Projet> business = new ProjetBusiness();
            return business.Get(code);
        }

        public IEnumerable<Projet> GetProjets(int indexFirstElement, int numberOfResults)
        {
            IReaderLimit<Projet> business = new ProjetBusiness();
            return business.Get(indexFirstElement, numberOfResults);
        }

        public int AddProjet(Projet element, string username, string password)
        {
            IManager<Projet> business = new ProjetBusiness();
            return business.Add(element, username, password);
        }

        public void EditProjet(Projet element, string username, string password)
        {
            IManager<Projet> business = new ProjetBusiness();
            business.Edit(element, username, password);
        }

        public void DeleteProjet(int code, string username, string password)
        {
            IManager<Projet> business = new ProjetBusiness();
            business.Delete(code, username, password);
        }
    }
}