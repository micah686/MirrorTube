using System.ComponentModel;

namespace MirrorTube.API.Configuration.Storage
{
    public interface ILocalConfig
    {
        public string DirectoryPath { get; set; }
    }
}
