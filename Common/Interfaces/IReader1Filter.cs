using System.Collections.Generic;
using System.Data.SqlClient;

namespace SolarSystem.Earth.Common.Interfaces
{
    public interface IReader1Filter<out TValue, in TKey> : IReaderSort<TValue>
    {
        IEnumerable<TValue> Get(TKey filter, int indexFirstElement, int numberOfResults, SortOrder order);

    }
}