using CoinMarketCup.API;
using CoinMarketCup.Helpers;
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


            services.AddTransient<LoginService>();
            services.AddTransient<CoinMarketCupService>();

     
            services.AddTransient<CallCoinMarketCup>();
        }
    }
}
