using NegosudAPI.DataAccess.Context;
using NegosudAPI.DataAccess.IRepository;
using NegosudAPI.Utils.DAO;
using NegosudAPI.Utils.DTO;
using Microsoft.EntityFrameworkCore;

namespace NegosudAPI.DataAccess.Repository
{
    public class ConnexionRepo:IRepository<ConnexionDAO, ConnexionDTO, int>
    {
        private readonly ApplicationDbContext _db;

        public ConnexionRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ConnexionDAO> Create(ConnexionDTO u)
        {
            ConnexionDAO v = new ConnexionDAO
            {

                Debut = u.Debut,
                Fin= u.Fin
            };

            if (u.utilisateur != null)
            {
                var w = await _db.Utilisateurs.Where(q => q.Email == u.utilisateur.Email).FirstOrDefaultAsync();
                if (w != null)
                {
                    v.utilisateur = w;
                }

            }

            if (u.application != null)
            {
                var w = await _db.Applications.Where(q => q.Id == u.application.Id).FirstOrDefaultAsync();
                if (w != null)
                {
                    v.application = w;
                }

            }


            _db.Connexions.Add(v);
            await _db.SaveChangesAsync();
            return v;
        }

        public async Task Delete(int id)
        {
            var u = await _db.Connexions.Where(q => q.Id == id).FirstOrDefaultAsync();
            if (u != null)
            {
                _db.Connexions.Remove(u);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<ConnexionDAO> Find(int id)
        {
            var u = await _db.Connexions.Where(q => q.Id == id).Include(q => q.utilisateur).Include(q => q.application).FirstOrDefaultAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public async Task<List<ConnexionDAO>> FindAll()
        {
            var u = await _db.Connexions.Include(q=>q.utilisateur).Include(q=>q.application).ToListAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public async Task Update(ConnexionDTO entity)
        {
            ConnexionDAO u = await _db.Connexions.Where(q => q.Id == entity.Id).FirstOrDefaultAsync();
            if(u != null) {
                u.Debut = entity.Debut;
                u.Fin = entity.Fin;
                if (u.utilisateur != null)
                {
                    var w = await _db.Utilisateurs.Where(q => q.Email == u.utilisateur.Email).FirstOrDefaultAsync();
                    if (w != null)
                    {
                        u.utilisateur = w;
                    }

                }

                if (u.application != null)
                {
                    var w = await _db.Applications.Where(q => q.Id == u.application.Id).FirstOrDefaultAsync();
                    if (w != null)
                    {
                        u.application = w;
                    }

                }


                _db.Entry(u).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
        }
    }
}
