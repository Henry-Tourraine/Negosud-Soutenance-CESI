using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NegosudAPI.Utils.DAO
{
    public class CommandeArticleDAO
    {
        [Key]
        public int Id { get; set; }

        public int Quantite { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("Commande")]
        public int? CommandeRef { get; set; }
        public CommandeDAO commande { get; set; }

        [ForeignKey("Article")]
        public int ArticleRef { get; set; }
        public DateTime ArticleMod { get; set; }
        public virtual ArticleDAO article { get; set; }
    }
}
