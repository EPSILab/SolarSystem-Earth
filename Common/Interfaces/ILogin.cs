namespace SolarSystem.Earth.Common.Interfaces
{
    public interface ILogin<T, out TService>
    {
        T Login(string username, string password);

        void ChangePassword(string username, string oldPassword, string newPassword);

        bool Exists(string username);

        bool Exists(string username, string password);

        int Register(T membre);

        TService LostPassword(string username, string email);
    }
}