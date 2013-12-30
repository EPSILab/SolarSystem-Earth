using System.Collections.Generic;
using System.Data.SqlClient;

namespace SolarSystem.Earth.Common.Interfaces
{
    public interface IReader3Filters<out TValue, in TKey, in TProperty, in TClass> : IReader2Filters<TValue, TKey, TProperty>
    {
        IEnumerable<TValue> Get(TKey filter1, TProperty filter2, TClass filter3, int indexFirstElement, int numberOfResults, SortOrder order);
    }
}