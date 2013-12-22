using SolarSystem.Earth.Business;
using SolarSystem.Earth.Common;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.WCF.Interfaces.Readers;
using System.Collections.Generic;

namespace SolarSystem.Earth.WCF
{
    public partial class ReadersService : IRoleReader
    {
        public Role GetRole(int code)
        {
            IReader<Role> business = new RoleBusiness();
            return business.Get(code);
        }

        public IEnumerable<Role> GetRoles()
        {
            IReader<Role> business = new RoleBusiness();
            return business.Get();
        }
    }
}