using System.ComponentModel.DataAnnotations;

namespace NegosudAPI.Utils.DAO
{
    public class FournisseurDAO
    {

        public int Id { get; set; }
        public string Nom { get; set; }
        [MaxLength(10), MinLength(10)]
        public string? Telephone { get; set; }
        public string Email { get; set; }
        public string Domaine { get; set; }
        public DateTime Mod { get; set; } = DateTime.Now;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
