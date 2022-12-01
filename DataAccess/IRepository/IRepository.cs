namespace NegosudAPI.DataAccess.IRepository
{
    public interface IRepository<DAO, DTO, TYPE_ID>
    {
        Task<DAO> Find(TYPE_ID id);
        Task<List<DAO>> FindAll();
        Task<DAO> Create(DTO entity);
        Task Update(DTO entity);
        Task Delete(TYPE_ID id);
    }
}
