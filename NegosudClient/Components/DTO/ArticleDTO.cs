

using System;

namespace NegosudAPI.Utils.DTO
{
    public class ArticleDTO
    {
       
        public int Ref { get; set; }
        public float Prix { get; set; }
        public int? Quantite { get; set; }

        public DateTime? Mod { get; set; }

        public int? FamilleId { get; set; }
        public FamilleDTO? famille { get; set; }

    
        public int? FournisseurId { get; set; }
        public FournisseurDTO? fournisseur { get; set; }

    }
}
