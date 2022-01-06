using Microsoft.AspNetCore.Identity;

namespace Entity.Model
{
    public class Role : IdentityRole
    {
        public bool IsPublic { get; set; }
    }
}
