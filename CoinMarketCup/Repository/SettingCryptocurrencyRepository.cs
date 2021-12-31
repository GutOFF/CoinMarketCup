using Entity;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoinMarketCup.Repository
{
    public class SettingCryptocurrencyRepository : RepositoryBase<SettingCryptocurrency>
    {
        public SettingCryptocurrencyRepository(ApplicationDbContext context) : base(context)
        {
        }

        public virtual async Task<string> GetApiKey()
        {
            return (await Context.SettingCryptocurrency.FirstOrDefaultAsync())
                .ApiKey;
        }

        public virtual async Task<int> GetLimit()
        {
            return (await Context.SettingCryptocurrency.FirstOrDefaultAsync())
                .Limit;
        }
        public virtual async Task<int> GetCountMetadata()
        {
            return (await Context.SettingCryptocurrency.FirstOrDefaultAsync())
                .MaxCountMetadata;
        }

        public virtual async Task<int> GetExpiryDateExpired()
        {
            return (await Context.SettingCryptocurrency.FirstOrDefaultAsync())
                .ExpiryDateExpired;
        }

        public virtual async Task<string> GetFiatCurrency()
        {
            return (await Context.SettingCryptocurrency.FirstOrDefaultAsync())
                .FiatCurrency;
        }
    }
}
