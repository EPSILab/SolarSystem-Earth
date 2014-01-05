using System.Collections.Generic;

namespace SolarSystem.Earth.Common.Interfaces
{
    public interface IReader2Filters<out T, in TClass, in TValue> : IReader1Filter<T, TClass>
    {
        IEnumerable<T> Get(TValue filter2);
        IEnumerable<T> Get(TValue filter2, int indexFirstResult, int numberOfResults);

        IEnumerable<T> Get(TClass filter1, TValue filter2);
        IEnumerable<T> Get(TClass filter1, TValue filter2, int indexFirstResult, int numberOfResults);
    }
}