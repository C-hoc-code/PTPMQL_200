using Microsoft.AspNetCore.Identity;

namespace DemoMVCIdentity.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FullName { get; set; }
    }
}