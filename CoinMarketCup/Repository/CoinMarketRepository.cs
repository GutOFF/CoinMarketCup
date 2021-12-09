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

            await Context.Database.ExecuteSqlInterpolatedAsync($"TRUNCATE TABLE {nameof(Context.Cryptocurrencies)}");
            await Context.SaveChangesAsync();
        }
        public async Task<bool> IsExpiryDateExpired()
        {
            var cryptocurrency = await Context.Cryptocurrencies
                .FirstOrDefaultAsync();

            if (cryptocurrency == null) return true;
            var timeExpire = DateTime
                .UtcNow
                .AddMinutes(5);

            return timeExpire < cryptocurrency.DateAdded;
        }



    }
}
