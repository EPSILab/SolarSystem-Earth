using EPSILab.SolarSystem.Earth.Common.Interfaces;
using MemberDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.Member;
using MemberDTO = EPSILab.SolarSystem.Earth.Common.Member;
using NewsDAO = EPSILab.SolarSystem.Earth.DataAccess.Model.News;
using NewsDTO = EPSILab.SolarSystem.Earth.Common.News;

namespace EPSILab.SolarSystem.Earth.Mappers
{
    /// <summary>
    /// News mapper
    /// </summary>
    class NewsMapper : IMapper<NewsDAO, NewsDTO>
    {
        #region Attributes

        /// <summary>
        /// Mapper for news
        /// </summary>
        private readonly IMapper<MemberDAO, MemberDTO> _mapperMember = new MemberMapper();

        #endregion

        #region Methods

        /// <summary>
        /// DAO to DTO
        /// </summary>
        /// <param name="element">Element to transform to DTO</param>
        /// <returns>DTO equivalent</returns>
        public NewsDTO ToDTO(NewsDAO element)
        {
            return new NewsDTO
            {
                Id = element.Id,
                Title = element.Title,
                ShortText = element.ShortText,
                Text = element.Text,
                DateTime = element.DateTime,
                ImageUrl = element.ImageUrl,
                Keywords = element.Keywords,
                IsPublished = element.IsPublished,
                Url = element.Url,
                Member = _mapperMember.ToDTO(element.Member)
            };
        }

        /// <summary>
        /// DTO to DAO
        /// </summary>
        /// <param name="element">Element to transform to DAO</param>
        /// <returns>DAO equivalent</returns>
        public NewsDAO ToDAO(NewsDTO element)
        {
            return new NewsDAO
            {
                Id = element.Id,
                IdAuthor = element.Member.Id,
                DateTime = element.DateTime,
                ImageUrl = element.ImageUrl,
                Keywords = element.Keywords,
                ShortText = element.ShortText,
                Text = element.Text,
                Title = element.Title,
                IsPublished = element.IsPublished,
                Url = element.Url
            };
        }

        #endregion
    }
}