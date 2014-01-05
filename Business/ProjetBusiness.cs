using System.Collections.Generic;
using System.Linq;
using SolarSystem.Earth.Common.Interfaces;
using SolarSystem.Earth.DataAccess.DataAccess;
using SolarSystem.Earth.Mappers;
using ProjetDAO = SolarSystem.Earth.DataAccess.Model.Projet;
using ProjetDTO = SolarSystem.Earth.Common.Projet;
using VilleDAO = SolarSystem.Earth.DataAccess.Model.Ville;
using VilleDTO = SolarSystem.Earth.Common.Ville;

namespace SolarSystem.Earth.Business
{
    public class ProjetBusiness : IReader1Filter<ProjetDTO, VilleDTO>, IManager<ProjetDTO>
    {
        #region Attributes

        private readonly ProjetDAL _projetDAL = new ProjetDAL();

        private readonly IMapper<ProjetDAO, ProjetDTO> _mapperProjet = new ProjetMapper();
        private readonly IMapper<VilleDAO, VilleDTO> _mapperVille = new VilleMapper();

        #endregion

        #region IReader1Filter methods

        public ProjetDTO Get(int code)
        {
            ProjetDAO dao = _projetDAL.Get(code);
            ProjetDTO dto = _mapperProjet.ToDTO(dao);

            return dto;
        }

        public IEnumerable<ProjetDTO> Get()
        {
            IEnumerable<ProjetDAO> dao = _projetDAL.Get();
            IEnumerable<ProjetDTO> dto = dao.Select(p => _mapperProjet.ToDTO(p));

            return dto;
        }

        public IEnumerable<ProjetDTO> Get(int indexFirstElement, int numberOfResults)
        {
            IEnumerable<ProjetDAO> dao = _projetDAL.Get(indexFirstElement, numberOfResults);
            IEnumerable<ProjetDTO> dto = dao.Select(p => _mapperProjet.ToDTO(p));

            return dto;
        }

        public IEnumerable<ProjetDTO> Get(VilleDTO ville)
        {
            VilleDAO villeDao = _mapperVille.ToDAO(ville);

            IEnumerable<ProjetDAO> dao = _projetDAL.Get(villeDao);
            IEnumerable<ProjetDTO> dto = dao.Select(p => _mapperProjet.ToDTO(p));

            return dto;
        }

        public IEnumerable<ProjetDTO> Get(VilleDTO ville, int indexFirstResult, int numberOfResults)
        {
            VilleDAO villeDao = _mapperVille.ToDAO(ville);

            IEnumerable<ProjetDAO> dao = _projetDAL.Get(villeDao, indexFirstResult, numberOfResults);
            IEnumerable<ProjetDTO> dto = dao.Select(p => _mapperProjet.ToDTO(p));

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
            ProjetDAO dao = _mapperProjet.ToDAO(element);
            return _projetDAL.Add(dao, username, password);
        }

        public void Edit(ProjetDTO element, string username, string password)
        {
            ProjetDAO dao = _mapperProjet.ToDAO(element);
            _projetDAL.Edit(dao, username, password);
        }

        public void Delete(int code, string username, string password)
        {
            _projetDAL.Delete(code, username, password);
        }

        #endregion
    }
}