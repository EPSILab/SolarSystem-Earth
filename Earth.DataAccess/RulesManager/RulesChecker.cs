using EPSILab.SolarSystem.Earth.DataAccess.Exceptions;

namespace EPSILab.SolarSystem.Earth.DataAccess.RulesManager
{
    /// <summary>
    /// Class containing all checking rules
    /// </summary>
    static class RulesChecker
    {
        /// <summary>
        /// Check if a database Id is valid
        /// </summary>
        /// <param name="field">Field to check</param>
        /// <param name="message">Message included in the thrown exception</param>
        public static void CheckIsNotNull(int field, string message)
        {
            if (field == 0)
            {
                throw new NoAssociationException(message);
            }
        }

        /// <summary>
        /// Check if a string is null, empty or contains only white spaces
        /// </summary>
        /// <param name="field">Field to check</param>
        /// <param name="message">Message included in the thrown exception</param>
        public static void CheckIsNotNull(string field, string message)
        {
            if (string.IsNullOrWhiteSpace(field))
            {
                throw new NullValueException(message);
            }
        }

        /// <summary>
        /// Check if a number is between 0 and 100
        /// </summary>
        /// <param name="field">Field to check</param>
        /// <param name="message">Message included in the thrown exception</param>
        public static void CheckIsPercentage(int field, string message)
        {
            if (field < 0 || field > 100)
            {
                throw new IncorrectValueException(message);
            }
        }

        /// <summary>
        /// Check if a is lesser than b
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="message">Message included in the thrown exception</param>
        public static void CheckIsShorter(int a, int b, string message)
        {
            if (a < b)
            {
                throw new IncorrectValueException(message);
            }
        }
    }
}