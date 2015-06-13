using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using TBP.Blog.Infra.CrossCutting.Identity.Configuration;

namespace TBP.Blog.Infra.CrossCutting.Identity.Context
{
    //[DbConfigurationType(typeof(ContextConfig))]
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext()
            : base("BlogConnectionString", false)
        {
        }

        public IDbSet<Client> Client { get; set; }

        public IDbSet<Claims> Claims { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
    }
}
