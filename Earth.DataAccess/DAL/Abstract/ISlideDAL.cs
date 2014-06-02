using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.DataAccess.Model;

namespace EPSILab.SolarSystem.Earth.DataAccess.DAL.Abstract
{
    public interface ISlideDAL : IReader1Filter<Slide, bool?>, IManager<Slide>
    {
    }
}
