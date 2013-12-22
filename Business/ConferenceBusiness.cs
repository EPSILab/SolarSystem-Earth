using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.DataAccess;
using SolarSystem.Earth.Mappers;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using ConferenceDAO = SolarSystem.Earth.DataAccess.Model.Conference;
using ConferenceDTO = SolarSystem.Earth.Common.Conference;
using VilleDAO = SolarSystem.Earth.DataAccess.Model.Ville;
using VilleDTO = SolarSystem.Earth.Common.Ville;

namespace SolarSystem.Earth.Business
{
    public class ConferenceBusiness : IReaderOneFilter<ConferenceDTO, VilleDTO>, IManager<ConferenceDTO>, ISearchable<ConferenceDTO>
    {
        #region Attributes

        private readonly ConferenceDAL _conferenceDAL = new ConferenceDAL();
        private readonly  VilleDAL _villeDAL = new VilleDAL();
        private readonly IMapper<ConferenceDAO, ConferenceDTO> _mapper = new ConferenceMapper();

        #endregion

        #region IReadableOneFilter methods

        public ConferenceDTO Get(int code)
        {
            ConferenceDAO dao = _conferenceDAL.Get(code);
            ConferenceDTO dto = _mapper.ToDTO(dao);

            return dto;
        }

        public IEnumerable<ConferenceDTO> Get()
        {
            IEnumerable<ConferenceDAO> dao = _conferenceDAL.Get();
            IEnumerable<ConferenceDTO> dto = dao.Select(c => _mapper.ToDTO(c));

            return dto; 
        }

        public IEnumerable<ConferenceDTO> Get(int indexFirstElement, int numberOfResults)
        {
            IEnumerable<ConferenceDAO> dao = _conferenceDAL.Get(indexFirstElement, numberOfResults);
            IEnumerable<ConferenceDTO> dto = dao.Select(c => _mapper.ToDTO(c));

            return dto; 
        }

        public IEnumerable<ConferenceDTO> Get(int indexFirstElement, int numberOfResults, SortOrder order)
        {
            IEnumerable<ConferenceDAO> dao = _conferenceDAL.Get(indexFirstElement, numberOfResults, order);
            IEnumerable<ConferenceDTO> dto = dao.Select(c => _mapper.ToDTO(c));

            return dto;
        }

        public IEnumerable<ConferenceDTO> Get(VilleDTO filter, int indexFirstElement, int numberOfResults, SortOrder order)
        {
            VilleDAO filterDao = null;

            if (filter != null)
            {
                filterDao = _villeDAL.Get(filter.Code_Ville);
            }

            IEnumerable<ConferenceDAO> dao = _conferenceDAL.Get(filterDao, indexFirstElement, numberOfResults, order);
            return dao.Select(c => _mapper.ToDTO(c));
        }

        public int GetLastInsertedId()
        {
            return _conferenceDAL.GetLastInsertedId();
        }

        #endregion

        #region IManager methods

        public IEnumerable<ConferenceDTO> Get(int indexFirstResult, int numberOfResults, string username, string password)
        {
            IEnumerable<ConferenceDAO> dao = _conferenceDAL.Get(indexFirstResult, numberOfResults, username, password);
            IEnumerable<ConferenceDTO> dto = dao.Select(c => _mapper.ToDTO(c));

            return dto; 
        }

        public ConferenceDTO Get(int code, string username, string password)
        {
            ConferenceDAO dao = _conferenceDAL.Get(code, username, password);
            ConferenceDTO dto = _mapper.ToDTO(dao);

            return dto;
        }

        public int Add(ConferenceDTO element, string username, string password)
        {
            ConferenceDAO dao = _mapper.ToDAO(element);
            return _conferenceDAL.Add(dao, username, password);
        }

        public void Edit(ConferenceDTO element, string username, string password)
        {
            ConferenceDAO dao = _mapper.ToDAO(element);
            _conferenceDAL.Edit(dao, username, password);
        }

        public void Delete(int code, string username, string password)
        {
            _conferenceDAL.Delete(code, username, password);
        }

        #endregion

        #region ISearchable methods

        public IEnumerable<ConferenceDTO> Search(string keywords)
        {
            IEnumerable<ConferenceDAO> dao = _conferenceDAL.Search(keywords);
            return dao.Select(c => _mapper.ToDTO(c));
        }

        #endregion
    }
}