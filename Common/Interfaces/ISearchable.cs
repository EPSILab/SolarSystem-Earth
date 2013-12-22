using System.Collections.Generic;

namespace SolarSystem.Earth.Common.Interfaces
{
    public interface ISearchable<out T>
    {
        IEnumerable<T> Search(string keywords);
    }
}