namespace SolarSystem.Earth.DataAccess.RulesManager
{
    interface IRulesManager<in T>
    {
        void Check(T element);
    }
}