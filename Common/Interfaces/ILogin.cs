namespace SolarSystem.Earth.Common.Interfaces
{
    /// <summary>
    /// An interface for login, registration and lost password management
    /// </summary>
    /// <typeparam name="T">Common/SunModel Member entity</typeparam>
    /// <typeparam name="TClass">Common/SunModel RequestLostPassword entity</typeparam>
    public interface ILogin<T, out TClass>
    {
        T Login(string username, string password);

        void ChangePassword(string username, string oldPassword, string newPassword);

        bool Exists(string username);

        bool Exists(string username, string password);

        int Register(T membre);

        TClass RequestLostPassword(string username, string email);

        void SetNewPasswordAfterLost(string username, string newPassword, string key);
    }
}