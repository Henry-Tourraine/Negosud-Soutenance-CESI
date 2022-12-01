
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace NegosudAPI.Utils.DTO
{
    public class AchatDTO
    {
   
        public int Ref { get; set; }
        public DateTime EffectueLe { get; set; } = DateTime.Now;
        public DateTime? Livre { get; set; }

      
        public string? UtilisateurEmail { get; set; }
        public UtilisateurDTO utilisateur { get; set; }


    }

    public class AchatMultiBusiness
    {

        public AchatDTO achat;
        public List<AchatArticleDTO> articlesList;


    }
}
