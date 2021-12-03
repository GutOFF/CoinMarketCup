using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinMarketCup.Monad;
using Entity.Model;
using Microsoft.AspNetCore.Identity;

namespace CoinMarketCup.Service
{
    public class RoleService
    {

        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService( RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<Return<bool>> CreateRole(string roleName, bool isPublish)
        {
            IdentityResult result = await _roleManager.CreateAsync(new Role()
            {
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                IsPublish = isPublish
            });

            return result.Succeeded
                ? Return<bool>.ReturnSuccessfully(true)
                : Return<bool>.ReturnFail("error_create_role");
        }
    }
}
