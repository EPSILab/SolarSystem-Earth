using EPSILab.SolarSystem.Earth.Business;
using EPSILab.SolarSystem.Earth.Common;
using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.WCF.Interfaces.Managers;
using System.Collections.Generic;

namespace EPSILab.SolarSystem.Earth.WCF
{
    public partial class ManagersService : ICampusManager
    {
        public Campus GetCampus(int code)
        {
            IReader<Campus> business = new CampusBusiness();
            return business.Get(code);
        }

        public IEnumerable<Campus> GetCampuses()
        {
            IReader<Campus> business = new CampusBusiness();
            return business.Get();
        }

        public int AddCampus(Campus element, string username, string password)
        {
            IManager<Campus> business = new CampusBusiness();
            return business.Add(element, username, password);
        }

        public void EditCampus(Campus element, string username, string password)
        {
            IManager<Campus> business = new CampusBusiness();
            business.Edit(element, username, password);
        }

        public void DeleteCampus(int code, string username, string password)
        {
            IManager<Campus> business = new CampusBusiness();
            business.Delete(code, username, password);
        }
    }
}