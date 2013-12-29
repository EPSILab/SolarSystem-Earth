using System;

namespace SolarSystem.Earth.DataAccess.Exceptions
{
    class NoAssociationException : Exception
    {
        public NoAssociationException(string message)
            : base (message)
        {
        }
    }
}