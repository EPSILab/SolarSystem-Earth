using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.DataAccess;
using SolarSystem.Earth.Mappers;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ProjetDAO = SolarSystem.Earth.DataAccess.Model.Projet;
using ProjetDTO = SolarSystem.Earth.Common.Projet;
using VilleDAO = SolarSystem.Earth.DataAccess.Model.Ville;
using VilleDTO = SolarSystem.Earth.Common.Ville;

namespace SolarSystem.Earth.Business
{
    public class ProjetBusiness : IReaderOneFilter<ProjetDTO, VilleDTO>, IManager<ProjetDTO>
    {
        #region Attributes

        private readonly ProjetDAL _projetDAL = new ProjetDAL();
        private readonly VilleDAL _villeDAL = new VilleDAL();
        private readonly IMapper<ProjetDAO, ProjetDTO> _mapper = new ProjetMapper();

        #endregion

        #region IReaderOneFilter methods

        public ProjetDTO Get(int code)
        {
            ProjetDAO dao = _projetDAL.Get(code);
            ProjetDTO dto = _mapper.ToDTO(dao);

            return dto;
        }

        public IEnumerable<ProjetDTO> Get()
        {
            IEnumerable<ProjetDAO> dao = _projetDAL.Get();
            IEnumerable<ProjetDTO> dto = dao.Select(p => _mapper.ToDTO(p));

            return dto;
        }

        public IEnumerable<ProjetDTO> Get(int indexFirstElement, int numberOfResults)
        {
            IEnumerable<ProjetDAO> dao = _projetDAL.Get(indexFirstElement, numberOfResults, SortOrder.Ascending);
            IEnumerable<ProjetDTO> dto = dao.Select(p => _mapper.ToDTO(p));

            return dto;
        }

        public IEnumerable<ProjetDTO> Get(int indexFirstElement, int numberOfResults, SortOrder order)
        {
            IEnumerable<ProjetDAO> dao = _projetDAL.Get(indexFirstElement, numberOfResults, order);
            IEnumerable<ProjetDTO> dto = dao.Select(p => _mapper.ToDTO(p));

            return dto;
        }

        public IEnumerable<ProjetDTO> Get(VilleDTO filter, int indexFirstElement, int numberOfResults, SortOrder order)
        {
            VilleDAO villeDao = null;

            if (filter != null)
            {
                villeDao = _villeDAL.Get(filter.Code_Ville);
            }

            IEnumerable<ProjetDAO> dao = _projetDAL.Get(villeDao, indexFirstElement, numberOfResults, order);
            IEnumerable<ProjetDTO> dto = dao.Select(p => _mapper.ToDTO(p));

            return dto;
        }

        public int GetLastInsertedId()
        {
            return _projetDAL.GetLastInsertedId();
        }

        #endregion

        #region IManager methods

        public int Add(ProjetDTO element, string username, string password)
        {
            ProjetDAO dao = _mapper.ToDAO(element);
            return _projetDAL.Add(dao, username, password);
        }

        public void Edit(ProjetDTO element, string username, string password)
        {
            ProjetDAO dao = _mapper.ToDAO(element);
            _projetDAL.Edit(dao, username, password);
        }

        public void Delete(int code, string username, string password)
        {
            _projetDAL.Delete(code, username, password);
        }

        #endregion
    }
}