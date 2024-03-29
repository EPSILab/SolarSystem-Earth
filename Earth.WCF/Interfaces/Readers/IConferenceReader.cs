﻿using System.Collections.Generic;
using System.ServiceModel;
using EPSILab.SolarSystem.Earth.Common;

namespace EPSILab.SolarSystem.Earth.WCF.Interfaces.Readers
{
    [ServiceContract]
    interface IConferenceReader
    {
        [OperationContract]
        Conference GetConference(int code);

        [OperationContract]
        IEnumerable<Conference> GetConferences();

        [OperationContract]
        IEnumerable<Conference> GetConferencesLimited(int indexFirstResult, int numberOfResults);

        [OperationContract]
        IEnumerable<Conference> GetConferencesByCampus(Campus campus);

        [OperationContract]
        IEnumerable<Conference> GetConferencesByCampusLimited(Campus campus, int indexFirstResult, int numberOfResults);

        [OperationContract]
        int GetConferenceLastInsertedId();

        [OperationContract]
        IEnumerable<Conference> SearchConferences(string keywords);
    }
}