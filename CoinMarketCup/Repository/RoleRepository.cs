using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Entity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoinMarketCup.Repository
{
    public class RoleRepository : RepositoryBase<Role>
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public Task<List<Role>> GetPublishRoles()
        {
            return Context.RolesRole
                .Where(w => w.IsPublish)
                .ToListAsync();
        }

        public Task<bool> IsPublishRole(string normalizedName)
        {
            return Context
                .RolesRole
                .AnyAsync(w => w.NormalizedName == normalizedName && w.IsPublish);
        }

        public Task<Role> GetRoleByNormalizedName(string normalizedName)
        {
            return Context
                .RolesRole
                .FirstOrDefaultAsync(w=>w.NormalizedName == normalizedName);
        }
    }
}
