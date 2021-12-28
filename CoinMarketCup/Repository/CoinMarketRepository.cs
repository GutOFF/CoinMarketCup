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
        private readonly SettingCryptocurrencyRepository _settingCryptocurrencyRepository;
        public CoinMarketRepository(ApplicationDbContext context, SettingCryptocurrencyRepository settingCryptocurrencyRepository) : base(context)
        {
            _settingCryptocurrencyRepository = settingCryptocurrencyRepository;
        }

        public async Task DeleteAllDate()
        {
            var cryptocurrencies = await Context.Cryptocurrencies.FirstOrDefaultAsync();

            if (cryptocurrencies is null)
            {
                return;
            }

            await Context.Database.ExecuteSqlInterpolatedAsync($"TRUNCATE TABLE Cryptocurrencies");
            await Context.SaveChangesAsync();
        }
        public async Task<bool> IsExpiryDateExpired()
        {
            var cryptocurrencies = await Context.Cryptocurrencies
                .FirstOrDefaultAsync();

            if (cryptocurrencies == null) return true;
            var timeExpire = cryptocurrencies
                .DateAdded
                .AddMinutes(await _settingCryptocurrencyRepository.GetExpiryDateExpired());

            return timeExpire <= DateTime.UtcNow;
        }

        public Task<List<Cryptocurrency>> GetCryptocurrencies(PaginatorInfoModel paginatorInfoModel, SortState sortState)
        {
            return sortState switch
            {
                SortState.DateAsk => Context.Cryptocurrencies.OrderBy(w => w.LastUpdated)
                    .Page(paginatorInfoModel.PageSize, paginatorInfoModel.CurrentPage - 1)
                    .ToListAsync(),
                SortState.DateDesk => Context.Cryptocurrencies.OrderByDescending(w => w.LastUpdated)
                    .Page(paginatorInfoModel.PageSize, paginatorInfoModel.CurrentPage - 1)
                    .ToListAsync(),
                SortState.NameAsc => Context.Cryptocurrencies.OrderBy(w => w.Name)
                    .Page(paginatorInfoModel.PageSize, paginatorInfoModel.CurrentPage - 1)
                    .ToListAsync(),
                SortState.NameDesc => Context.Cryptocurrencies.OrderByDescending(w => w.Name)
                    .Page(paginatorInfoModel.PageSize, paginatorInfoModel.CurrentPage - 1)
                    .ToListAsync(),
                SortState.PriceAsk => Context.Cryptocurrencies.OrderBy(w => w.Price)
                    .Page(paginatorInfoModel.PageSize, paginatorInfoModel.CurrentPage)
                    .ToListAsync(),
                SortState.PriceDesk => Context.Cryptocurrencies.OrderByDescending(w => w.Price)
                    .Page(paginatorInfoModel.PageSize, paginatorInfoModel.CurrentPage - 1)
                    .ToListAsync(),
                _ => Context.Cryptocurrencies.Page(paginatorInfoModel.PageSize, paginatorInfoModel.CurrentPage - 1)
                    .ToListAsync()
            };
        }

    }
}
