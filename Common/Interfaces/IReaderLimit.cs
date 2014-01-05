using System.Collections.Generic;

namespace SolarSystem.Earth.Common.Interfaces
{
    public interface IReaderLimit<out T> : IReader<T>
    {
        IEnumerable<T> Get(int indexFirstElement, int numberOfResults);
    }
}