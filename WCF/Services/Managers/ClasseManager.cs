using System.Collections.Generic;
using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Managers;

namespace SolarSystem.Earth.WCF
{
    public partial class ManagersService : IClasseManager
    {
        public Classe GetClasse(int code)
        {
            IReader<Classe> business = new ClasseBusiness();
            return business.Get(code);
        }

        public IEnumerable<Classe> GetClasses()
        {
            IReader<Classe> business = new ClasseBusiness();
            return business.Get();
        }

        public IEnumerable<Classe> GetClassesAvailables()
        {
            IAvailable<Classe> business = new ClasseBusiness();
            return business.GetAvailables();
        }

        public int AddClasse(Classe element, string username, string password)
        {
            IManager<Classe> business = new ClasseBusiness();
            return business.Add(element, username, password);
        }

        public void EditClasse(Classe element, string username, string password)
        {
            IManager<Classe> business = new ClasseBusiness();
            business.Edit(element, username, password);
        }

        public void DeleteClasse(int code, string username, string password)
        {
            IManager<Classe> business = new ClasseBusiness();
            business.Delete(code, username, password);
        }
    }
}