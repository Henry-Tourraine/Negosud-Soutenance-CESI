using Microsoft.EntityFrameworkCore;
using NegosudAPI.Utils.DAO;

namespace NegosudAPI.DataAccess.Context
{
    
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UtilisateurDAO> Utilisateurs { get; set; }
        public DbSet<FamilleDAO> Familles { get; set; }
        public DbSet<FournisseurDAO> Fournisseurs { get; set; }
        public DbSet<ApplicationDAO> Applications { get; set; }



        public DbSet<ArticleDAO> Articles { get; set; }
        public DbSet<CommandeDAO> Commandes { get; set; }
        public DbSet<AchatArticleDAO> AchatsArticles { get; set; }
        public DbSet<AchatDAO> Achats { get; set; }
        public DbSet<CommandeArticleDAO> CommandesArticles { get; set; }
        public DbSet<ConnexionDAO> Connexions { get; set; }
        public DbSet<PanierDAO> Paniers { get; set; }
        public DbSet<QuantiteDAO> Quantites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    }
}
