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
            #region Repository

            services.AddTransient<RoleRepository>();
            services.AddScoped<RoleRepository>();
            services.AddTransient<CoinMarketRepository>();
            services.AddTransient<SettingCryptocurrencyRepository>();
            #endregion

            #region Service

            services.AddTransient<LoginService>();
            services.AddTransient<CoinMarketCupService>();

            #endregion

            #region Helpers

            services.AddTransient<CoinMarketCupHelpers>();

            #endregion

            services.AddTransient<CallCoinMarketCup>();
        }
    }
}
