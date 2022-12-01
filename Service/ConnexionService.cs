using NegosudAPI.Business;
using NegosudAPI.DataAccess.IRepository;
using NegosudAPI.Utils.DAO;
using NegosudAPI.Utils.DTO;

namespace NegosudAPI.Service
{
    public class ConnexionService : IBusiness<ConnexionDTO, int>
    {
        private readonly IRepository<ConnexionDAO, ConnexionDTO, int> _repo;
        public ConnexionService(IRepository<ConnexionDAO, ConnexionDTO, int> repo)
        {
            _repo = repo;
        }

        public async Task<ConnexionDTO> Create(ConnexionDTO entity)
        {
            var a = await _repo.Create(entity);
            entity.Id = a.Id;
            return entity;
        }


        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<ConnexionDTO> Find(int id)
        {
            var u = await _repo.Find(id);
            if (u != null)
            {
                ConnexionDTO v = new ConnexionDTO
                {
                    Id = u.Id,
                    Debut = u.Debut,
                    Fin = u.Fin
                };

                return v;
            }

            return null;
        }


        public async Task<List<ConnexionDTO>> FindAll()
        {
            var z = await _repo.FindAll();
            var a = new List<ConnexionDTO>();
            if (z != null)
            {
                foreach (var u in z)
                {
                    if (u != null)
                    {
                        ConnexionDTO v = new ConnexionDTO
                        {
                            Id = u.Id,
                            Debut = u.Debut,
                            Fin = u.Fin
                        };

                        a.Add(v);
                    }
                }

            }

            return a;
        }

        public async Task Update(ConnexionDTO element)
        {
            await _repo.Update(element);
        }
    }
}
