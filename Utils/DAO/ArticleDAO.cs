using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NegosudAPI.Utils.DAO
{
    public class ArticleDAO
    {
        [Key]
        public int Ref { get; set; }
        public float Prix { get; set; }
        public int Quantite { get; set; }

        public DateTime Mod { get; set; } = DateTime.Now;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("Famille")]
        public int FamilleId { get; set; }
        public DateTime FamilleMod { get; set; }
        public virtual FamilleDAO? famille { get; set; }

        [ForeignKey("Fournisseur")]
        public int FournisseurId { get; set; }
        public DateTime FournisseurMod { get; set; }
        public virtual FournisseurDAO? fournisseur { get; set; }

    }
}
