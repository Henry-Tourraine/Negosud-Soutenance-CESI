
namespace NegosudAPI.Utils.DTO
{
    public class ConnexionDTO
    {
        public int Id { get; set; }
        public DateTime Debut { get; set; } = DateTime.Now;
        public DateTime? Fin { get; set; }

       
        public string? UtilisateurEmail { get; set; }
        public UtilisateurDTO utilisateur { get; set; }

        public int? ApplicationId { get; set; }

        public ApplicationDTO application { get; set; }

    }
}
