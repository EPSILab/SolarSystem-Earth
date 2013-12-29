namespace SolarSystem.Earth.Common.Interfaces
{
    public interface IManager<T> : IReaderLimit<T> 
    {
        int Add(T element, string username, string password);

        void Edit(T element, string username, string password);

        void Delete(int code, string username, string password);
    }
}