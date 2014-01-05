using System.Collections.Generic;
using System.Linq;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.DataAccess;
using SolarSystem.Earth.Mappers;
using MembreDAO = SolarSystem.Earth.DataAccess.Model.Membre;
using MembreDTO = SolarSystem.Earth.Common.Membre;
using NewsDAO = SolarSystem.Earth.DataAccess.Model.News;
using NewsDTO = SolarSystem.Earth.Common.News;

namespace SolarSystem.Earth.Business
{
    public class NewsBusiness : IReader2Filters<NewsDTO, MembreDTO, bool?>, ISearchable<NewsDTO>, IManager<NewsDTO>
    {
        #region Attributes

        private readonly NewsDAL _newsDAL = new NewsDAL();

        private readonly IMapper<NewsDAO, NewsDTO> _mapperNews = new NewsMapper();
        private readonly IMapper<MembreDAO, MembreDTO> _mapperMembre = new MembreMapper();

        #endregion

        #region IReader2Filters methods

        public NewsDTO Get(int code)
        {
            NewsDAO dao = _newsDAL.Get(code);
            NewsDTO dto = _mapperNews.ToDTO(dao);

            return dto;
        }

        public IEnumerable<NewsDTO> Get()
        {
            IEnumerable<NewsDAO> dao = _newsDAL.Get();
            IEnumerable<NewsDTO> dto = dao.Select(n => _mapperNews.ToDTO(n));

            return dto;
        }

        public IEnumerable<NewsDTO> Get(int indexFirstElement, int numberOfResults)
        {
            IEnumerable<NewsDAO> dao = _newsDAL.Get(indexFirstElement, numberOfResults);
            IEnumerable<NewsDTO> dto = dao.Select(n => _mapperNews.ToDTO(n));

            return dto;
        }

        public IEnumerable<NewsDTO> Get(bool? published)
        {
            IEnumerable<NewsDAO> dao = _newsDAL.Get(published);
            IEnumerable<NewsDTO> dto = dao.Select(n => _mapperNews.ToDTO(n));

            return dto;
        }

        public IEnumerable<NewsDTO> Get(bool? published, int indexFirstResult, int numberOfResults)
        {
            IEnumerable<NewsDAO> dao = _newsDAL.Get(published, indexFirstResult, numberOfResults);
            IEnumerable<NewsDTO> dto = dao.Select(n => _mapperNews.ToDTO(n));

            return dto;
        }

        public IEnumerable<NewsDTO> Get(MembreDTO membre)
        {
            MembreDAO membreDao = _mapperMembre.ToDAO(membre);

            IEnumerable<NewsDAO> dao = _newsDAL.Get(membreDao);
            IEnumerable<NewsDTO> dto = dao.Select(n => _mapperNews.ToDTO(n));

            return dto;
        }

        public IEnumerable<NewsDTO> Get(MembreDTO membre, int indexFirstResult, int numberOfResults)
        {
            MembreDAO membreDao = _mapperMembre.ToDAO(membre);

            IEnumerable<NewsDAO> dao = _newsDAL.Get(membreDao, indexFirstResult, numberOfResults);
            IEnumerable<NewsDTO> dto = dao.Select(n => _mapperNews.ToDTO(n));

            return dto;
        }

        public IEnumerable<NewsDTO> Get(MembreDTO membre, bool? published)
        {
            MembreDAO membreDao = _mapperMembre.ToDAO(membre);

            IEnumerable<NewsDAO> dao = _newsDAL.Get(membreDao, published);
            IEnumerable<NewsDTO> dto = dao.Select(n => _mapperNews.ToDTO(n));

            return dto;
        }

        public IEnumerable<NewsDTO> Get(MembreDTO membre, bool? published, int indexFirstResult, int numberOfResults)
        {
            MembreDAO membreDao = _mapperMembre.ToDAO(membre);

            IEnumerable<NewsDAO> dao = _newsDAL.Get(membreDao, published, indexFirstResult, numberOfResults);
            IEnumerable<NewsDTO> dto = dao.Select(n => _mapperNews.ToDTO(n));

            return dto;
        }

        public int GetLastInsertedId()
        {
            return _newsDAL.GetLastInsertedId();
        }

        #endregion

        #region ISearchable methods

        public IEnumerable<NewsDTO> Search(string keyword)
        {
            IEnumerable<NewsDAO> dao = _newsDAL.Search(keyword);
            IEnumerable<NewsDTO> dto = dao.Select(n => _mapperNews.ToDTO(n));

            return dto;
        }

        #endregion

        #region IManager methods

        public int Add(NewsDTO element, string username, string password)
        {
            NewsDAO dao = _mapperNews.ToDAO(element);
            return _newsDAL.Add(dao, username, password);
        }

        public void Edit(NewsDTO news, string username, string password)
        {
            NewsDAO dao = _mapperNews.ToDAO(news);
            _newsDAL.Edit(dao, username, password);
        }

        public void Delete(int code, string username, string password)
        {
            _newsDAL.Delete(code, username, password);
        }

        #endregion
    }
}