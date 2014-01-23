using System.Collections.Generic;

namespace EPSILab.SolarSystem.Earth.Common.Interfaces
{
    /// <summary>
    /// An interface to search elements
    /// </summary>
    /// <typeparam name="T">A Common/SunModel entity</typeparam>
    public interface ISearchable<out T>
    {
        IEnumerable<T> Search(string keywords);
    }
}