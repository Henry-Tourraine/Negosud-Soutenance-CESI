using NegosudAPI.Business;
using NegosudAPI.DataAccess.IRepository;
using NegosudAPI.Utils.DAO;
using NegosudAPI.Utils.DTO;
using static System.Net.Mime.MediaTypeNames;

namespace NegosudAPI.Service
{
    public class ApplicationService : IBusiness<ApplicationDTO, int>
    {
        private readonly IRepository<ApplicationDAO, ApplicationDTO, int> _repo;
        public ApplicationService(IRepository<ApplicationDAO, ApplicationDTO, int> repo)
        {
            _repo = repo;
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<ApplicationDTO> Create(ApplicationDTO entity)
        {
            var a = await _repo.Create(entity);
            entity.Id = a.Id;
            return entity;
        }

        public async Task<ApplicationDTO> Find(int id)
        {
            var u = await _repo.Find(id);
            if (u != null)
            {
                ApplicationDTO v = new ApplicationDTO
                {
                    Nom = u.Nom,
                   
                };
                return v;
            }
            return null;
        }

        public async Task<List<ApplicationDTO>> FindAll()
        {
            var z = await _repo.FindAll();
            var a = new List<ApplicationDTO>();
            if (z != null)
            {
                foreach (var u in z)
                {
                    ApplicationDTO v = new ApplicationDTO
                    {
                        Nom = u.Nom,

                    };
                    a.Add(v);
                }
            }

            return a;
        }

        public async Task Update(ApplicationDTO element)
        {
            await _repo.Update(element);
        }
    }
}
