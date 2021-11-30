using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Identity;

namespace CoinMarketCup.Repository
{
    public class RoleRepository : RepositoryBase<IdentityRole>
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
                
        }
    }
}
