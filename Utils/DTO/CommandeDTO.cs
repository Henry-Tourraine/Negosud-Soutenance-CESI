

namespace NegosudAPI.Utils.DTO
{
    public class CommandeDTO
    {
       
        public int Ref { get; set; }
        public DateTime EmiseLe { get; set; }
        public DateTime? Livre { get; set; }

        //ADMIN
      
        public string? UtilisateurEmail { get; set; }
        public UtilisateurDTO utilisateur { get; set; }

        public int? FournisseurId { get; set; }
        public FournisseurDTO fournisseur { get; set; }





    }
    public class CommandeMultiBusiness
    {

        public CommandeDTO commande;
        public List<CommandeArticleDTO> articlesList;


    }

}
