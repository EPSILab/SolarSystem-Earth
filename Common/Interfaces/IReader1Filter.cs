using System.Collections.Generic;

namespace SolarSystem.Earth.Common.Interfaces
{
    public interface IReader1Filter<out T, in TClass> : IReaderLimit<T>
    {
        IEnumerable<T> Get(TClass filter);
        IEnumerable<T> Get(TClass filter, int indexFirstResult, int numberOfResults);
    }
}