using System;

namespace SolarSystem.Earth.DataAccess.Exceptions
{
    public class UserNotExistsException : Exception
    {
        public UserNotExistsException(string message)
            : base(message)
        {
        }
    }
}