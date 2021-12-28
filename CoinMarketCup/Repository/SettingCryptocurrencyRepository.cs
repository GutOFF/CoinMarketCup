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

        public async Task<string> GetApiKey()
        {
            return (await Context.SettingCryptocurrency.FirstOrDefaultAsync())
                .ApiKey;
        }

        public async Task<int> GetLimit()
        {
            return (await Context.SettingCryptocurrency.FirstOrDefaultAsync())
                .Limit;
        }
        public async Task<int> GetCountMetadata()
        {
            return (await Context.SettingCryptocurrency.FirstOrDefaultAsync())
                .MaxCountMetadata;
        }

        public async Task<int> GetExpiryDateExpired()
        {
            return (await Context.SettingCryptocurrency.FirstOrDefaultAsync())
                .ExpiryDateExpired;
        }

        public async Task<string> GetFiatCurrency()
        {
            return (await Context.SettingCryptocurrency.FirstOrDefaultAsync())
                .FiatCurrency;
        }
    }
}
