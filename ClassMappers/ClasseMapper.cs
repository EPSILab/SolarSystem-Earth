using SolarSystem.Earth.Common.Interfaces;
using ClasseDAO = SolarSystem.Earth.DataAccess.Model.Classe;
using ClasseDTO = SolarSystem.Earth.Common.Classe;

namespace SolarSystem.Earth.Mappers
{
    /// <summary>
    /// Promo mapper
    /// </summary>
    public class ClasseMapper : IMapper<ClasseDAO, ClasseDTO>
    {
        /// <summary>
        /// DAO to DTO
        /// </summary>
        /// <param name="element">Element to transform to DTO</param>
        /// <returns>DTO equivalent</returns>
        public ClasseDTO ToDTO(ClasseDAO element)
        {
            return new ClasseDTO
            {
                Code_Classe = element.Code_Classe,
                Libelle = element.Libelle,
                Annee_Promo_Sortante = element.Annee_Promo_Sortante,
                Encore_Presente = element.Encore_Presente
            };
        }

        /// <summary>
        /// DTO to DAO
        /// </summary>
        /// <param name="element">Element to transform to DAO</param>
        /// <returns>DAO equivalent</returns>
        public ClasseDAO ToDAO(ClasseDTO element)
        {
            return new ClasseDAO
            {
                Code_Classe = element.Code_Classe,
                Libelle = element.Libelle,
                Annee_Promo_Sortante = element.Annee_Promo_Sortante,
                Encore_Presente = element.Encore_Presente
            };
        }
    }
}