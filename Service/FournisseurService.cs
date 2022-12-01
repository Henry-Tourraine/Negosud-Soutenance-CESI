using NegosudAPI.Business;
using NegosudAPI.DataAccess.IRepository;
using NegosudAPI.Utils.DAO;
using NegosudAPI.Utils.DTO;

namespace NegosudAPI.Service
{
    public class FournisseurService : IBusiness<FournisseurDTO, int>
    {
        private readonly IRepository<FournisseurDAO, FournisseurDTO, int> _repo;
        public FournisseurService(IRepository<FournisseurDAO, FournisseurDTO, int> repo)
        {
            _repo = repo;
        }

        public async Task<FournisseurDTO> Create(FournisseurDTO entity)
        {
            var a = await _repo.Create(entity);
            entity.Id = a.Id;
            return entity;
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<FournisseurDTO> Find(int id)
        {
            var u = await _repo.Find(id);
            if (u != null)
            {
                FournisseurDTO v = new FournisseurDTO
                {
                    Id = u.Id,
                    Nom = u.Nom,
                    Email = u.Email,
                    Domaine = u.Domaine,
                    Telephone = u.Telephone,
                    Mod = u.Mod
                };

                return v;
            }

            return null;
        }

        public async Task<List<FournisseurDTO>> FindAll()
        {
            var z = await _repo.FindAll();
            var a = new List<FournisseurDTO>();
            if (z != null)
            {
                foreach (var u in z)
                {
                    if (u != null)
                    {
                        FournisseurDTO v = new FournisseurDTO
                        {
                            Id = u.Id,
                            Nom = u.Nom,
                            Email = u.Email,
                            Domaine = u.Domaine,
                            Telephone = u.Telephone,
                            Mod = u.Mod
                        };

                        a.Add(v);
                    }
                }
            }

            return a;
        }

        public async Task Update(FournisseurDTO element)
        {
            await _repo.Update(element);
        }
    }
}
