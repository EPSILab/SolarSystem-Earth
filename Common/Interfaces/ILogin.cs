using System.Runtime.InteropServices;

namespace SolarSystem.Earth.Common.Interfaces
{
    public interface ILogin<T>
    {
        T Login(string username, string password);

        bool Exists(string username, string password);

        int Register(T membre);
    }
}