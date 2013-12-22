using System.Collections.Generic;
using System.Data.SqlClient;

namespace SolarSystem.Earth.Common.Interfaces
{
    public interface IReaderTwoFilters<out TValue, in TKey, in TProperty> : IReaderSort<TValue>
    {
        IEnumerable<TValue> Get(TKey filter1, TProperty filter2, int indexFirstElement, int numberOfResults, SortOrder order);
    }
}