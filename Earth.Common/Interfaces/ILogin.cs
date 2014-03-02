namespace EPSILab.SolarSystem.Earth.Common.Interfaces
{
    /// <summary>
    /// An interface for login, registration and lost password management
    /// </summary>
    /// <typeparam name="TMember">Common/SunModel Member entity</typeparam>
    /// <typeparam name="TRequestLostPassword">Common/SunModel RequestLostPassword entity</typeparam>
    public interface ILogin<TMember, out TRequestLostPassword>
    {
        TMember Login(string username, string password);

        void ChangePassword(string username, string oldPassword, string newPassword);

        bool Exists(string username);

        bool Exists(string username, string password);

        int Register(TMember member, string newPassword);

        TRequestLostPassword RequestLostPassword(string username, string email);

        void SetNewPasswordAfterLost(string username, string newPassword, string key);
    }
}