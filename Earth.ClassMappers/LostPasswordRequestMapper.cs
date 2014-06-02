using EPSILab.SolarSystem.Earth.Common.Interfaces;
using LostPasswordRequestDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.LostPasswordRequest;
using LostPasswordRequestDTO = EPSILab.SolarSystem.Earth.Common.LostPasswordRequest;

namespace EPSILab.SolarSystem.Earth.Mappers
{
    /// <summary>
    /// Lost password request mapper
    /// </summary>
    class LostPasswordRequestMapper : IMapper<LostPasswordRequestDAO, LostPasswordRequestDTO>
    {
        /// <summary>
        /// DAO to DTO
        /// </summary>
        /// <param name="element">Element to transform to DTO</param>
        /// <returns>DTO equivalent</returns>
        public LostPasswordRequestDTO ToDTO(LostPasswordRequestDAO element)
        {
            return new LostPasswordRequestDTO
            {
                GeneratedKey = element.GeneratedKey,
                RequestDateTime = element.RequestDateTime,
                Id = element.Id,
                Member = new MemberMapper().ToDTO(element.Member)
            };
        }

        /// <summary>
        /// DTO to DAO
        /// </summary>
        /// <param name="element">Element to transform to DAO</param>
        /// <returns>DAO equivalent</returns>
        public LostPasswordRequestDAO ToDAO(LostPasswordRequestDTO element)
        {
            return new LostPasswordRequestDAO
            {
                GeneratedKey = element.GeneratedKey,
                RequestDateTime = element.RequestDateTime,
                Id = element.Id,
                MemberId = element.Member.Id
            };
        }
    }
}