﻿using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.DataAccess;
using SolarSystem.Earth.Mappers;
using System.Collections.Generic;
using System.Linq;
using PubliciteDAO = SolarSystem.Earth.DataAccess.Model.Publicite;
using PubliciteDTO = SolarSystem.Earth.Common.Publicite;

namespace SolarSystem.Earth.Business
{
    public class PubliciteBusiness : IManager<PubliciteDTO>
    {
        #region Attributes

        private readonly PubliciteDAL _publiciteDAL = new PubliciteDAL();
        private readonly IMapper<PubliciteDAO, PubliciteDTO> _mapper = new PubliciteMapper();

        #endregion

        #region IManager methods

        public PubliciteDTO Get(int code)
        {
            PubliciteDAO dao = _publiciteDAL.Get(code);
            PubliciteDTO dto = _mapper.ToDTO(dao);
            return dto;
        }

        public IEnumerable<PubliciteDTO> Get()
        {
            IEnumerable<PubliciteDAO> dao = _publiciteDAL.Get();
            IEnumerable<PubliciteDTO> dto = dao.Select(p => _mapper.ToDTO(p));

            return dto;
        }

        public IEnumerable<PubliciteDTO> Get(int indexFirstElement, int numberOfResults)
        {
            IEnumerable<PubliciteDAO> dao = _publiciteDAL.Get(indexFirstElement, numberOfResults);
            IEnumerable<PubliciteDTO> dto = dao.Select(p => _mapper.ToDTO(p));

            return dto;
        }

        public int GetLastInsertedId()
        {
            return _publiciteDAL.GetLastInsertedId();
        }

        public int Add(PubliciteDTO element, string username, string password)
        {
            PubliciteDAO dao = _mapper.ToDAO(element);
            return _publiciteDAL.Add(dao, username, password);
        }

        public void Edit(PubliciteDTO element, string username, string password)
        {
            PubliciteDAO dao = _mapper.ToDAO(element);
            _publiciteDAL.Edit(dao, username, password);
        }

        public void Delete(int code, string username, string password)
        {
            _publiciteDAL.Delete(code, username, password);
        }

        #endregion
    }
}