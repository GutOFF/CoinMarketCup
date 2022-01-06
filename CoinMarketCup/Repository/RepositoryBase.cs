using CoinMarketCup.Interface;
using Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoinMarketCup.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> 
        where T : class
    {
        protected ApplicationDbContext Context;

        protected RepositoryBase(ApplicationDbContext context)
        {
            Context = context;
        }


        public async Task Add(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Edit(T entity)
        {
            Context.Set<T>().Update(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public async Task EditRange(IEnumerable<T> entity)
        {
            Context.Set<T>().UpdateRange(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<T> GetById(string id)
        {
            var result= await Context.Set<T>().FindAsync(id);
            return result;
        }

        public async Task Remove(T entity)
        {
             Context.Set<T>().Remove(entity);
             await Context.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<T> entity)
        {
            await Context.Set<T>().AddRangeAsync(entity);
            await Context.SaveChangesAsync();
        }
    }
}
