using System.Collections.Generic;
using System.Data.SqlClient;
using System.ServiceModel;
using SolarSystem.Earth.Common;

namespace SolarSystem.Earth.WCF.Interfaces.Readers
{
    [ServiceContract]
    interface IMembreReader
    {
        [OperationContract]
        Membre GetMembre(int code);

        [OperationContract]
        IEnumerable<Membre> GetMembres();

        [OperationContract]
        IEnumerable<Membre> GetMembresLimited(int indexFirstElement, int numberOfResults);

        [OperationContract]
        IEnumerable<Membre> GetMembresSorted(int indexFirstElement, int numberOfResults, SortOrder order);

        [OperationContract]
        IEnumerable<Membre> GetMembresByVilleAndRole(Ville ville, Role role, int indexFirstResult, int numberOfResults, SortOrder order);

        [OperationContract]
        int GetMembreLastInsertedId();

        [OperationContract]
        IEnumerable<Membre> SearchMembres(string keywords);
    }
}