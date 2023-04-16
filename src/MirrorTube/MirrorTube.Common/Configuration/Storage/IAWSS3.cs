namespace MirrorTube.Common.Configuration.Storage
{
    public interface IAWSS3Config
    {
        string AccessKeyId { get; set; }
        string SecretAccessKey { get; set; }
        string SessionToken { get; set; }
        string BucketName { get; set; }
        string RegionEndpoint { get; set; }
    }
}
