using NegosudAPI.Business;
using NegosudAPI.DataAccess.IRepository;
using NegosudAPI.Utils.DAO;
using NegosudAPI.Utils.DTO;

namespace NegosudAPI.Service
{
    public class AchatService : IBusiness<AchatDTO, int>
    {
        private readonly IRepository<AchatDAO, AchatDTO, int> _repo;
        public AchatService(IRepository<AchatDAO, AchatDTO, int>  repo)
        {
            _repo = repo;
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<AchatDTO> Create(AchatDTO entity)
        {
            var a = await _repo.Create(entity);
            entity.Ref = a.Ref;
            return entity;
        }


        public async Task<AchatDTO> Find(int id)
        {
            var u = await _repo.Find(id);
            if (u != null)
            {
                AchatDTO v = new AchatDTO
                {
                    Ref = u.Ref,
                    EffectueLe = u.EffectueLe,
                    Livre = u.Livre
                };

                if (u.utilisateur != null)
                {
                    var w = new UtilisateurDTO
                    {
                        Prenom = u.utilisateur.Prenom,
                        Nom = u.utilisateur.Nom,
                        Email = u.utilisateur.Email,
                        Password = u.utilisateur.Password,
                        Admin = u.utilisateur.Admin,
                        Mod= u.utilisateur.Mod
                    };
                    v.utilisateur = w;

                }

                return v;
            }
            return null;
        }

        public async Task<List<AchatDTO>> FindAll()
        {
            var z = await _repo.FindAll();
            var a = new List<AchatDTO>();
            if (z != null)
            {
                foreach (var u in z)
                {

                    if (u != null)
                    {
                        AchatDTO v = new AchatDTO
                        {
                            Ref = u.Ref,
                            EffectueLe = u.EffectueLe,
                            Livre = u.Livre
                        };

                        if (u.utilisateur != null)
                        {
                            var w = new UtilisateurDTO
                            {
                                Prenom = u.utilisateur.Prenom,
                                Nom = u.utilisateur.Nom,
                                Email = u.utilisateur.Email,
                                Password = u.utilisateur.Password,
                                Admin = u.utilisateur.Admin,
                                Mod = u.utilisateur.Mod
                            };
                            v.utilisateur = w;

                        }

                        a.Add(v);
                    }
                }

            }
            return a;
        }

        public async Task Update(AchatDTO element)
        {
            await _repo.Update(element);
        }
    }
}
