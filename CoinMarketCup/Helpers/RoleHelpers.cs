using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CoinMarketCup.Monad;
using Entity;
using Entity.Model;
using Microsoft.AspNetCore.Identity;

namespace CoinMarketCup.Helpers
{
    public class RoleHelpers
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleHelpers(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;

        }

    }
}
