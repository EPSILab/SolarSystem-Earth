using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.Model;
using System.Collections.Generic;
using System.Linq;

namespace SolarSystem.Earth.DataAccess.DAL
{
    public class RoleDAL : IReader<Role>
    {
        #region IReader methods

        /// <summary>
        /// Get a role
        /// </summary>
        /// <param name="code">Role code</param>
        /// <returns>Matching role</returns>
        public Role Get(int code)
        {
            return (from role in SunAccess.Instance.Role
                    where role.Code_Role == code
                    select role).First();
        }

        /// <summary>
        /// Get all roles
        /// </summary>
        /// <returns>List of roles</returns>
        public IEnumerable<Role> Get()
        {
            return SunAccess.Instance.Role;
        }

        /// <summary>
        /// Get last role id
        /// </summary>
        /// <returns>Last role id</returns>
        public int GetLastInsertedId()
        {
            return (from r in SunAccess.Instance.Role
                    orderby r.Code_Role descending
                    select r).First().Code_Role;
        }

        #endregion
    }
}