using System;

namespace EPSILab.SolarSystem.Earth.DataAccess.Exceptions
{
    /// <summary>
    /// Thrown when a association between 2 entities is incorrect (Id = 0)
    /// </summary>
    class NoAssociationException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Exception message</param>
        public NoAssociationException(string message)
            : base (message)
        {
        }
    }
}