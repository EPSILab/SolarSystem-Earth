using System;

namespace SolarSystem.Earth.DataAccess.Exceptions
{
    class AssociationManquanteException : Exception
    {
        public AssociationManquanteException(string message)
            : base (message)
        {
        }
    }
}