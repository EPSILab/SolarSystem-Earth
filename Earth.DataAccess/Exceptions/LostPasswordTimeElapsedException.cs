﻿using EPSILab.SolarSystem.Earth.DataAccess.Resources;
using System;

namespace EPSILab.SolarSystem.Earth.DataAccess.Exceptions
{
    /// <summary>
    /// Thrown when a lost password request has expired
    /// </summary>
    public class LostPasswordTimeElapsedException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LostPasswordTimeElapsedException()
            : base(ErrorMessages.LostPassword_TimeExpired)
        {
        }
    }
}