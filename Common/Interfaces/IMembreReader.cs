using System.Collections.Generic;

namespace SolarSystem.Earth.Common.Interfaces
{
    /// <summary>
    /// An interface to get specific members
    /// </summary>
    /// <typeparam name="T">Common/SunModel Member entity</typeparam>
    /// <typeparam name="TClass">Common/SunModel City entity</typeparam>
    public interface IMembreReader<out T, in TClass> : IReader<T>
    {
        IEnumerable<T> GetBureauAndMembresActives();
        IEnumerable<T> GetBureauAndMembresActives(TClass ville);

        IEnumerable<T> GetBureau();
        IEnumerable<T> GetBureau(TClass ville);

        IEnumerable<T> GetMembresActives(TClass ville);

        IEnumerable<T> GetAlumnis();
        IEnumerable<T> GetAlumnis(TClass ville);

        IEnumerable<T> GetWaitingForValidation();
    }
}