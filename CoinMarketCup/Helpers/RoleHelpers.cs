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
