namespace MirrorTube.Common.Configuration
{
    public interface ISettingsRoot
    {
        IStorageSettings StorageSettings { get; set; }
    }
}
