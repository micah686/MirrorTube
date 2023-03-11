﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace MirrorTube.API.Database.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
    : base(options)
        {
        }
    }
}
