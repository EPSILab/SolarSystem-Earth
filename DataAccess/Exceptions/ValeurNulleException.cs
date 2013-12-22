using System;

namespace SolarSystem.Earth.DataAccess.Exceptions
{
    class ValeurNulleException : Exception
    {
        public ValeurNulleException(string message)
            : base(message)
        {
        }
    }
}