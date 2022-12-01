using NegosudAPI.Business;
using NegosudAPI.DataAccess.IRepository;
using NegosudAPI.Utils.DAO;
using NegosudAPI.Utils.DTO;

namespace NegosudAPI.Service
{
    public class PanierService : IBusiness<PanierDTO, int>
    {
        private readonly IRepository<PanierDAO, PanierDTO, int> _repo;
        public PanierService(IRepository<PanierDAO, PanierDTO, int> repo)
        {
            _repo = repo;
        }

        public async Task<PanierDTO> Create(PanierDTO entity)
        {
            var a = await _repo.Create(entity);
            entity.Id = a.Id;
            return entity;
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<PanierDTO> Find(int id)
        {
            var u = await _repo.Find(id);
            if (u != null)
            {
                PanierDTO v = new PanierDTO
                {
                    Id = u.Id
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
                if (u.articles != null)
                {
                    var t = new List<ArticleDTO>();
                    foreach(var x in u.articles)
                    {
                        var w = new ArticleDTO
                        {
                            Ref = x.Ref,
                            Prix = x.Prix,
                            Quantite = x.Quantite,
                            Mod = x.Mod
                        };

                        t.Add(w);
                    };
                    v.articles = t;

                }

                return v;
            }
            return null;
        }

        public async Task<List<PanierDTO>> FindAll()
        {
            var z = await _repo.FindAll();
            var a = new List<PanierDTO>();
            if (z != null)
            {
                foreach (var u in z)
                {
                    if (u != null)
                    {
                        PanierDTO v = new PanierDTO
                        {
                            Id = u.Id
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
                        if (u.articles != null)
                        {
                            var t = new List<ArticleDTO>();
                            foreach (var x in u.articles)
                            {
                                var w = new ArticleDTO
                                {
                                    Ref = x.Ref,
                                    Prix = x.Prix,
                                    Quantite = x.Quantite,
                                    Mod = x.Mod
                                };

                                t.Add(w);
                            };
                            v.articles = t;

                        }

                        a.Add(v);
                    }
                }
            }
            return a;
        }

        public async Task Update(PanierDTO element)
        {
            await _repo.Update(element);
        }
    }
}
