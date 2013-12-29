using System;
namespace SolarSystem.Earth.DataAccess.Exceptions
{
    class IncorrectValueException : Exception
    {
        public IncorrectValueException(string message)
            : base(message)
        {
        }
    }
}