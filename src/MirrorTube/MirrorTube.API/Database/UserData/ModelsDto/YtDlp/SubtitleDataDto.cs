using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MirrorTube.API.Database.UserData.ModelsDto.YtDlp
{
    public class SubtitleDataDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public string PK_ID { get; set; }

        public string? LangCode { get; set; }
        public string? SubtitleData { get; set; }
        public SubtitleType SubtitleType { get; set; }

    }
    public enum SubtitleType
    {
        Unknown,
        Vtt,
        Ttml,
        Srv3,
        Srv2,
        Srv1,
        Json3        
    }
}
