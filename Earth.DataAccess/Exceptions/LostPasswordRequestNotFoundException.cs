using EPSILab.SolarSystem.Earth.DataAccess.Resources;
using System;

namespace EPSILab.SolarSystem.Earth.DataAccess.Exceptions
{
    /// <summary>
    /// Thrown when a lost password request has not been found
    /// </summary>
    class LostPasswordRequestNotFoundException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LostPasswordRequestNotFoundException()
            : base(ErrorMessages.LostPassword_RequestNotFound)
        {
        }
    }
}