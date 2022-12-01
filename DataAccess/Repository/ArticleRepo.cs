using NegosudAPI.DataAccess.Context;
using NegosudAPI.DataAccess.IRepository;
using NegosudAPI.Utils.DAO;
using NegosudAPI.Utils.DTO;
using Microsoft.EntityFrameworkCore;

namespace NegosudAPI.DataAccess.Repository
{
    public class ArticleRepo : IRepository<ArticleDAO, ArticleDTO, int>
    {
        private readonly ApplicationDbContext _db;

        public ArticleRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<ArticleDAO> Create(ArticleDTO u)
        {
            ArticleDAO v = new ArticleDAO
            {
             
                Prix = u.Prix,
                 Quantite = (int)u.Quantite
            };

            if (u.famille != null)
            {
                var w = await _db.Familles.Where(q => q.Id == u.famille.Id).FirstOrDefaultAsync();
                if (w != null)
                {
                    v.famille = w;
                }

            }

            if (u.fournisseur != null)
            {
                var w = await _db.Fournisseurs.Where(q => q.Id == u.fournisseur.Id).FirstOrDefaultAsync();
                if (w != null)
                {
                    v.fournisseur = w;
                }

            }


            _db.Articles.Add(v);
            await _db.SaveChangesAsync();
            return v;
        }

        public async Task Delete(int id)
        {
            var u = await _db.Articles.Where(q => q.Ref == id).FirstOrDefaultAsync();
            if (u != null)
            {
                _db.Articles.Remove(u);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<ArticleDAO> Find(int id)
        {
            var u = await _db.Articles.Where(q => q.Ref == id).Include(q => q.famille).Include(q => q.fournisseur).FirstOrDefaultAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public async Task<List<ArticleDAO>> FindAll()
        {
            var u = await _db.Articles.Include(q=>q.famille).Include(q=>q.fournisseur).ToListAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public async Task Update(ArticleDTO entity)
        {
            ArticleDAO u = await _db.Articles.Where(q => q.Ref == entity.Ref).FirstOrDefaultAsync();
            if (u != null)
            {

                u.Ref = entity.Ref;
                u.Prix = entity.Prix;

                if(entity.Quantite != null)
                {
                    u.Quantite = (int)entity.Quantite;
                }

                if (u.fournisseur != null)
                {
                    var w = await _db.Fournisseurs.Where(q => q.Id == u.fournisseur.Id).FirstOrDefaultAsync();
                    if (w != null)
                    {
                        u.fournisseur = w;
                    }

                }

                if (u.famille != null)
                {
                    var w = await _db.Familles.Where(q => q.Id == u.famille.Id).FirstOrDefaultAsync();
                    if (w != null)
                    {
                        u.famille = w;
                    }

                }

                _db.Entry(u).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
        }
    }
}
