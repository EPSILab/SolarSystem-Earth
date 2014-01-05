using System.Collections.Generic;
using System.Linq;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.Model;

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
            return Db.Role;
        }

        public int GetLastInsertedId()
        {
            return (from r in Db.Role
                    orderby r.Code_Role descending
                    select r).First().Code_Role;
        }

        #endregion
    }
}