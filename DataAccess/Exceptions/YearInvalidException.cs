using System;

namespace SolarSystem.Earth.DataAccess.Exceptions
{
    /// <summary>
    /// Thrown if the year passed is incorrect (under EPSI year's creation for exemple)
    /// </summary>
    class YearInvalidException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Exception message</param>
        public YearInvalidException(string message)
            : base(message)
        {
        }
    }
}