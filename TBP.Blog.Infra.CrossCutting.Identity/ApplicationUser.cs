using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TBP.Blog.Infra.CrossCutting.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, ClaimsIdentity ext = null)
        {
            // Observe que o authenticationType precisa ser o mesmo que foi definido em CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Adicionando Claims externos capturados no login
            if (ext != null)
            {
                await SetExternalProperties(userIdentity, ext);
            }

            return userIdentity;
        }

        private async Task SetExternalProperties(ClaimsIdentity identity, ClaimsIdentity ext)
        {
            if (ext != null)
            {
                // Adicionando Claims Externos no Identity
                foreach (var c in ext.Claims.Where(c => !identity.HasClaim(c.Type, c.Value)))
                {
                    identity.AddClaim(c);
                }
            }
        }
    }
}