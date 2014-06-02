using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.DataAccess.Model;

namespace EPSILab.SolarSystem.Earth.DataAccess.DAL.Abstract
{
    public interface IShowDAL : IReader1Filter<Show, bool?>, ISearchable<Show>, IManager<Show>
    {
    }
}
