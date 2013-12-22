using SolarSystem.Earth.Common.Interfaces;
using ClasseDAO = SolarSystem.Earth.DataAccess.Model.Classe;
using ClasseDTO = SolarSystem.Earth.Common.Classe;

namespace SolarSystem.Earth.Mappers
{
    public class ClasseMapper : IMapper<ClasseDAO, ClasseDTO>
    {
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