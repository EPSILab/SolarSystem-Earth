using System.Collections.Generic;
using System.Data.SqlClient;

namespace SolarSystem.Earth.Common.Interfaces
{
    public interface IReader4Filters<out TValue, in TKey, in TProperty, in TClass, in T> : IReader3Filters<TValue, TKey, TProperty, TClass>
    {
        IEnumerable<TValue> Get(TKey filter1, TProperty filter2, TClass filter3, T filter4, int indexFirstElement, int numberOfResults, SortOrder order);
    }
}