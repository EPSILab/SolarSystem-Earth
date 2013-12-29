using System;

namespace SolarSystem.Earth.DataAccess.Exceptions
{
    class NullValueException : Exception
    {
        public NullValueException(string message)
            : base(message)
        {
        }
    }
}