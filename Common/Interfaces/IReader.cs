using System.Collections.Generic;

namespace SolarSystem.Earth.Common.Interfaces
{
    public interface IReader<out T>
    {
        T Get(int code);
        IEnumerable<T> Get();
    }
}