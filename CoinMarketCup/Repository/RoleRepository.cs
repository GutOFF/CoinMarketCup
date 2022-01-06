using Entity;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinMarketCup.Repository
{
    public class RoleRepository : RepositoryBase<Role>
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public Task<List<Role>> GetPublicRoles()
        {
            return Context.Roles
                .Where(w => w.IsPublic)
                .ToListAsync();
        }

        public Task<bool> IsPublicRole(string normalizedName)
        {
            return Context
                .Roles
                .AnyAsync(w => w.NormalizedName == normalizedName && w.IsPublic);
        }

        public Task<Role> GetRoleByNormalizedName(string normalizedName)
        {
            return Context
                .Roles
                .FirstOrDefaultAsync(w=>w.NormalizedName == normalizedName);
        }
    }
}
