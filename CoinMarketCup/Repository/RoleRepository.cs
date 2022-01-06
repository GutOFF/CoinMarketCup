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

        public Task<List<Role>> GetPublishRoles()
        {
            return Context.Roles
                .Where(w => w.IsPublish)
                .ToListAsync();
        }

        public Task<bool> IsPublishRole(string normalizedName)
        {
            return Context
                .Roles
                .AnyAsync(w => w.NormalizedName == normalizedName && w.IsPublish);
        }

        public Task<Role> GetRoleByNormalizedName(string normalizedName)
        {
            return Context
                .Roles
                .FirstOrDefaultAsync(w=>w.NormalizedName == normalizedName);
        }
    }
}
