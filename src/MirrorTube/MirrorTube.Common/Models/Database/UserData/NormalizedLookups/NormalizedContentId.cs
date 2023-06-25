namespace MirrorTube.Common.Models.Database.UserData.NormalizedLookups
{
    public class NormalizedContentId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ContentId { get; set; }
    }
}
