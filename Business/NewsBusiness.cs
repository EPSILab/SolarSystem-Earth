using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.DataAccess;
using SolarSystem.Earth.Mappers;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using NewsDAO = SolarSystem.Earth.DataAccess.Model.News;
using NewsDTO = SolarSystem.Earth.Common.News;

namespace SolarSystem.Earth.Business
{
    public class NewsBusiness : IReaderSort<NewsDTO>, ISearchable<NewsDTO>, IManager<NewsDTO>
    {
        #region Attributes

        private readonly NewsDAL _newsDAL = new NewsDAL();
        private readonly IMapper<NewsDAO, NewsDTO> _mapper = new NewsMapper();

        #endregion

        #region IReadableSortable methods

        public NewsDTO Get(int code)
        {
            NewsDAO dao = _newsDAL.Get(code);
            NewsDTO dto = _mapper.ToDTO(dao);

            return dto;
        }

        public IEnumerable<NewsDTO> Get()
        {
            IEnumerable<NewsDAO> dao = _newsDAL.Get();
            IEnumerable<NewsDTO> dto = dao.Select(n => _mapper.ToDTO(n));

            return dto;
        }

        public IEnumerable<NewsDTO> Get(int indexFirstElement, int numberOfResults)
        {
            IEnumerable<NewsDAO> dao = _newsDAL.Get(indexFirstElement, numberOfResults);
            IEnumerable<NewsDTO> dto = dao.Select(n => _mapper.ToDTO(n));

            return dto;
        }

        public IEnumerable<NewsDTO> Get(int indexFirstElement, int numberOfResults, SortOrder order)
        {
            IEnumerable<NewsDAO> dao = _newsDAL.Get(indexFirstElement, numberOfResults, order);
            IEnumerable<NewsDTO> dto = dao.Select(n => _mapper.ToDTO(n));

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
            IEnumerable<NewsDTO> dto = dao.Select(n => _mapper.ToDTO(n));

            return dto;
        }

        #endregion

        #region ICrudable methods

        public IEnumerable<NewsDTO> Get(int indexFirstResult, int numberOfResults, string username, string password)
        {
            IEnumerable<NewsDAO> dao = _newsDAL.Get(indexFirstResult, numberOfResults, username, password);
            IEnumerable<NewsDTO> dto = dao.Select(n => _mapper.ToDTO(n));

            return dto;
        }

        public NewsDTO Get(int code, string username, string password)
        {
            NewsDAO dao = _newsDAL.Get(code, username, password);
            NewsDTO dto =  _mapper.ToDTO(dao);

            return dto;
        }

        public int Add(NewsDTO element, string username, string password)
        {
            NewsDAO dao = _mapper.ToDAO(element);
            return _newsDAL.Add(dao, username, password);
        }

        public void Edit(NewsDTO news, string username, string password)
        {
            NewsDAO dao = _mapper.ToDAO(news);
            _newsDAL.Edit(dao, username, password);
        }

        public void Delete(int code, string username, string password)
        {
            _newsDAL.Delete(code, username, password);
        }

        #endregion
    }
}