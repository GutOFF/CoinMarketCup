using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            #endregion

            #region Service

            services.AddTransient<LoginService>();
            services.AddTransient<CoinMarketCupService>();

            #endregion

            #region Helpers

            services.AddTransient<CoinMarketCupHelpers>();

            #endregion
        }
    }
}
