using NegosudAPI.DataAccess.Context;
using NegosudAPI.DataAccess.IRepository;
using NegosudAPI.Utils.DAO;
using Microsoft.EntityFrameworkCore;
using NegosudAPI.Utils.DTO;

namespace NegosudAPI.DataAccess.Repository
{
    public class CommandeRepo:IRepository<CommandeDAO, CommandeDTO, int>
    {
        private readonly ApplicationDbContext _db;

        public CommandeRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<CommandeDAO> Create(CommandeDTO u)
        {
            CommandeDAO v = new CommandeDAO
            {

                EmiseLe = u.EmiseLe,
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

            if (u.fournisseur != null)
            {
                var w = await _db.Fournisseurs.Where(q => q.Id == u.fournisseur.Id).FirstOrDefaultAsync();
                if (w != null)
                {
                    v.fournisseur = w;
                }

            }


            _db.Commandes.Add(v);
            await _db.SaveChangesAsync();
            return v;
        }

        public async Task Delete(int id)
        {
            var u = await _db.Commandes.Where(q => q.Ref == id).FirstOrDefaultAsync();
            if (u != null)
            {
                _db.Commandes.Remove(u);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<CommandeDAO> Find(int id)
        {
            var u = await _db.Commandes.Where(q => q.Ref == id).Include(q => q.utilisateur).Include(q => q.fournisseur).FirstOrDefaultAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public async Task<List<CommandeDAO>> FindAll()
        {
            var u = await _db.Commandes.Include(q=>q.utilisateur).Include(q=>q.fournisseur).ToListAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public async Task Update(CommandeDTO entity)
        {
            CommandeDAO u = await _db.Commandes.Where(q => q.Ref == entity.Ref).FirstOrDefaultAsync();
            if(u != null) {
                if (u.utilisateur != null)
                {
                    var w = await _db.Utilisateurs.Where(q => q.Email == u.utilisateur.Email).FirstOrDefaultAsync();
                    if (w != null)
                    {
                        u.utilisateur = w;
                    }

                }

                if (u.fournisseur != null)
                {
                    var w = await _db.Fournisseurs.Where(q => q.Id == u.fournisseur.Id).FirstOrDefaultAsync();
                    if (w != null)
                    {
                        u.fournisseur = w;
                    }

                }


                _db.Entry(u).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            
            }
        }
    }
}
