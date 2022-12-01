using System;

namespace NegosudAPI.Utils.DTO
{
    public class UtilisateurDTO
    {
            public string Prenom { get; set; }
            public string Nom { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public bool Admin { get; set; }
            public DateTime? Mod { get; set; }
    }
}
