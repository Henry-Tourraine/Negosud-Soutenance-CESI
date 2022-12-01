using System.ComponentModel.DataAnnotations;

namespace NegosudAPI.Utils.DAO
{
    public class UtilisateurDAO
    {
        public string Prenom { get; set; }
        public string Nom { get; set; }
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
        public DateTime Mod { get; set; }= DateTime.Now;
        public DateTime CreatedAt { get; set; }=DateTime.Now;
    }
}
