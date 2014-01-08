namespace SolarSystem.Earth.Common.Interfaces
{
    /// <summary>
    /// An interface to map DTO to DAO and vice versa
    /// </summary>
    /// <typeparam name="TKey">A SunModel entity</typeparam>
    /// <typeparam name="TValue">A Common entity</typeparam>
    public interface IMapper<TKey, TValue>
    {
        TValue ToDTO(TKey element);
        TKey ToDAO(TValue element);
    }
}