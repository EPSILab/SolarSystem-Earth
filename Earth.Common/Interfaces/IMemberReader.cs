using System.Collections.Generic;

namespace EPSILab.SolarSystem.Earth.Common.Interfaces
{
    /// <summary>
    /// An interface to get specific members
    /// </summary>
    /// <typeparam name="T">Common/SunModel Member entity</typeparam>
    /// <typeparam name="TClass">Common/SunModel City entity</typeparam>
    public interface IMemberReader<out T, in TClass> : IReader<T>
    {
        IEnumerable<T> GetBureauAndMembersActives();
        IEnumerable<T> GetBureauAndMembersActives(TClass campus);

        IEnumerable<T> GetBureau();
        IEnumerable<T> GetBureau(TClass campus);

        IEnumerable<T> GetMembersActives(TClass campus);

        IEnumerable<T> GetAlumnis();
        IEnumerable<T> GetAlumnis(TClass campus);

        IEnumerable<T> GetWaitingForValidation();
    }
}