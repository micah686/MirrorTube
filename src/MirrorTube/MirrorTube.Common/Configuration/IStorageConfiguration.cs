using MirrorTube.Common.Configuration.Storage;

namespace MirrorTube.Common.Configuration
{
    public interface IStorageConfiguration
    {
        ILocalConfig LocalConfig { get; set; }

    }

}

