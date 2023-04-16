namespace MirrorTube.Common.Configuration.Storage
{
    public interface IFtpConfig
    {
        string Hostname { get; set; }
        ushort Port { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}
