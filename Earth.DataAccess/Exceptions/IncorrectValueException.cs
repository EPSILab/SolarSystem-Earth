using System;
namespace EPSILab.SolarSystem.Earth.DataAccess.Exceptions
{
    /// <summary>
    /// Thrown if a value is incorrect
    /// </summary>
    class IncorrectValueException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Exception message</param>
        public IncorrectValueException(string message)
            : base(message)
        {
        }
    }
}