using System.Collections.Generic;
using System.ServiceModel;
using SolarSystem.Earth.Common;

namespace SolarSystem.Earth.WCF.Interfaces.Readers
{
    [ServiceContract]
    interface IRoleReader
    {
        [OperationContract]
        Role GetRole(int code);

        [OperationContract]
        IEnumerable<Role> GetRoles();
    }
}
