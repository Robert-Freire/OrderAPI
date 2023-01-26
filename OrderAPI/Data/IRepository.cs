namespace OrderAPI.Data
{
    public interface IRepository<T>
    {
        Task<T> Add(T order);
        Task<T?> Get(int id);
    }
}
