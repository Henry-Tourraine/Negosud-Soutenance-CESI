using NegosudAPI.Business;
using NegosudAPI.DataAccess.IRepository;
using NegosudAPI.Utils.DAO;
using NegosudAPI.Utils.DTO;

namespace NegosudAPI.Service
{
    public class AchatArticleService : IBusiness<AchatArticleDTO, int>
    {
        private readonly IRepository<AchatArticleDAO, AchatArticleDTO, int> _repo;
        public AchatArticleService(IRepository<AchatArticleDAO, AchatArticleDTO, int> repo)
        {
            _repo = repo;
        }
        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<AchatArticleDTO> Create(AchatArticleDTO entity)
        {
            var a = await _repo.Create(entity);
            entity.Id = a.Id;
            return entity;
        }


        public async Task<AchatArticleDTO> Find(int id)
        {
            var u = await _repo.Find(id);
            if (u != null)
            {
                AchatArticleDTO v = new AchatArticleDTO
                {
                    Id = u.Id,
                    Quantite = u.Quantite
                };
                
                if(u.achat != null)
                {
                    var w = new AchatDTO
                    {
                        Ref = u.achat.Ref,
                        EffectueLe = u.achat.EffectueLe,
                        Livre = u.achat.Livre
                    };
                    v.achat = w;

                }
                if (u.article != null)
                {
                    var w = new ArticleDTO
                    {
                        Ref = u.article.Ref,
                        Prix = u.article.Prix,
                        Quantite = u.Quantite,
                        Mod = u.article.Mod
                    };
                    v.article = w;

                }

                return v;
            }
            return null;
        }

        public async Task<List<AchatArticleDTO>> FindAll()
        {
            var z = await _repo.FindAll();
            var a = new List<AchatArticleDTO>();
            if(z != null)
            {
                foreach(var u in z)
                {
                    
                        AchatArticleDTO v = new AchatArticleDTO
                        {
                            Id = u.Id,
                            Quantite = u.Quantite
                        };

                        if (u.achat != null)
                        {
                            var w = new AchatDTO
                            {
                                Ref = u.achat.Ref,
                                EffectueLe = u.achat.EffectueLe,
                                Livre = u.achat.Livre
                            };
                            v.achat = w;

                        }
                        if (u.article != null)
                        {
                            var w = new ArticleDTO
                            {
                                Ref = u.article.Ref,
                                Prix = u.article.Prix,
                                Quantite = u.Quantite,
                                Mod = u.article.Mod
                            };
                            v.article = w;

                        }

                    a.Add(v);
                    }
                
            }
            return a;
        }

        public async Task Update(AchatArticleDTO element)
        {
            await _repo.Update(element);
        }
    }
}
