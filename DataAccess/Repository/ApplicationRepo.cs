using NegosudAPI.DataAccess.Context;
using NegosudAPI.DataAccess.IRepository;
using NegosudAPI.Utils.DAO;
using NegosudAPI.Utils.DTO;
using Microsoft.EntityFrameworkCore;

namespace NegosudAPI.DataAccess.Repository
{
    public class ApplicationRepo : IRepository<ApplicationDAO, ApplicationDTO, int>
    {
        private readonly ApplicationDbContext _db;

        public ApplicationRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ApplicationDAO> Create(ApplicationDTO entity)
        {
            var u = new ApplicationDAO
            {
                Nom = entity.Nom
            };
            _db.Applications.Add(u);
            await _db.SaveChangesAsync();
            return u;
        }

        public async Task Delete(int id)
        {
            var u = await _db.Applications.Where(q => q.Id == id).FirstOrDefaultAsync();
            if (u != null)
            {
                _db.Applications.Remove(u);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<ApplicationDAO> Find(int id)
        {
            var u = await _db.Applications.Where(q => q.Id == id).FirstOrDefaultAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public async Task<List<ApplicationDAO>> FindAll()
        {
            var u = await _db.Applications.ToListAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public async Task Update(ApplicationDTO entity)
        {
            if (entity != null)
            {
                var u = await _db.Applications.Where(q => q.Id == entity.Id).FirstOrDefaultAsync();
                if(u != null)
                {
                    entity.Nom = u.Nom;
                    _db.Update(u);
                    await _db.SaveChangesAsync();
                }
                
            }
        }
    }
}
