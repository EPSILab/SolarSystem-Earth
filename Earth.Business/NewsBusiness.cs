using EPSILab.SolarSystem.Earth.Common.Interfaces;
using EPSILab.SolarSystem.Earth.DataAccess.DAL;
using EPSILab.SolarSystem.Earth.Mappers;
using System.Collections.Generic;
using System.Linq;
using MemberDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Member;
using MemberDTO = EPSILab.SolarSystem.Earth.Common.Member;
using NewsDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.News;
using NewsDTO = EPSILab.SolarSystem.Earth.Common.News;

namespace EPSILab.SolarSystem.Earth.Business
{
    /// <summary>
    /// Business class for news
    /// </summary>
    public class NewsBusiness : IReader2Filters<NewsDTO, MemberDTO, bool?>, ISearchable<NewsDTO>, IManager<NewsDTO>
    {
        #region Attributes

        /// <summary>
        /// DAL access
        /// </summary>
        private readonly NewsDAL _dal = new NewsDAL();

        /// <summary>
        /// News mapper
        /// </summary>
        private readonly IMapper<NewsDAO, NewsDTO> _mapperNews = new NewsMapper();

        /// <summary>
        /// Member mapper
        /// </summary>
        private readonly IMapper<MemberDAO, MemberDTO> _mapperMember = new MemberMapper();

        #endregion

        #region IReader2Filters methods

        /// <summary>
        /// Get a news
        /// </summary>
        /// <param name="code">News id</param>
        /// <returns>Matching news</returns>
        public NewsDTO Get(int code)
        {
            NewsDAO dao = _dal.Get(code);
            NewsDTO dto = _mapperNews.ToDTO(dao);

            return dto;
        }

        /// <summary>
        /// Get all news
        /// </summary>
        /// <returns>List of news</returns>
        public IEnumerable<NewsDTO> Get()
        {
            IEnumerable<NewsDAO> dao = _dal.Get();
            IEnumerable<NewsDTO> dto = dao.Select(n => _mapperNews.ToDTO(n));

            return dto;
        }

        /// <summary>
        /// Get a limited list of news
        /// </summary>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>Matching list of news</returns>
        public IEnumerable<NewsDTO> Get(int indexFirstElement, int numberOfResults)
        {
            IEnumerable<NewsDAO> dao = _dal.Get(indexFirstElement, numberOfResults);
            IEnumerable<NewsDTO> dto = dao.Select(n => _mapperNews.ToDTO(n));

            return dto;
        }

        /// <summary>
        /// Get a member's news
        /// </summary>
        /// <param name="author">Author</param>
        /// <returns>Matching news</returns>
        public IEnumerable<NewsDTO> Get(MemberDTO author)
        {
            MemberDAO memberDao = _mapperMember.ToDAO(author);

            IEnumerable<NewsDAO> dao = _dal.Get(memberDao);
            IEnumerable<NewsDTO> dto = dao.Select(n => _mapperNews.ToDTO(n));

            return dto;
        }

        /// <summary>
        /// Get a limited list of a member's news
        /// </summary>
        /// <param name="author">Author</param>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>Matching list of news</returns>
        public IEnumerable<NewsDTO> Get(MemberDTO author, int indexFirstElement, int numberOfResults)
        {
            MemberDAO memberDao = _mapperMember.ToDAO(author);

            IEnumerable<NewsDAO> dao = _dal.Get(memberDao, indexFirstElement, numberOfResults);
            IEnumerable<NewsDTO> dto = dao.Select(n => _mapperNews.ToDTO(n));

            return dto;
        }

        /// <summary>
        /// Get all/published/not published news
        /// </summary>
        /// <param name="published">Determines if news must be published, not published or indifferent</param>
        /// <returns>List of news</returns>
        public IEnumerable<NewsDTO> Get(bool? published)
        {
            IEnumerable<NewsDAO> dao = _dal.Get(published);
            IEnumerable<NewsDTO> dto = dao.Select(n => _mapperNews.ToDTO(n));

            return dto;
        }

        /// <summary>
        /// Get a limited list of all/published/not published news
        /// </summary>
        /// <param name="published">Determines if news must be published, not published or indifferent</param>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of news</returns>
        public IEnumerable<NewsDTO> Get(bool? published, int indexFirstElement, int numberOfResults)
        {
            IEnumerable<NewsDAO> dao = _dal.Get(published, indexFirstElement, numberOfResults);
            IEnumerable<NewsDTO> dto = dao.Select(n => _mapperNews.ToDTO(n));

            return dto;
        }

        /// <summary>
        /// Get a all/published/not published member's news
        /// </summary>
        /// <param name="author">Author</param>
        /// <param name="published">Determines if news must be published, not published or indifferent</param>
        /// <returns>List of news</returns>
        public IEnumerable<NewsDTO> Get(MemberDTO author, bool? published)
        {
            MemberDAO memberDao = _mapperMember.ToDAO(author);

            IEnumerable<NewsDAO> dao = _dal.Get(memberDao, published);
            IEnumerable<NewsDTO> dto = dao.Select(n => _mapperNews.ToDTO(n));

            return dto;
        }

        /// <summary>
        /// Get a limited list of a member's all/published/not published news
        /// </summary>
        /// <param name="author">Author</param>
        /// <param name="published">Determines if news must be published, not published or indifferent</param>
        /// <param name="indexFirstElement">Index of the first result</param>
        /// <param name="numberOfResults">Number of results</param>
        /// <returns>List of news</returns>
        public IEnumerable<NewsDTO> Get(MemberDTO author, bool? published, int indexFirstElement, int numberOfResults)
        {
            MemberDAO memberDao = _mapperMember.ToDAO(author);

            IEnumerable<NewsDAO> dao = _dal.Get(memberDao, published, indexFirstElement, numberOfResults);
            IEnumerable<NewsDTO> dto = dao.Select(n => _mapperNews.ToDTO(n));

            return dto;
        }

        /// <summary>
        /// Returns last news id
        /// </summary>
        /// <returns>Id the last inserted news</returns>
        public int GetLastInsertedId()
        {
            return _dal.GetLastInsertedId();
        }

        #endregion

        #region ISearchable methods

        /// <summary>
        /// Returns all news matching to a keyword
        /// </summary>
        /// <param name="keywords">Search keywords separated by a space</param>
        /// <returns>List of matching news</returns>
        public IEnumerable<NewsDTO> Search(string keywords)
        {
            IEnumerable<NewsDAO> dao = _dal.Search(keywords);
            IEnumerable<NewsDTO> dto = dao.Select(n => _mapperNews.ToDTO(n));

            return dto;
        }

        #endregion

        #region IManager methods

        /// <summary>
        /// Create a news
        /// </summary>
        /// <param name="element">News to create</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        /// <returns>New news id</returns>
        public int Add(NewsDTO element, string username, string password)
        {
            NewsDAO dao = _mapperNews.ToDAO(element);
            return _dal.Add(dao, username, password);
        }

        /// <summary>
        /// Edit a news
        /// </summary>
        /// <param name="element">Edited news</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Edit(NewsDTO element, string username, string password)
        {
            NewsDAO dao = _mapperNews.ToDAO(element);
            _dal.Edit(dao, username, password);
        }

        /// <summary>
        /// Delete a news
        /// </summary>
        /// <param name="code">News id to delete</param>
        /// <param name="username">Username of an existing member</param>
        /// <param name="password">Password of an existing member</param>
        public void Delete(int code, string username, string password)
        {
            _dal.Delete(code, username, password);
        }

        #endregion
    }
}