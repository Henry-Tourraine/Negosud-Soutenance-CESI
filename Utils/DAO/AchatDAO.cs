
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NegosudAPI.Utils.DAO
{
    public class AchatDAO
    {
        [Key]
        public int Ref { get; set; }
        public DateTime EffectueLe { get; set; } = DateTime.Now;
        public DateTime? Livre { get; set; }

        //ADMIN
        [ForeignKey("Utilisateur")]
        public string UtilisateurEmail { get; set; }
        public virtual UtilisateurDAO utilisateur { get; set; }


    }
}
