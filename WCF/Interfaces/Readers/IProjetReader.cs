using System.Collections.Generic;
using System.Data.SqlClient;
using System.ServiceModel;
using SolarSystem.Earth.Common;

namespace SolarSystem.Earth.WCF.Interfaces.Readers
{
    [ServiceContract]
    interface IProjetReader
    {
        [OperationContract]
        Projet GetProjet(int code);

        [OperationContract]
        IEnumerable<Projet> GetProjets();

        [OperationContract]
        IEnumerable<Projet> GetProjetsLimited(int indexFirstElement, int numberOfResults);

        [OperationContract]
        IEnumerable<Projet> GetProjetsSorted(int indexFirstElement, int numberOfResults, SortOrder order);

        [OperationContract]
        IEnumerable<Projet> GetProjetsByVille(Ville filter, int indexFirstElement, int numberOfResults, SortOrder order);

        [OperationContract]
        int GetProjetLastInsertedId();
    }
}