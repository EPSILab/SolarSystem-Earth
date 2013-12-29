using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SolarSystem.Earth.WCF
{
    public partial class ManagersService : IProjetManager
    {
        #region IProjetReader methods

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

        public IEnumerable<Projet> GetProjetsSorted(int indexFirstElement, int numberOfResults, SortOrder order)
        {
            IReaderSort<Projet> business = new ProjetBusiness();
            return business.Get(indexFirstElement, numberOfResults, order);
        }

        public IEnumerable<Projet> GetProjetsByVille(Ville filter, int indexFirstElement, int numberOfResults, SortOrder order)
        {
            IReaderOneFilter<Projet, Ville> business = new ProjetBusiness();
            return business.Get(filter, indexFirstElement, numberOfResults, order);
        }

        public int GetProjetLastInsertedId()
        {
            IReaderLimit<Projet> business = new ProjetBusiness();
            return business.GetLastInsertedId();
        }

        #endregion

        #region IProjetManager methods

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

        #endregion
    }
}