using NegosudAPI.Business;
using NegosudAPI.DataAccess.IRepository;
using NegosudAPI.Utils.DAO;
using NegosudAPI.Utils.DTO;

namespace NegosudAPI.Service
{
    public class UtilisateurService : IBusiness<UtilisateurDTO, string>
    {
        private readonly IRepository<UtilisateurDAO, UtilisateurDTO, string> _repo;
        public UtilisateurService(IRepository<UtilisateurDAO, UtilisateurDTO, string> repo)
        {
            _repo = repo;
        }

        public async Task<UtilisateurDTO> Create(UtilisateurDTO entity)
        {
            var a = await _repo.Create(entity);
            return entity;
        }

        public async Task Delete(string id)
        {
            await _repo.Delete(id);
        }

        public async Task<UtilisateurDTO> Find(string id)
        {
            var u = await _repo.Find(id);
            if (u != null)
            {
                UtilisateurDTO v = new UtilisateurDTO
                {
                    Prenom=u.Prenom,
                    Password=u.Password,
                    Admin=u.Admin,
                    Nom = u.Nom,
                    Email = u.Email,
                    Mod = u.Mod
                };

                return v;
            }

            return null;
        }

        public async Task<List<UtilisateurDTO>> FindAll()
        {
            var z = await _repo.FindAll();
            var a = new List<UtilisateurDTO>();
            if (z != null)
            {
                foreach (var u in z)
                {
                    if (u != null)
                    {
                        UtilisateurDTO v = new UtilisateurDTO
                        {
                            Prenom = u.Prenom,
                            Password = u.Password,
                            Admin = u.Admin,
                            Nom = u.Nom,
                            Email = u.Email,
                            Mod = u.Mod
                        };

                        a.Add(v);
                    }

                }
            }
            return a;
         }

        public async Task Update(UtilisateurDTO element)
        {
            await _repo.Update(element);
        }
    }
}
