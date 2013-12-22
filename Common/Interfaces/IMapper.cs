namespace SolarSystem.Earth.Common.Interfaces
{
    public interface IMapper<TKey, TValue>
    {
        TValue ToDTO(TKey element);
        TKey ToDAO(TValue element);
    }
}