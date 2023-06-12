namespace MirrorTube.Common.Models.Database.UserData
{
    public class NormalizedVideoId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string VideoId { get; set; }
    }
}
