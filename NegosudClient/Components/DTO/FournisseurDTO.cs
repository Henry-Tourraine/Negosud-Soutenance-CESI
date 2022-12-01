using System;

namespace NegosudAPI.Utils.DTO
{
    public class FournisseurDTO
    {

        public int Id { get; set; }
        public string Nom { get; set; }
       
        public string? Telephone { get; set; }
        public string Email { get; set; }
        public string Domaine { get; set; }
        public DateTime? Mod { get; set; }

    }
}
