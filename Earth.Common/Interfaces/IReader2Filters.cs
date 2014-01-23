using System.Collections.Generic;

namespace EPSILab.SolarSystem.Earth.Common.Interfaces
{
    /// <summary>
    /// An interface to get elements with 2 filters
    /// </summary>
    /// <typeparam name="T">A Common/SunModel entity</typeparam>
    /// <typeparam name="TClass">A Common/SunModel entity</typeparam>
    /// <typeparam name="TValue">A Common/SunModel entity</typeparam>
    public interface IReader2Filters<out T, in TClass, in TValue> : IReader1Filter<T, TClass>
    {
        IEnumerable<T> Get(TValue filter2);
        IEnumerable<T> Get(TValue filter2, int indexFirstElement, int numberOfResults);

        IEnumerable<T> Get(TClass filter1, TValue filter2);
        IEnumerable<T> Get(TClass filter1, TValue filter2, int indexFirstElement, int numberOfResults);
    }
}