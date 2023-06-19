using Microsoft.EntityFrameworkCore;
using MirrorTube.API.Database.UserData.Triggers;
using MirrorTube.Common.Models.Database.UserData;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MirrorTube.API.Database.UserData
{
    public class UserDataContext : DbContext
    {
        public UserDataContext(DbContextOptions<UserDataContext> options) : base(options)
        {
        }

        //public DbSet<TestUser> Users { get; set; }
        public DbSet<LookupResources> LookupResources { get; set; }
        public DbSet<LookupResourcesHistory> LookupResourcesHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(DatabaseSchema.userdata.ToString());

            builder.Entity<LookupResources>().HasKey(h => h.Id);
            builder.Entity<LookupResourcesHistory>().HasKey(h => h.AcroFsId);
        }

    }

    

    public class TestUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTimeOffset DateTime { get; set; }
    }
}
