namespace NegosudAPI.Business
{
    public interface IBusiness<T, U>
    {
        Task<T> Create(T entity);
        Task<T> Find(U id);
        Task<List<T>> FindAll();
        Task Update(T element);
        Task Delete(U id);
    }
}
