using System.Collections.Generic;

namespace EPSILab.SolarSystem.Earth.Common.Interfaces
{
    /// <summary>
    /// An interface to get elements
    /// </summary>
    /// <typeparam name="T">A Common/SunModel entity</typeparam>
    public interface IReader<out T>
    {
        T Get(int code);
        IEnumerable<T> Get();
        int GetLastInsertedId();
    }
}