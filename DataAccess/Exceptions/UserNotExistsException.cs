using SolarSystem.Earth.DataAccess.Resources;
using System;

namespace SolarSystem.Earth.DataAccess.Exceptions
{
    public class UserNotExistsException : Exception
    {
        public UserNotExistsException()
            : base(ErrorMessages.UTILISATEUR_INTROUVABLE)
        {
        }
    }
}