using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Database
{
    public class OSIdentityContext : IdentityDbContext<IdentityUser>
    {
        public OSIdentityContext(DbContextOptions<OSIdentityContext> options) : base(options)
        {

        }
    }
}
