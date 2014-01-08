namespace SolarSystem.Earth.DataAccess.RulesManager.Managers.Interfaces
{
    /// <summary>
    /// Generic interface for rules checkers
    /// </summary>
    /// <typeparam name="T">Earth entity to check</typeparam>
    interface IRulesManager<in T>
    {
        /// <summary>
        /// Check if entity is correct
        /// </summary>
        /// <param name="element">Element to check</param>
        void Check(T element);
    }
}