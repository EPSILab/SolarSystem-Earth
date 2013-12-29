using SolarSystem.Earth.DataAccess.Exceptions;

namespace SolarSystem.Earth.DataAccess.RulesManager
{
    static class RulesChecker
    {
        public static void CheckIsNotNull(int field, string message)
        {
            if (field == 0)
            {
                throw new NoAssociationException(message);
            }
        }

        public static void CheckIsNotNull(string field, string message)
        {
            if (string.IsNullOrWhiteSpace(field))
            {
                throw new NullValueException(message);
            }
        }

        public static void CheckIsPercentage(int field, string message)
        {
            if (field < 0 || field > 100)
            {
                throw new IncorrectValueException(message);
            }
        }

        public static void CheckIsShorter(int field, int reference, string message)
        {
            if (field < reference)
            {
                throw new IncorrectValueException(message);
            }
        }
    }
}