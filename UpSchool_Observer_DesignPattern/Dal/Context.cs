using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UpSchool_Observer_DesignPattern.Dal
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Discount> Discounts { get; set; }
    }
}
