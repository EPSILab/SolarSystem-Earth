namespace SolarSystem.Earth.Common.Interfaces
{
    public interface ILogin
    {
        int Login(string username, string password);

        bool Exists(string username, string password);
    }
}