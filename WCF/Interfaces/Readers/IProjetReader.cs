using System.Collections.Generic;
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
        IEnumerable<Projet> GetProjetsByVille(Ville ville);

        [OperationContract]
        IEnumerable<Projet> GetProjetsByVilleLimited(Ville ville, int indexFirstElement, int numberOfResults);

        [OperationContract]
        int GetProjetLastInsertedId();
    }
}