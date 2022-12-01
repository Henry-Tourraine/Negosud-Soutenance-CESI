using NegosudAPI.DataAccess.Context;
using NegosudAPI.DataAccess.IRepository;
using NegosudAPI.Utils.DAO;
using Microsoft.EntityFrameworkCore;
using NegosudAPI.Utils.DTO;

namespace NegosudAPI.DataAccess.Repository
{
    public class AchatArticleRepo : IRepository<AchatArticleDAO, AchatArticleDTO, int>
    {
        private readonly ApplicationDbContext _db;
        public AchatArticleRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<AchatArticleDAO> Create(AchatArticleDTO u)
        {
            
            AchatArticleDAO v = new AchatArticleDAO
            {
             
                Quantite = u.Quantite
            };

            if (u.achat != null)
            {
                var w = await _db.Achats.Where(q => q.Ref == u.achat.Ref).FirstOrDefaultAsync();
                if(w!= null)
                {
                    v.achat = w;
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
            
            _db.AchatsArticles.Add(u);
            await _db.SaveChangesAsync();
            return v;
        }

        public async Task Delete(int id)
        {
            var u = await _db.AchatsArticles.Where(q => q.Id == id).FirstOrDefaultAsync();
            if (u != null)
            {
                _db.AchatsArticles.Remove(u);
                await _db.SaveChangesAsync();
            }
           
           
        }

        public async  Task<AchatArticleDAO> Find(int id)
        {
            var u = await _db.AchatsArticles.Where(q => q.Id == id).Include(u => u.article).Include(u => u.achat).FirstOrDefaultAsync();
            if(u != null)
            {
                return u;
            }
            return null;
        }

        public async Task<List<AchatArticleDAO>> FindAll()
        {
            var u = await _db.AchatsArticles.Include(u => u.article).Include(u => u.achat).ToListAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public async Task Update(AchatArticleDTO entity)
        {
            AchatArticleDAO u = await _db.AchatsArticles.Where(q => q.Id == entity.Id).FirstOrDefaultAsync();
            if (u != null)
            {

                u.Quantite = entity.Quantite;

                if (entity.achat != null)
                {
                    var w = await _db.Achats.Where(q => q.Ref == entity.achat.Ref).FirstOrDefaultAsync();
                    if (w != null)
                    {
                        u.achat = w;
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
