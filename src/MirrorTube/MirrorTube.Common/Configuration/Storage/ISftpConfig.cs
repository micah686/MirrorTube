namespace MirrorTube.Common.Configuration.Storage
{
    public interface ISftpConfig
    {
        string Hostname { get; set; }
        ushort Port { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string PrivateKeyFile { get; set; }
    }
}
