using CoinMarketCup.API;
using CoinMarketCup.Interface;
using CoinMarketCup.Repository;
using CoinMarketCup.Service;
using Microsoft.Extensions.DependencyInjection;

namespace CoinMarketCup.Extension
{
    public static class Di
    {
        public static void DiContainer(IServiceCollection services)
        {

            services.AddTransient<RoleRepository>();
            services.AddScoped<RoleRepository>();
            services.AddTransient<CoinMarketRepository>();
            services.AddTransient<SettingCryptocurrencyRepository>();


            services.AddTransient<AccountService>();
            services.AddTransient<ICoinMarketCupService, CoinMarketCupService>();

            services.AddTransient<ICallApiCoinMarketCup, CallCoinMarketCup>();
        }
    }
}
