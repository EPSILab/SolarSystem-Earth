using SolarSystem.Earth.DataAccess.Resources;
using System;

namespace SolarSystem.Earth.DataAccess.Exceptions
{
    class LostPasswordRequestNotFoundException : Exception
    {
        public LostPasswordRequestNotFoundException()
            : base(ErrorMessages.DEMANDE_RECUP_MOT_DE_PASSE_INTROUVABLE)
        {
        }
    }
}