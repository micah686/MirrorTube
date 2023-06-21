using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MirrorTube.Common.Models.Database.UserData;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MirrorTube.API.Database.UserData.Configuration
{
    public class NormalizedLanguagesConfiguration : IEntityTypeConfiguration<NormalizedLanguages>
    {
        void IEntityTypeConfiguration<NormalizedLanguages>.Configure(EntityTypeBuilder<NormalizedLanguages> builder)
        {
            builder.HasKey(nl => nl.Id);

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .OrderBy(x => x.Parent.TwoLetterISOLanguageName)
                .GroupBy(t => t.TwoLetterISOLanguageName)
                .Select(c => c.First())
                .Where(x => x.TwoLetterISOLanguageName.Length == 2).ToArray();
            for (int i = 0; i < cultures.Length; i++)
            {
                builder.HasData(new NormalizedLanguages
                {
                    Id = i+1,
                    LanguageShort = cultures[i].Parent.TwoLetterISOLanguageName,
                    LanguageDescription = cultures[i].Parent.EnglishName
                });
            }            
        }
    }
}
