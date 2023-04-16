using System.ComponentModel;

namespace MirrorTube.Common.Configuration.Storage
{
    public interface ILocalConfig
    {
        public string DirectoryPath { get; set; }
    }
}
