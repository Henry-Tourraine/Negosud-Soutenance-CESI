using NegosudAPI.DataAccess.Context;
using NegosudAPI.DataAccess.IRepository;
using NegosudAPI.Utils.DAO;
using NegosudAPI.Utils.DTO;
using Microsoft.EntityFrameworkCore;

namespace NegosudAPI.DataAccess.Repository
{
    public class CommandeArticleRepo:IRepository<CommandeArticleDAO, CommandeArticleDTO, int>
    {
        private readonly ApplicationDbContext _db;

        public CommandeArticleRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<CommandeArticleDAO> Create(CommandeArticleDTO u)
        {
            CommandeArticleDAO v = new CommandeArticleDAO
            {
           
                Quantite=u.Quantite
            };

            if (u.commande != null)
            {
                var w = await _db.Commandes.Where(q => q.Ref == u.commande.Ref).FirstOrDefaultAsync();
                if (w != null)
                {
                    v.commande = w;
                }

            }

            if (u.article != null)
            {
                var w = await _db.Articles.Where(q => q.Ref == u.article.Ref).FirstOrDefaultAsync();
                if (w != null)
                {
                    v.article = w;
                }

            }


            _db.CommandesArticles.Add(v);
            await _db.SaveChangesAsync();
            return v;
        }

        public async Task Delete(int id)
        {
            var u = await _db.CommandesArticles.Where(q => q.Id == id).FirstOrDefaultAsync();
            if (u != null)
            {
                _db.CommandesArticles.Remove(u);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<CommandeArticleDAO> Find(int id)
        {
            var u = await _db.CommandesArticles.Where(q => q.Id== id).Include(q => q.article).Include(q => q.commande).FirstOrDefaultAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public async Task<List<CommandeArticleDAO>> FindAll()
        {
            var u = await _db.CommandesArticles.Include(q => q.article).Include(q=>q.commande).ToListAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public async Task Update(CommandeArticleDAO entity)
        {
            CommandeArticleDAO u = await _db.CommandesArticles.Where(q => q.Id == entity.Id).FirstOrDefaultAsync();
            if (u != null)
            {

                u.Quantite = entity.Quantite;

                if (entity.commande != null)
                {
                    var w = await _db.Commandes.Where(q => q.Ref == entity.commande.Ref).FirstOrDefaultAsync();
                    if (w != null)
                    {
                        u.commande = w;
                    }

                }
                if (entity.article != null)
                {
                    var w = await _db.Articles.Where(q => q.Ref == entity.article.Ref).FirstOrDefaultAsync();
                    if (w != null)
                    {
                        u.article = w;
                    }


                }

                _db.Entry(u).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
        }
    }
}
