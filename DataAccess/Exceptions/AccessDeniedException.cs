using SolarSystem.Earth.DataAccess.Resources;
using System;

namespace SolarSystem.Earth.DataAccess.Exceptions
{
    public class AccessDeniedException : Exception
    {
        public AccessDeniedException()
            : base(ErrorMessages.ACCES_REFUSE)
        {
        }
    }
}