using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace NegosudAPI.Utils.DTO
{
    public class AchatArticleDTO
    {
        
        public int Id { get; set; }
        public int Quantite { get; set; }
   
        public int? AchatRef { get; set; }
        public AchatDTO? achat { get; set; }

     
        public int? ArticleRef { get; set; }
        public ArticleDTO? article { get; set; }

    }
}
