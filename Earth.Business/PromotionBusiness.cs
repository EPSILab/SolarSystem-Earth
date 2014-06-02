using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.DataAccess.DAL;
using EPSILab.SolarSystem.Earth.Mappers;
using System.Collections.Generic;
using System.Linq;
using PromotionDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Promotion;
using PromotionDTO = EPSILab.SolarSystem.Earth.Common.Promotion;

namespace EPSILab.SolarSystem.Earth.Business
{
    /// <summary>
    /// Business class for promos
    /// </summary>
    class PromotionBusiness : IReader<PromotionDTO>, IAvailable<PromotionDTO>, IManager<PromotionDTO>
    {
        #region Attributes

        /// <summary>
        /// DAL access
        /// </summary>
        private readonly PromotionDAL _dal = new PromotionDAL();

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper<PromotionDAO, PromotionDTO> _mapper = new PromotionMapper();

        #endregion

        #region IReader methods

        /// <summary>
        /// Get one promo
        /// </summary>
        /// <param name="code">Promo id</param>
        /// <returns>Matching promo</returns>
        public PromotionDTO Get(int code)
        {
            PromotionDAO dao = _dal.Get(code);
            PromotionDTO dto = _mapper.ToDTO(dao);

            return dto;
        }

        /// <summary>
        /// Returns all promos
        /// </summary>
        /// <returns>List of promos</returns>
        public IEnumerable<PromotionDTO> Get()
        {
            IEnumerable<PromotionDAO> dao = _dal.Get();
            IEnumerable<PromotionDTO> dto = dao.Select(c => _mapper.ToDTO(c));

            return dto;
        }

        /// <summary>
        /// Returns last promo id
        /// </summary>
        /// <returns>Id the last inserted promo</returns>
        public int GetLastInsertedId()
        {
            return _dal.GetLastInsertedId();
        }

        #endregion

        #region IAvailable methods

        /// <summary>
        /// Get all availables promos for new members
        /// </summary>
        /// <returns>List of promos</returns>
        public IEnumerable<PromotionDTO> GetAvailables()
        {
            IEnumerable<PromotionDAO> dao = _dal.GetAvailables();
            IEnumerable<PromotionDTO> dto = dao.Select(c => _mapper.ToDTO(c));

            return dto;
        }

        #endregion

        #region IManager methods

        /// <summary>
        /// Create a promo
        /// </summary>
        /// <param name="element">Promo to create</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        /// <returns>New promo id</returns>
        public int Add(PromotionDTO element, string username, string password)
        {
            PromotionDAO dao = _mapper.ToDAO(element);
            return _dal.Add(dao, username, password);
        }

        /// <summary>
        /// Edit a promo
        /// </summary>
        /// <param name="element">Edited promo</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(PromotionDTO element, string username, string password)
        {
            PromotionDAO dao = _mapper.ToDAO(element);
            _dal.Edit(dao, username, password);
        }

        /// <summary>
        /// Delete a promo
        /// </summary>
        /// <param name="code">Promo id to delete</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Delete(int code, string username, string password)
        {
            _dal.Delete(code, username, password);
        }

        #endregion
    }
}