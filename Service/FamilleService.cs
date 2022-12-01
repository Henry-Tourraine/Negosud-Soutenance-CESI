using NegosudAPI.Business;
using NegosudAPI.DataAccess.IRepository;
using NegosudAPI.Utils.DAO;
using NegosudAPI.Utils.DTO;

namespace NegosudAPI.Service
{
    public class FamilleService : IBusiness<FamilleDTO, int>
    {
        private readonly IRepository<FamilleDAO, FamilleDTO, int> _repo;
        public FamilleService(IRepository<FamilleDAO, FamilleDTO, int> repo)
        {
            _repo = repo;
        }

        public async Task<FamilleDTO> Create(FamilleDTO entity)
        {
            var a = await _repo.Create(entity);
            entity.Id = a.Id;
            return entity;
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<FamilleDTO> Find(int id)
        {
            var u = await _repo.Find(id);
            if (u != null)
            {
                FamilleDTO v = new FamilleDTO
                {
                    Id = u.Id,
                    Nom = u.Nom
                };

                return v;
            }

            return null;
        }

        public async Task<List<FamilleDTO>> FindAll()
        {
            var z = await _repo.FindAll();
            var a = new List<FamilleDTO>();
            if (z != null)
            {
                foreach (var u in z)
                {
                    if (u != null)
                    {
                        FamilleDTO v = new FamilleDTO
                        {
                            Id = u.Id,
                            Nom = u.Nom
                        };

                        a.Add(v);
                    }
                }
            }
            return a;
        }

        public async Task Update(FamilleDTO element)
        {
            await _repo.Update(element);
        }
    }
}
