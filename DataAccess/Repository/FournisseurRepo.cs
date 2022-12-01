using NegosudAPI.DataAccess.Context;
using NegosudAPI.DataAccess.IRepository;
using NegosudAPI.Utils.DAO;
using NegosudAPI.Utils.DTO;
using Microsoft.EntityFrameworkCore;

namespace NegosudAPI.DataAccess.Repository
{
    public class FournisseurRepo:IRepository<FournisseurDAO, FournisseurDTO, int>
    {
        private readonly ApplicationDbContext _db;

        public FournisseurRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<FournisseurDAO> Create(FournisseurDTO entity)
        {
            var u = new FournisseurDAO
            {
                Id = entity.Id,
                Nom = entity.Nom,
                Email = entity.Email,
                Telephone = entity.Telephone,
                Domaine = entity.Domaine
            };
            _db.Fournisseurs.Add(u);
            await _db.SaveChangesAsync();
            return u;
        }

        public async Task Delete(int id)
        {
            var u = await _db.Fournisseurs.Where(q => q.Id == id).FirstOrDefaultAsync();
            if (u != null)
            {
                _db.Fournisseurs.Remove(u);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<FournisseurDAO> Find(int id)
        {
            var u = await _db.Fournisseurs.Where(q => q.Id == id).FirstOrDefaultAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public async Task<List<FournisseurDAO>> FindAll()
        {
            var u = await _db.Fournisseurs.ToListAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public async Task Update(FournisseurDTO entity)
        {
            var u = await _db.Fournisseurs.Where(q => q.Id == entity.Id).FirstOrDefaultAsync();
            if (u != null)
            {
                u.Id = entity.Id;
                u.Email = entity.Email;
                u.Nom = entity.Nom;
                u.Mod = (DateTime)entity.Mod;
                u.Telephone = entity.Telephone;




                _db.Entry(u).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
        }
    }
}
