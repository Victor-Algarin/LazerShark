namespace MVCPresentationLayer.Migrations
{
    using LazerSharkLogicLayer;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVCPresentationLayer.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Claims;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCPresentationLayer.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MVCPresentationLayer.Models.ApplicationDbContext";
        }

        protected override void Seed(MVCPresentationLayer.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(u => u.UserName == "admin@lazershark.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "admin@lazershark.com",
                    Email = "admin@lazershark.com"
                };

                IdentityResult result = userManager.Create(user, "N3wuser!");

                if (result.Succeeded)
                {
                    userManager.AddClaim(user.Id, new Claim(ClaimTypes.GivenName, "Admin"));
                }

                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Administrator"});
                context.SaveChanges();
                userManager.AddToRole(user.Id, "Administrator");
                context.SaveChanges();

            }
            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Customer" });
            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Administrator" });
        }
    }
}
