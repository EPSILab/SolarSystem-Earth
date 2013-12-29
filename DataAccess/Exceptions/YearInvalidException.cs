using System;

namespace SolarSystem.Earth.DataAccess.Exceptions
{
    class YearInvalidException : Exception
    {
        public YearInvalidException(string message)
            : base(message)
        {
        }
    }
}