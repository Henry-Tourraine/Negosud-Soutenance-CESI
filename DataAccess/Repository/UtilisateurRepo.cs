using NegosudAPI.DataAccess.Context;
using NegosudAPI.DataAccess.IRepository;
using NegosudAPI.Utils.DAO;
using NegosudAPI.Utils.DTO;
using Microsoft.EntityFrameworkCore;

namespace NegosudAPI.DataAccess.Repository
{
    public class UtilisateurRepo:IRepository<UtilisateurDAO, UtilisateurDTO, string>
    {
        private readonly ApplicationDbContext _db;
        public UtilisateurRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<UtilisateurDAO> Create(UtilisateurDTO entity)
        {
            _db.Utilisateurs.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(string id)
        {
            var u = await _db.Utilisateurs.Where(q => q.Email == id).FirstOrDefaultAsync();
            if (u != null)
            {
                _db.Utilisateurs.Remove(u);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<UtilisateurDAO> Find(string id)
        {
            var u = await _db.Utilisateurs.Where(q => q.Email == id).FirstOrDefaultAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public async Task<List<UtilisateurDAO>> FindAll()
        {
            var u = await _db.Utilisateurs.ToListAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public async Task Update(UtilisateurDTO entity)
        {
            UtilisateurDAO u = await _db.Utilisateurs.Where(q => q.Email == entity.Email).FirstOrDefaultAsync();
            if (u != null)
            {

                u.Prenom = entity.Prenom;
                    u.Password = entity.Password;
                    u.Admin = entity.Admin;
                    u.Nom = entity.Nom;
                    u.Email = entity.Email;
                u.Mod = DateTime.Now;
               
                _db.Entry(u).State = EntityState.Modified;
                await _db.SaveChangesAsync();


            }
            }
        }
    }
}
