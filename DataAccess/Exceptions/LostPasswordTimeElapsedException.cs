using SolarSystem.Earth.DataAccess.Resources;
using System;

namespace SolarSystem.Earth.DataAccess.Exceptions
{
    public class LostPasswordTimeElapsedException : Exception
    {
        public LostPasswordTimeElapsedException()
            : base(ErrorMessages.TEMPS_EXPIRE_RECUP_MOT_DE_PASSE)
        {
        }
    }
}