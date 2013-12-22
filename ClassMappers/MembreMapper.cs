﻿using SolarSystem.Earth.Common.Interfaces;
using MembreDAO = SolarSystem.Earth.DataAccess.Model.Membre;
using MembreDTO = SolarSystem.Earth.Common.Membre;

namespace SolarSystem.Earth.Mappers
{
    public class MembreMapper : IMapper<MembreDAO, MembreDTO>
    {
        public MembreDTO ToDTO(MembreDAO element)
        {
            return new MembreDTO
            {
                Code_Membre = element.Code_Membre,
                Nom = element.Nom,
                Prenom = element.Prenom,
                Pseudo = element.Pseudo,
                Email_perso = element.Email_perso,
                Email_EPSI = element.Email_EPSI,
                Telephone_mobile = element.Telephone_mobile,
                Ville_origine = element.Ville_origine,
                Site_web = element.Site_web,
                URL_Facebook = element.URL_Facebook,
                URL_Twitter = element.URL_Twitter,
                URL_LinkedIn = element.URL_LinkedIn,
                URL_Viadeo = element.URL_Viadeo,
                Statut = element.Statut,
                Presentation = element.Presentation,
                Image = element.Image,
                URL = element.URL,
                Ville = new VilleMapper().ToDTO(element.Ville),
                Classe = new ClasseMapper().ToDTO(element.Classe),
                Role = new RoleMapper().ToDTO(element.Role),
            };
        }

        public MembreDAO ToDAO(MembreDTO element)
        {
            return new MembreDAO
            {
                Code_Membre = element.Code_Membre,
                Code_Classe = element.Classe.Code_Classe,
                Code_Role = element.Role.Code_Role,
                Code_Ville = element.Ville.Code_Ville,
                Email_EPSI = element.Email_EPSI,
                Email_perso = element.Email_perso,
                Image = element.Image,
                Mot_de_passe = element.Mot_de_passe,
                Nom = element.Nom,
                Prenom = element.Prenom,
                Presentation = element.Presentation,
                Pseudo = element.Pseudo,
                Site_web = element.Site_web,
                Statut = element.Statut,
                Telephone_mobile = element.Telephone_mobile,
                URL_Facebook = element.URL_Facebook,
                URL_Twitter = element.URL_Twitter,
                URL_LinkedIn = element.URL_LinkedIn,
                URL_Viadeo = element.URL_Viadeo,
                Ville_origine = element.Ville_origine,
                URL = element.URL
            };
        }
    }
}