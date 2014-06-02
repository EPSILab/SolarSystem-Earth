using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.DataAccess.Model;

namespace EPSILab.SolarSystem.Earth.DataAccess.DAL.Abstract
{
    public interface IMemberDAL : IMemberReader<Member, Campus>, ISearchable<Member>, ILogin<Member, LostPasswordRequest>, IManager<Member>
    {
    }
}
