using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinMarketCup.Service;
using Microsoft.Extensions.DependencyInjection;

namespace CoinMarketCup.Extension
{
    public static class Di
    {
        public static void DiContainer(IServiceCollection services)
        {
            #region Repository

            #endregion

            #region Service

            services.AddTransient<LoginService>();

            #endregion

        }
    }
}
