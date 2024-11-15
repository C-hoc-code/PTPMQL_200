namespace DemoMVC.Models.ViewModels
{
    public class UserWithRoleVM
    {
        public ApplicationUser User { get; set; }
        public IList<String> Roles { get; set; }
    }
}