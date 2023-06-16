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

        public DbSet<StoreUser> MyStore { get; set; }

        public DbSet<VideoInfoHistory> VideoInfoHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("mirrortube");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql(@"User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=postgres;Include Error Detail=true")
                .UseTriggers(triggerOptions => {
                    triggerOptions.AddTrigger<VideoHistoryAddTrigger>();
                });

            base.OnConfiguring(optionsBuilder);
        }
    }

    public class StoreUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; private set; }

    }
}
