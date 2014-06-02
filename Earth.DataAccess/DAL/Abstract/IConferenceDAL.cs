using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.DataAccess.Model;

namespace EPSILab.SolarSystem.Earth.DataAccess.DAL.Abstract
{
    public interface IConferenceDAL : IReader2Filters<Conference, Campus, bool?>, ISearchable<Conference>, IManager<Conference>
    {
    }
}
