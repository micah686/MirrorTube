using Innofactor.EfCoreJsonValueConverter;
using Microsoft.EntityFrameworkCore;
using MirrorTube.API.Database.UserData.ModelsDto;
using MirrorTube.API.Database.UserData.ModelsDto.YtDlp;
using Newtonsoft.Json;
using System.Reflection.Emit;
using System.Text.Json;
using YoutubeDLSharp.Metadata;

namespace MirrorTube.API.Database.UserData
{
    public class UserDatadbContext : DbContext
    {
        public UserDatadbContext(DbContextOptions<UserDatadbContext> options) : base(options)
        {
        }

        public DbSet<VideoDataDto> VideoDataDto { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //VideoData
            builder.Entity<VideoDataDto>().Property(x => x.Tags).HasJsonValueConversion();
            builder.Entity<VideoDataDto>().Property(x => x.Categories).HasJsonValueConversion();
            builder.Entity<VideoDataDto>().Property(x => x.Cast).HasJsonValueConversion();
            builder.Entity<VideoDataDto>().Property(x => x.Chapters).HasJsonValueConversion();





            //end
            base.OnModelCreating(builder);
        }
    }

}
