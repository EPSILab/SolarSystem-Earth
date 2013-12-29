using System.Collections.Generic;

namespace SolarSystem.Earth.Common.Interfaces
{
    public interface IAvailable<out T>
    {
        IEnumerable<T> GetAvailables();
    }
}