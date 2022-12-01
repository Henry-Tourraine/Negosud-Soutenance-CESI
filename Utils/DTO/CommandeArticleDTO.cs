
namespace NegosudAPI.Utils.DTO
{
    public class CommandeArticleDTO
    {
      
        public int Id { get; set; }
        public int Quantite { get; set; }
    
        public int? CommandeRef { get; set; }
        public CommandeDTO commande { get; set; }

        public int? ArticleRef { get; set; }
        public ArticleDTO article { get; set; }
    }
}
