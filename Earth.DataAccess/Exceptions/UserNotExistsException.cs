using EPSILab.SolarSystem.Earth.DataAccess.Resources;
using System;

namespace EPSILab.SolarSystem.Earth.DataAccess.Exceptions
{
    /// <summary>
    /// Thrown if an user has not been found
    /// </summary>
    public class UserNotExistsException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UserNotExistsException()
            : base(ErrorMessages.Member_NotFound)
        {
        }
    }
}