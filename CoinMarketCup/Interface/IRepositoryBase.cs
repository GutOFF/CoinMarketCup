using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinMarketCup.Interface
{
    public interface IRepositoryBase<T> where T : class
    {
        ValueTask<T> GetById(string id);
        Task Add(T entity);
        Task Remove(T entity);
        Task Edit(T entity);
    }
}
