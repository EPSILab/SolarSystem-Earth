using System.Collections.Generic;
using System.Data.SqlClient;

namespace SolarSystem.Earth.Common.Interfaces
{
    public interface IReaderSort<out T> : IReaderLimit<T>
    {
        IEnumerable<T> Get(int indexFirstElement, int numberOfResults, SortOrder order);
    }
}