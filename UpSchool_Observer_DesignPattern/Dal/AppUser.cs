using Microsoft.AspNetCore.Identity;

namespace UpSchool_Observer_DesignPattern.Dal
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
    }
}
