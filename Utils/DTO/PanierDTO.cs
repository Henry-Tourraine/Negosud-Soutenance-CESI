namespace NegosudAPI.Utils.DTO
{
    public class PanierDTO
    {

        public int Id { get; set; }
        public string? UtilisateurEmail { get; set; }

        public UtilisateurDTO utilisateur { get; set; }
        public List<ArticleDTO> articles { get; set; }
    }
}
