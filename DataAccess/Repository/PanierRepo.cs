using NegosudAPI.DataAccess.Context;
using NegosudAPI.DataAccess.IRepository;
using NegosudAPI.Utils.DAO;
using NegosudAPI.Utils.DTO;
using Microsoft.EntityFrameworkCore;

namespace NegosudAPI.DataAccess.Repository
{
    public class PanierRepo:IRepository<PanierDAO, PanierDTO, int>
    {
        private readonly ApplicationDbContext _db;

        public PanierRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<PanierDAO> Create(PanierDTO entity)
        {
            var u = new PanierDAO();
            if(entity.utilisateur != null)
            {
                var w = await _db.Utilisateurs.Where(q => q.Email == entity.utilisateur.Email).FirstOrDefaultAsync();
                if(w != null)
                {
                    u.utilisateur = w;
                }
            }
            if (entity.articles != null)
            {
                var t = new List<ArticleDAO>();
                entity.articles.ForEach(async (x) =>
                {
                    var w = await _db.Articles.Where(q => q.Ref == x.Ref).FirstOrDefaultAsync();
                    if (w != null)
                    {
                        t.Add(w);
                    }
                });
                u.articles = t;
                
            }
            _db.Paniers.Add(u);
            await _db.SaveChangesAsync();
            return u;
        }

        public async Task Delete(int id)
        {
            var u = await _db.Paniers.Where(q => q.Id == id).FirstOrDefaultAsync();
            if (u != null)
            {
                _db.Paniers.Remove(u);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<PanierDAO> Find(int id)
        {
            var u = await _db.Paniers.Where(q => q.Id == id).Include(q => q.utilisateur).Include(q => q.articles).FirstOrDefaultAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public async Task<List<PanierDAO>> FindAll()
        {
            var u = await _db.Paniers.Include(q=>q.utilisateur).Include(q => q.articles).ToListAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public async Task Update(PanierDTO entity)
        {

            if (entity != null)
            {
                var a = await _db.Paniers.Where(q => q.Id == entity.Id).FirstOrDefaultAsync();
                if(a != null) { 
                if (entity.utilisateur != null)
                {
                    var w = await _db.Utilisateurs.Where(q => q.Email == entity.utilisateur.Email).FirstOrDefaultAsync();
                    if (w != null)
                    {
                        a.utilisateur = w;
                    }
                }
                if (entity.articles != null)
                {
                    var t = new List<ArticleDAO>();
                    entity.articles.ForEach(async (x) =>
                    {
                        var w = await _db.Articles.Where(q => q.Ref == x.Ref).FirstOrDefaultAsync();
                        if (w != null)
                        {
                            t.Add(w);
                        }
                    });
                    a.articles = t;

                }
                    _db.Entry(a).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
            }
            }
        }
    }
}
