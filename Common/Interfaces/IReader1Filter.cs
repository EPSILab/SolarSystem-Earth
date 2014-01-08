using System.Collections.Generic;

namespace SolarSystem.Earth.Common.Interfaces
{
    /// <summary>
    /// An interface to get elements with one filter
    /// </summary>
    /// <typeparam name="T">A Common/SunModel entity</typeparam>
    /// <typeparam name="TClass">A Common/SunModel entity</typeparam>
    public interface IReader1Filter<out T, in TClass> : IReaderLimit<T>
    {
        IEnumerable<T> Get(TClass filter);
        IEnumerable<T> Get(TClass filter, int indexFirstResult, int numberOfResults);
    }
}