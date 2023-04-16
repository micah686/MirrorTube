using MirrorTube.Common.Configuration.Storage;

namespace MirrorTube.Common.Configuration
{
    public interface IStorageConfiguration
    {
        ILocalConfig LocalConfig { get; set; }
        IFtpConfig FtpConfig { get; set; }
        ISftpConfig SftpConfig { get; set; }
        IAWSS3Config AWSS3Config { get; set; }

    }

}

