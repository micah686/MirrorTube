using MirrorTube.API.Configuration.Storage;

namespace MirrorTube.API.Configuration
{
    public interface IStorageConfiguration
    {
        ILocalConfig LocalConfig { get; set; }
        IFtpConfig FtpConfig { get; set; }
        ISftpConfig SftpConfig { get; set; }
        IAWSS3Config AWSS3Config { get; set; }
        
    }

}

