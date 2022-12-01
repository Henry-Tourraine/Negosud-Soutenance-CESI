using NegosudAPI.DataAccess.Context;
using NegosudAPI.DataAccess.IRepository;
using NegosudAPI.Utils.DAO;
using Microsoft.EntityFrameworkCore;
using NegosudAPI.Utils.DTO;

namespace NegosudAPI.DataAccess.Repository
{
    public class AchatRepo : IRepository<AchatDAO, AchatDTO, int>
    {
        private readonly ApplicationDbContext _db;

        public AchatRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<AchatDAO> Create(AchatDTO u)
        {
            AchatDAO v = new AchatDAO
            {
                EffectueLe = u.EffectueLe,
                Livre = u.Livre
            };

            if (u.utilisateur != null)
            {
                var w = await _db.Utilisateurs.Where(q => q.Email == u.utilisateur.Email).FirstOrDefaultAsync();
                if (w != null)
                {
                    v.utilisateur = w;
                }

            }
           

            _db.Achats.Add(v);
            await _db.SaveChangesAsync();
            return v;
        }

        public async Task Delete(int id)
        {
            var u = await _db.Achats.Where(q => q.Ref == id).FirstOrDefaultAsync();
            if (u != null)
            {
                _db.Achats.Remove(u);
                await _db.SaveChangesAsync();
            }

        }

        public async Task<AchatDAO> Find(int id)
        {
            var u = await _db.Achats.Where(q => q.Ref == id).Include(q=>q.utilisateur).FirstOrDefaultAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public async Task<List<AchatDAO>> FindAll()
        {
            var u = await _db.Achats.Include(q => q.utilisateur).ToListAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public async Task Update(AchatDTO entity)
        {
            AchatDAO u = await _db.Achats.Where(q => q.Ref == entity.Ref).FirstOrDefaultAsync();
            if (u != null)
            {

                u.EffectueLe = entity.EffectueLe;
                u.Livre = entity.Livre;

                if (u.utilisateur != null)
                {
                    var w = await _db.Utilisateurs.Where(q => q.Email == u.utilisateur.Email).FirstOrDefaultAsync();
                    if (w != null)
                    {
                        u.utilisateur = w;
                    }

                }

                _db.Entry(u).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
        }
    }
}
