using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OrderService.Api.Database.Seed
{
    public static class IdentitySeedData
    {
        private const string userAdmin = "admin";
        private const string passwordAdmin = "Admin@2020";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var manager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                var user = await manager.FindByIdAsync(userAdmin);
                if (user == null)
                {
                    user = new IdentityUser(userAdmin);
                    await manager.CreateAsync(user, passwordAdmin);
                }         
            }            
        }
    }
}
