using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TBP.Blog.Infra.CrossCutting.Identity.Context
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext()
            : base("BlogConnectionString", false)
        { }

        public IDbSet<Claims> Claims { get; set; }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
    }
}
