using System;

namespace SolarSystem.Earth.DataAccess.Exceptions
{
    class AnneeInvalideException : Exception
    {
        public AnneeInvalideException(string message)
            : base(message)
        {
        }
    }
}