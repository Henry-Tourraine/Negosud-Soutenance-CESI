
using System.ComponentModel.DataAnnotations.Schema;

namespace NegosudAPI.Utils.DAO
{
    public class PanierDAO
    {

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("utilisateurEmail")]
        public string UtilisateurEmail { get; set; }


        public virtual UtilisateurDAO utilisateur { get; set; }
        public virtual ICollection<ArticleDAO> articles { get; set; }
    }
}
