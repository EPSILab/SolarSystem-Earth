using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.DAL;
using SolarSystem.Earth.Mappers;
using System.Collections.Generic;
using System.Linq;
using ClasseDAO = SolarSystem.Earth.DataAccess.Model.Classe;
using ClasseDTO = SolarSystem.Earth.Common.Classe;

namespace SolarSystem.Earth.Business
{
    /// <summary>
    /// Business class for promos
    /// </summary>
    public class ClasseBusiness : IReader<ClasseDTO>, IAvailable<ClasseDTO>, IManager<ClasseDTO>
    {
        #region Attributes

        /// <summary>
        /// DAL access
        /// </summary>
        private readonly ClasseDAL _dal = new ClasseDAL();

        /// <summary>
        /// Mapper
        /// </summary>
        private readonly IMapper<ClasseDAO, ClasseDTO> _mapper = new ClasseMapper();

        #endregion

        #region IReader methods

        /// <summary>
        /// Get one promo
        /// </summary>
        /// <param name="code">Promo id</param>
        /// <returns>Matching promo</returns>
        public ClasseDTO Get(int code)
        {
            ClasseDAO dao = _dal.Get(code);
            ClasseDTO dto = _mapper.ToDTO(dao);

            return dto;
        }

        /// <summary>
        /// Returns all promos
        /// </summary>
        /// <returns>List of promos</returns>
        public IEnumerable<ClasseDTO> Get()
        {
            IEnumerable<ClasseDAO> dao = _dal.Get();
            IEnumerable<ClasseDTO> dto = dao.Select(c => _mapper.ToDTO(c));

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
        public IEnumerable<ClasseDTO> GetAvailables()
        {
            IEnumerable<ClasseDAO> dao = _dal.GetAvailables();
            IEnumerable<ClasseDTO> dto = dao.Select(c => _mapper.ToDTO(c));

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
        public int Add(ClasseDTO element, string username, string password)
        {
            ClasseDAO dao = _mapper.ToDAO(element);
            return _dal.Add(dao, username, password);
        }

        /// <summary>
        /// Edit a promo
        /// </summary>
        /// <param name="element">Edited promo</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(ClasseDTO element, string username, string password)
        {
            ClasseDAO dao = _mapper.ToDAO(element);
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