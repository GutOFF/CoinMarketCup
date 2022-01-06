using Microsoft.AspNetCore.Identity;

namespace Entity.Model
{
    public class Role : IdentityRole
    {
        public bool IsPublish { get; set; }
    }
}
