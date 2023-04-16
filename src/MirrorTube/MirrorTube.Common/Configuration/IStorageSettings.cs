namespace MirrorTube.Common.Configuration
{
    public interface IStorageSettings
    {
        StorageType StorageType { get; set; }
        IStorageConfiguration StorageConfig { get; set; }
    }

    public enum StorageType
    {
        Local,
        FTP,
        SFTP,
        ASWS3
    }
}
