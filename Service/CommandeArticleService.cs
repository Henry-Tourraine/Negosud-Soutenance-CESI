using NegosudAPI.Business;
using NegosudAPI.DataAccess.IRepository;
using NegosudAPI.Utils.DAO;
using NegosudAPI.Utils.DTO;

namespace NegosudAPI.Service
{
    public class CommandeArticleService : IBusiness<CommandeArticleDTO, int>
    {
        private readonly IRepository<CommandeArticleDAO, CommandeArticleDTO, int> _repo;
        public CommandeArticleService(IRepository<CommandeArticleDAO, CommandeArticleDTO, int> repo)
        {
            _repo = repo;
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<CommandeArticleDTO> Create(CommandeArticleDTO entity)
        {
            var a = await _repo.Create(entity);
            entity.Id = a.Id;
            return entity;
        }

        public async Task<CommandeArticleDTO> Find(int id)
        {
            var u = await _repo.Find(id);
            if (u != null)
            {
                CommandeArticleDTO v = new CommandeArticleDTO
                {
                    Id = u.Id,
                    Quantite = u.Quantite
                };

                if (u.commande != null)
                {
                    var w = new CommandeDTO
                    {
                        Ref = u.commande.Ref,
                        EmiseLe = u.commande.EmiseLe,
                        Livre = u.commande.Livre
                    };
                    v.commande = w;

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


        public async Task<List<CommandeArticleDTO>> FindAll()
        {
            var z = await _repo.FindAll();
            var a = new List<CommandeArticleDTO>();
            if (z != null)
            {
                foreach (var u in z)
                {
                    if (u != null)
                    {
                        CommandeArticleDTO v = new CommandeArticleDTO
                        {
                            Id = u.Id,
                            Quantite = u.Quantite
                        };

                        if (u.commande != null)
                        {
                            var w = new CommandeDTO
                            {
                                Ref = u.commande.Ref,
                                EmiseLe = u.commande.EmiseLe,
                                Livre = u.commande.Livre
                            };
                            v.commande = w;

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
            }

            return a;
        }

        public async Task Update(CommandeArticleDTO element)
        {
            await _repo.Update(element);
        }
    }
}
