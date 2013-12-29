using System;

namespace SolarSystem.Earth.DataAccess.Exceptions
{
    public class AccesRefuseException : Exception
    {
        public AccesRefuseException(string message)
            : base(message)
        {
        }
    }
}