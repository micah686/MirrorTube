using Microsoft.EntityFrameworkCore;
using MirrorTube.Common.Models.Database.UserData;
using System;

namespace MirrorTube.API.Database.UserData
{
    public class UserDataContext : DbContext
    {
        public UserDataContext(DbContextOptions<UserDataContext> options) : base(options)
        {
        }

        public DbSet<NormalizedVideoId> NormalizedVideoId { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
