using NegosudAPI.Business;
using NegosudAPI.DataAccess.IRepository;
using NegosudAPI.Utils.DAO;
using NegosudAPI.Utils.DTO;

namespace NegosudAPI.Service
{
   public class ArticleService : IBusiness<ArticleDTO, int>
    {
        private readonly IRepository<ArticleDAO, ArticleDTO, int> _repo;
        public ArticleService(IRepository<ArticleDAO, ArticleDTO, int> repo)
        {
            _repo = repo;
        }

        public async Task<ArticleDTO> Create(ArticleDTO entity)
        {
            var a = await _repo.Create(entity);
            entity.Ref = a.Ref;
            return entity;
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<ArticleDTO> Find(int id)
        {
            var u = await _repo.Find(id);
            if (u != null)
            {
                ArticleDTO v = new ArticleDTO
                {
                    Ref = u.Ref,
                    Prix = u.Prix,
                    Quantite=u.Quantite,
                    Mod = u.Mod
                };

                if (u.famille != null)
                {
                    var w = new FamilleDTO
                    {
                        Id = u.famille.Id,
                        Nom = u.famille.Nom
                    };
                    v.famille = w;

                }
                if (u.fournisseur != null)
                {
                    var w = new FournisseurDTO
                    {
                        Id=u.fournisseur.Id,
                        Nom=u.fournisseur.Nom,
                        Email=u.fournisseur.Email,
                        Telephone=u.fournisseur.Telephone,
                        Domaine=u.fournisseur.Domaine
                    };
                    v.fournisseur = w;

                }

                return v;
            }
            return null;
        }

        public async Task<List<ArticleDTO>> FindAll()
        {
            var z = await _repo.FindAll();
            var a = new List<ArticleDTO>();
            if (z != null)
            {
                foreach (var u in z)
                {
                    if (u != null)
                    {
                        ArticleDTO v = new ArticleDTO
                        {
                            Ref = u.Ref,
                            Prix = u.Prix,
                            Quantite = u.Quantite,
                            Mod = u.Mod
                        };

                        if (u.famille != null)
                        {
                            var w = new FamilleDTO
                            {
                                Id = u.famille.Id,
                                Nom = u.famille.Nom
                            };
                            v.famille = w;

                        }
                        if (u.fournisseur != null)
                        {
                            var w = new FournisseurDTO
                            {
                                Id = u.fournisseur.Id,
                                Nom = u.fournisseur.Nom,
                                Email = u.fournisseur.Email,
                                Telephone = u.fournisseur.Telephone,
                                Domaine = u.fournisseur.Domaine
                            };
                            v.fournisseur = w;

                        }

                        a.Add(v);
                    }
                }
            }
            return a;
        }

        public async Task Update(ArticleDTO element)
        {
            await _repo.Update(element);
        }
    }
}
