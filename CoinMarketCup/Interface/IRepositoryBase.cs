using System.Threading.Tasks;

namespace CoinMarketCup.Interface
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> GetById(string id);
        Task Add(T entity);
        Task Remove(T entity);
        Task Edit(T entity);
    }
}
