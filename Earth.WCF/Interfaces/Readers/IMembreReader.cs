using EPSILab.SolarSystem.Earth.Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers
{
    [ServiceContract]
    interface IMembreReader
    {
        [OperationContract]
        Membre GetMembre(int code);

        [OperationContract]
        IEnumerable<Membre> GetMembres();

        [OperationContract]
        IEnumerable<Membre> GetMembresByVille(Ville ville);

        [OperationContract]
        IEnumerable<Membre> GetMembresBureau();

        [OperationContract]
        IEnumerable<Membre> GetMembresBureauByVille(Ville ville);

        [OperationContract]
        IEnumerable<Membre> GetMembresAlumnis(Ville ville);

        [OperationContract]
        int GetMembreLastInsertedId();

        [OperationContract]
        IEnumerable<Membre> SearchMembres(string keywords);
    }
}