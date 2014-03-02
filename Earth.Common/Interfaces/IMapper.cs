namespace EPSILab.SolarSystem.Earth.Common.Interfaces
{
    /// <summary>
    /// An interface to map DTO to DAO and vice versa
    /// </summary>
    /// <typeparam name="TDAO">A SunModel entity</typeparam>
    /// <typeparam name="TDTO">A Common entity</typeparam>
    public interface IMapper<TDAO, TDTO>
    {
        TDTO ToDTO(TDAO element);
        TDAO ToDAO(TDTO element);
    }
}