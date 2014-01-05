using System.Collections.Generic;
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
        IEnumerable<Membre> GetMembresNotInBureauByVille(Ville ville);

        [OperationContract]
        IEnumerable<Membre> GetMembresInBureau();

        [OperationContract]
        IEnumerable<Membre> GetMembresInBureauByVille(Ville ville);

        [OperationContract]
        IEnumerable<Membre> GetMembresAlumnis(Ville ville);

        [OperationContract]
        int GetMembreLastInsertedId();

        [OperationContract]
        IEnumerable<Membre> SearchMembres(string keywords);
    }
}