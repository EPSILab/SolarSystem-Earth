using EPSILab.SolarSystem.Earth.Business;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace EPSILab.SolarSystem.Earth.WCF
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