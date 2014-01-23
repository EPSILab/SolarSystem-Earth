using System.Collections.Generic;

namespace EPSILab.SolarSystem.Earth.Common.Interfaces
{
    /// <summary>
    /// An interface to get a limited list of results
    /// </summary>
    /// <typeparam name="T">A Common/SunModel entity</typeparam>
    public interface IReaderLimit<out T> : IReader<T>
    {
        IEnumerable<T> Get(int indexFirstElement, int numberOfResults);
    }
}