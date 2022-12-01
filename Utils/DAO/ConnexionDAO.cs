
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations.Schema;

namespace NegosudAPI.Utils.DAO
{
    public class ConnexionDAO
    {
        public int Id { get; set; }
        public DateTime Debut { get; set; } = DateTime.Now;
        public DateTime? Fin { get; set; }

        [ForeignKey("Utilisateur")]
        public string UtilisateurEmail { get; set; }
        public virtual UtilisateurDAO utilisateur { get; set; }

        [ForeignKey("Application")]
        public int ApplicationId { get; set; }

        public virtual ApplicationDAO application { get; set; }

    }
}
