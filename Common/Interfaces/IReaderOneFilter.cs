using System.Collections.Generic;
using System.Data.SqlClient;

namespace SolarSystem.Earth.Common.Interfaces
{
    public interface IReaderOneFilter<out TValue, in TKey> : IReaderSort<TValue>
    {
        IEnumerable<TValue> Get(TKey filter, int indexFirstElement, int numberOfResults, SortOrder order);
    }
}