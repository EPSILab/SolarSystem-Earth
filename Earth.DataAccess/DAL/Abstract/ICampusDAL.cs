using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.DataAccess.Model;

namespace EPSILab.SolarSystem.Earth.DataAccess.DAL.Abstract
{
    public interface ICampusDAL : IReader<Campus>, IManager<Campus>
    {
    }
}
