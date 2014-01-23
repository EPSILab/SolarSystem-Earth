using EPSILab.SolarSystem.Earth.DataAccess.Resources;
using System;

namespace EPSILab.SolarSystem.Earth.DataAccess.Exceptions
{
    /// <summary>
    /// Thrown when the user cannot call a method
    /// </summary>
    public class AccessDeniedException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="username">The username who tryed to access to the system</param>
        public AccessDeniedException(string username)
            : base(string.Format(ErrorMessages.AccessDenied, username))
        {
        }
    }
}