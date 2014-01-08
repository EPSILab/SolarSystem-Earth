namespace SolarSystem.Earth.Common.Interfaces
{
    /// <summary>
    /// An interface to create, edit or delete elements
    /// </summary>
    /// <typeparam name="T">A Common/SunModel entity</typeparam>
    public interface IManager<in T>
    {
        int Add(T element, string username, string password);

        void Edit(T element, string username, string password);

        void Delete(int code, string username, string password);
    }
}