using System.Collections.Generic;

namespace SolarSystem.Earth.Common.Interfaces
{
    public interface IManager<T>
    {
        IEnumerable<T> Get(int indexFirstResult, int numberOfResults, string username, string password);

        T Get(int code, string username, string password);

        int Add(T element, string username, string password);
        void Edit(T element, string username, string password);
        void Delete(int code, string username, string password);
    }
}