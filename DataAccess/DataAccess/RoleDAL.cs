using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.Model;
using System.Collections.Generic;
using System.Linq;

namespace SolarSystem.Earth.DataAccess.DataAccess
{
    public class RoleDAL : DALBase, IReader<Role>
    {
        #region IReader methods

        public Role Get(int code)
        {
            return (from role in Db.Role
                    where role.Code_Role == code
                    select role).First();
        }

        public IEnumerable<Role> Get()
        {
            return (from r in Db.Role
                    select r);
        }

        #endregion
    }
}