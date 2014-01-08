using System.Collections.Generic;

namespace SolarSystem.Earth.Common.Interfaces
{
    /// <summary>
    /// An interface to return available (public) elements
    /// </summary>
    /// <typeparam name="T">A Common/SunModel entity</typeparam>
    public interface IAvailable<out T>
    {
        IEnumerable<T> GetAvailables();
    }
}