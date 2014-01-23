using System;

namespace EPSILab.SolarSystem.Earth.DataAccess.Exceptions
{
    /// <summary>
    /// Thrown when a null value is passed
    /// </summary>
    class NullValueException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Exception message</param>
        public NullValueException(string message)
            : base(message)
        {
        }
    }
}