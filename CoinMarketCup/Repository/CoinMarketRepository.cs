using CoinMarketCup.Extension;
using CoinMarketCup.Models;
using Entity;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinMarketCup.Repository
{
    public class CoinMarketRepository : RepositoryBase<Cryptocurrency>
    {
        public CoinMarketRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task DeleteAllDate()
        {
            var cryptocurrency = await Context.Cryptocurrencies.FirstOrDefaultAsync();

            if (cryptocurrency is null)
            {
                return;
            }

            await Context.Database.ExecuteSqlInterpolatedAsync($"TRUNCATE TABLE Cryptocurrencies");
            await Context.SaveChangesAsync();
        }
        public async Task<bool> IsExpiryDateExpired()
        {
            var cryptocurrency = await Context.Cryptocurrencies
                .FirstOrDefaultAsync();

            if (cryptocurrency == null) return true;
            var timeExpire = cryptocurrency
                .DateAdded
                .AddMinutes(5);

            return timeExpire <= DateTime.UtcNow;
        }

        public Task<List<Cryptocurrency>> GetCryptocurrency(PaginatorInfoModel paginatorInfoModel, SortState sortState)
        {
            switch (sortState)
            {
                case SortState.DateAsk:
                    return Context
                        .Cryptocurrencies
                        .OrderBy(w => w.LastUpdated)
                        .Page(paginatorInfoModel.PageSize, paginatorInfoModel.CurrentPage-1)
                        .ToListAsync();
                case SortState.DateDesk:
                    return Context
                        .Cryptocurrencies
                        .OrderByDescending(w=> w.LastUpdated)
                        .Page(paginatorInfoModel.PageSize, paginatorInfoModel.CurrentPage-1)
                        .ToListAsync();
                case SortState.NameAsc:
                    return Context
                        .Cryptocurrencies
                        .OrderBy(w=> w.Name)
                        .Page(paginatorInfoModel.PageSize, paginatorInfoModel.CurrentPage-1)
                        .ToListAsync();
                case SortState.NameDesc:
                    return Context
                        .Cryptocurrencies
                        .OrderByDescending(w=> w.Name)
                        .Page(paginatorInfoModel.PageSize, paginatorInfoModel.CurrentPage-1)
                        .ToListAsync();
                case SortState.PriceAsk:
                    return Context
                        .Cryptocurrencies
                        .OrderBy(w=> w.Price)
                        .Page(paginatorInfoModel.PageSize, paginatorInfoModel.CurrentPage)
                        .ToListAsync();
                case SortState.PriceDesk:
                    return Context
                        .Cryptocurrencies
                        .OrderByDescending(w=> w.Price)
                        .Page(paginatorInfoModel.PageSize, paginatorInfoModel.CurrentPage-1)
                        .ToListAsync();
                default:
                    return Context
                        .Cryptocurrencies
                        .Page(paginatorInfoModel.PageSize, paginatorInfoModel.CurrentPage-1)
                        .ToListAsync();
            }
        }

    }
}
