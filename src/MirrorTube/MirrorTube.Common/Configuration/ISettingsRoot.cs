namespace MirrorTube.API.Configuration
{
    public interface ISettingsRoot
    {
        IStorageSettings StorageSettings { get; set; }
    }
}
