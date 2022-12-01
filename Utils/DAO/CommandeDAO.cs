
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NegosudAPI.Utils.DAO
{
    public class CommandeDAO
    {
        [Key]
        public int Ref { get; set; }
        public DateTime EmiseLe { get; set; } = DateTime.Now;
        public DateTime? Livre { get; set; }

        //ADMIN
        [ForeignKey("Utilisateur")]
        public string UtilisateurEmail { get; set; }
        public virtual UtilisateurDAO utilisateur { get; set; }

        [ForeignKey("Fournisseur")]
        public int FournisseurId { get; set; }
        public virtual FournisseurDAO fournisseur { get; set; }



    }
}
