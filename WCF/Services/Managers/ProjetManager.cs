using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace SolarSystem.Earth.WCF
{
    public partial class ManagersService : IProjetManager
    {
        public IEnumerable<Projet> GetProjets(int indexFirstResult, int numberOfResults, string username, string password)
        {
            IManager<Projet> business = new ProjetBusiness();
            return business.Get(indexFirstResult, numberOfResults, username, password);
        }

        public Projet GetProjet(int code, string username, string password)
        {
            IManager<Projet> business = new ProjetBusiness();
            return business.Get(code, username, password);
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