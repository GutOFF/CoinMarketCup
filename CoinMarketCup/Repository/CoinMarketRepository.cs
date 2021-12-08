using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Entity;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace CoinMarketCup.Repository
{
    public class CoinMarketRepository : RepositoryBase<Cryptocurrency>
    {
        public CoinMarketRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<bool> IsExpiryDateExpired()
        {
            var cryptocurrency = await Context.Cryptocurrencies
                .FirstOrDefaultAsync();

            if (cryptocurrency == null) return true;
            var timeExpire = DateTimeOffset
                .UtcNow
                .AddMinutes(5);

            return timeExpire < cryptocurrency.DateAdded;
        }



    }
}
