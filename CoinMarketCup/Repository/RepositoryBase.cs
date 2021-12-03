﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinMarketCup.Interface;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace CoinMarketCup.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> 
        where T : class
    {
        protected ApplicationDbContext Context;

        public RepositoryBase(ApplicationDbContext context)
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
            Context.Set<T>().Update(entity).State  = EntityState.Modified; ;
            await Context.SaveChangesAsync();
        }

        public async ValueTask<T> GetById(string id)
        {
            var result= await Context.Set<T>().FindAsync(id);
            return result;
        }

        public async Task Remove(T entity)
        {
             Context.Set<T>().Remove(entity);
             await Context.SaveChangesAsync();
        }
    }
}