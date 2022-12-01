using NegosudAPI.DataAccess.Context;
using NegosudAPI.DataAccess.IRepository;
using NegosudAPI.Utils.DAO;
using NegosudAPI.Utils.DTO;
using Microsoft.EntityFrameworkCore;

namespace NegosudAPI.DataAccess.Repository
{
    public class FamilleRepo:IRepository<FamilleDAO, FamilleDTO, int>
    {
        private readonly ApplicationDbContext _db;

        public FamilleRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<FamilleDAO> Create(FamilleDTO entity)
        {
            var u = new FamilleDAO
            {
                Nom = entity.Nom
            };
            _db.Familles.Add(u);
            await _db.SaveChangesAsync();
            return u;
        }

        public async Task Delete(int id)
        {
            var u = await _db.Familles.Where(q => q.Id == id).FirstOrDefaultAsync();
            if (u != null)
            {
                _db.Familles.Remove(u);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<FamilleDAO> Find(int id)
        {
            var u = await _db.Familles.Where(q => q.Id == id).FirstOrDefaultAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public async Task<List<FamilleDAO>> FindAll()
        {
            var u = await _db.Familles.ToListAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public async Task Update(FamilleDTO entity)
        {
            var u = await _db.Familles.Where(q => q.Id == entity.Id).FirstOrDefaultAsync();
            if (u != null)
            {
                u.Nom = entity.Nom;
                _db.Entry(u).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
        }
    }
}
