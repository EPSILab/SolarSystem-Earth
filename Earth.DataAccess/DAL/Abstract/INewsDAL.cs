using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.DataAccess.Model;

namespace EPSILab.SolarSystem.Earth.DataAccess.DAL.Abstract
{
    public interface INewsDAL : IReader2Filters<News, Member, bool?>, ISearchable<News>, IManager<News>
    {
    }
}
