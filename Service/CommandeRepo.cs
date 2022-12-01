using NegosudAPI.Business;
using NegosudAPI.DataAccess.IRepository;
using NegosudAPI.Utils.DAO;
using NegosudAPI.Utils.DTO;

namespace NegosudAPI.Service
{
    public class CommandeService : IBusiness<CommandeDTO, int>
    {
        private readonly IRepository<CommandeDAO, CommandeDTO, int> _repo;
        public CommandeService(IRepository<CommandeDAO, CommandeDTO, int> repo)
        {
            _repo = repo;
        }

        public async Task<CommandeDTO> Create(CommandeDTO entity)
        {
            var a = await _repo.Create(entity);
            entity.Ref = a.Ref;
            return entity;
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<CommandeDTO> Find(int id)
        {
            var u = await _repo.Find(id);
            if (u != null)
            {
                CommandeDTO v = new CommandeDTO
                {
                    Ref = u.Ref,
                    EmiseLe = u.EmiseLe,
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

                return v;
            }
            return null;
        }

        public async Task<List<CommandeDTO>> FindAll()
        {
            var z = await _repo.FindAll();
            var a = new List<CommandeDTO>();
            if (z != null)
            {
                foreach (var u in z)
                {
                    if (u != null)
                    {
                        CommandeDTO v = new CommandeDTO
                        {
                            Ref = u.Ref,
                            EmiseLe = u.EmiseLe,
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

        public async Task Update(CommandeDTO element)
        {
            await _repo.Update(element);
        }
    }
}
