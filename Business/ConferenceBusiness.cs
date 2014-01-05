using System.Collections.Generic;
using System.Linq;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.DataAccess;
using SolarSystem.Earth.Mappers;
using ConferenceDAO = SolarSystem.Earth.DataAccess.Model.Conference;
using ConferenceDTO = SolarSystem.Earth.Common.Conference;
using VilleDAO = SolarSystem.Earth.DataAccess.Model.Ville;
using VilleDTO = SolarSystem.Earth.Common.Ville;

namespace SolarSystem.Earth.Business
{
    public class ConferenceBusiness : IReader2Filters<ConferenceDTO, VilleDTO, bool?>, ISearchable<ConferenceDTO>, IManager<ConferenceDTO>
    {
        #region Attributes

        private readonly ConferenceDAL _conferenceDAL = new ConferenceDAL();

        private readonly IMapper<ConferenceDAO, ConferenceDTO> _mapperConference = new ConferenceMapper();
        private readonly IMapper<VilleDAO, VilleDTO> _mapperVille = new VilleMapper();

        #endregion

        #region IReader2Filters methods

        public ConferenceDTO Get(int code)
        {
            ConferenceDAO dao = _conferenceDAL.Get(code);
            ConferenceDTO dto = _mapperConference.ToDTO(dao);

            return dto;
        }

        public IEnumerable<ConferenceDTO> Get()
        {
            IEnumerable<ConferenceDAO> dao = _conferenceDAL.Get();
            IEnumerable<ConferenceDTO> dto = dao.Select(c => _mapperConference.ToDTO(c));

            return dto;
        }

        public IEnumerable<ConferenceDTO> Get(int indexFirstElement, int numberOfResults)
        {
            IEnumerable<ConferenceDAO> dao = _conferenceDAL.Get(indexFirstElement, numberOfResults);
            IEnumerable<ConferenceDTO> dto = dao.Select(c => _mapperConference.ToDTO(c));

            return dto;
        }

        public IEnumerable<ConferenceDTO> Get(bool? active)
        {
            IEnumerable<ConferenceDAO> dao = _conferenceDAL.Get(active);
            IEnumerable<ConferenceDTO> dto = dao.Select(c => _mapperConference.ToDTO(c));

            return dto;
        }

        public IEnumerable<ConferenceDTO> Get(bool? active, int indexFirstResult, int numberOfResults)
        {
            IEnumerable<ConferenceDAO> dao = _conferenceDAL.Get(active, indexFirstResult, numberOfResults);
            IEnumerable<ConferenceDTO> dto = dao.Select(c => _mapperConference.ToDTO(c));

            return dto;
        }

        public IEnumerable<ConferenceDTO> Get(VilleDTO ville, bool? active)
        {
            VilleDAO villeDao = _mapperVille.ToDAO(ville);

            IEnumerable<ConferenceDAO> dao = _conferenceDAL.Get(villeDao, active);
            IEnumerable<ConferenceDTO> dto = dao.Select(c => _mapperConference.ToDTO(c));

            return dto;
        }

        public IEnumerable<ConferenceDTO> Get(VilleDTO ville, bool? active, int indexFirstResult, int numberOfResults)
        {
            VilleDAO villeDao = _mapperVille.ToDAO(ville);

            IEnumerable<ConferenceDAO> dao = _conferenceDAL.Get(villeDao, active, indexFirstResult, numberOfResults);
            IEnumerable<ConferenceDTO> dto = dao.Select(c => _mapperConference.ToDTO(c));

            return dto;
        }

        public IEnumerable<ConferenceDTO> Get(VilleDTO ville)
        {
            VilleDAO villeDao = _mapperVille.ToDAO(ville);

            IEnumerable<ConferenceDAO> dao = _conferenceDAL.Get(villeDao);
            IEnumerable<ConferenceDTO> dto = dao.Select(c => _mapperConference.ToDTO(c));

            return dto;
        }

        public IEnumerable<ConferenceDTO> Get(VilleDTO ville, int indexFirstResult, int numberOfResults)
        {
            VilleDAO villeDao = _mapperVille.ToDAO(ville);

            IEnumerable<ConferenceDAO> dao = _conferenceDAL.Get(villeDao, indexFirstResult, numberOfResults);
            IEnumerable<ConferenceDTO> dto = dao.Select(c => _mapperConference.ToDTO(c));

            return dto;
        }

        public int GetLastInsertedId()
        {
            return _conferenceDAL.GetLastInsertedId();
        }

        #endregion

        #region IManager methods

        public int Add(ConferenceDTO element, string username, string password)
        {
            ConferenceDAO dao = _mapperConference.ToDAO(element);
            return _conferenceDAL.Add(dao, username, password);
        }

        public void Edit(ConferenceDTO element, string username, string password)
        {
            ConferenceDAO dao = _mapperConference.ToDAO(element);
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
            return dao.Select(c => _mapperConference.ToDTO(c));
        }

        #endregion
    }
}