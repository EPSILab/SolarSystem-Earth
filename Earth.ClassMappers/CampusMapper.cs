using EPSILab.SolarSystem.Earth.Common.Interfaces;
using CampusDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Campus;
using CampusDTO = EPSILab.SolarSystem.Earth.Common.Campus;

namespace EPSILab.SolarSystem.Earth.Mappers
{
    /// <summary>
    /// Campus mapper
    /// </summary>
    public class CampusMapper : IMapper<CampusDAO, CampusDTO>
    {
        /// <summary>
        /// DAO to DTO
        /// </summary>
        /// <param name="element">Element to transform to DTO</param>
        /// <returns>DTO equivalent</returns>
        public CampusDTO ToDTO(CampusDAO element)
        {
            return new CampusDTO
            {
                Id = element.Id,
                Place = element.Place,
                ContactEmail = element.ContactEmail
            };
        }

        /// <summary>
        /// DTO to DAO
        /// </summary>
        /// <param name="element">Element to transform to DAO</param>
        /// <returns>DAO equivalent</returns>
        public CampusDAO ToDAO(CampusDTO element)
        {
            return new CampusDAO
            {
                Id = element.Id,
                ContactEmail = element.ContactEmail,
                Place = element.Place
            };
        }
    }
}