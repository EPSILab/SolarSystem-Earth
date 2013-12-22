using System;
namespace SolarSystem.Earth.DataAccess.Exceptions
{
    class ValeurIncorrecteException : Exception
    {
        public ValeurIncorrecteException(string message)
            : base(message)
        {
        }
    }
}
