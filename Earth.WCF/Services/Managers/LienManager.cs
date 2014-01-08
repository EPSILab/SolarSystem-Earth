using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace SolarSystem.Earth.WCF
{
    public partial class ManagersService : ILienManager
    {
        #region ILienReader methods

        public Lien GetLien(int code)
        {
            IReader<Lien> business = new LienBusiness();
            return business.Get(code);
        }

        public IEnumerable<Lien> GetLiens()
        {
            IReader<Lien> business = new LienBusiness();
            return business.Get();
        }

        #endregion

        #region ILienManager methods

        public int AddLien(Lien element, string username, string password)
        {
            IManager<Lien> business = new LienBusiness();
            return business.Add(element, username, password);
        }

        public void EditLien(Lien element, string username, string password)
        {
            IManager<Lien> business = new LienBusiness();
            business.Edit(element, username, password);
        }

        public void DeleteLien(int code, string username, string password)
        {
            IManager<Lien> business = new LienBusiness();
            business.Delete(code, username, password);
        }

        #endregion
    }
}