using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NegosudAPI.Utils.DAO
{
    public class AchatArticleDAO
    {
        [Key]
        public int Id { get; set; }
        public int Quantite { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("Achat")]
        public int AchatRef { get; set; }
        public AchatDAO achat { get; set; }

        [ForeignKey("Article")]
        public int ArticleRef { get; set; }
        public DateTime ArticleMod { get; set; }
        public ArticleDAO article { get; set; }

    }
}
