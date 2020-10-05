using Microsoft.AspNetCore.Identity;

namespace backend.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public virtual Country Country { get; set; }
    }
}
