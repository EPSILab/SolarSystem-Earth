using System.Collections.Generic;

namespace SolarSystem.Earth.Common.Interfaces
{
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