using FluentStorage;
using FluentStorage.Blobs;
using MirrorTube.API.Interfaces;
using MirrorTube.Common.Configuration;
using MirrorTube.Common.Configuration.Storage;
using System.Net;

namespace MirrorTube.API.Services
{
    public class StorageService: IStorageService
    {        

        public IBlobStorage GetStorageBlob()
        {
            IBlobStorage storage;
            var storageSettings = Globals.ConfigSettings.StorageSettings;
            if(storageSettings == null)
            {
                storage = StorageFactory.Blobs.DirectoryFiles(Globals.UserDataPath);
                return storage;
            }
            storage = storageSettings.StorageType switch
            {
                StorageType.Local => GetLocalStorage(storageSettings.StorageConfig.LocalConfig),
                _ => StorageFactory.Blobs.DirectoryFiles(Globals.UserDataPath),
            };
            return storage;
        }

        private IBlobStorage GetLocalStorage(ILocalConfig localConfig)
        {
            IBlobStorage storage;
            if(localConfig.DirectoryPath == null) { localConfig.DirectoryPath = Globals.UserDataPath; }
            storage = StorageFactory.Blobs.DirectoryFiles(localConfig.DirectoryPath);
            return storage;
        }        
    }
}
