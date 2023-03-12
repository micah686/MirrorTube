using Config.Net;
using FluentFTP;
using FluentStorage;
using FluentStorage.Blobs;
using MirrorTube.API.Configuration;
using MirrorTube.API.Configuration.Storage;
using MirrorTube.API.Interfaces;
using Renci.SshNet;
using System.Net;
using static System.Net.WebRequestMethods;

namespace MirrorTube.API.Services
{
    public class StorageService: IStorageService
    {        

        public IBlobStorage GetStorageBlob()
        {
            IBlobStorage storage;
            var settings = new ConfigurationBuilder<ISettingsRoot>()
                .UseJsonFile("config.json")
                .Build();
            var storageSettings = settings.StorageSettings;
            if(storageSettings == null)
            {
                storage = StorageFactory.Blobs.DirectoryFiles(Globals.UserDataPath);
                return storage;
            }
            storage = storageSettings.StorageType switch
            {
                StorageType.Local => GetLocalStorage(storageSettings.StorageConfig.LocalConfig),
                StorageType.FTP => GetFtpStorage(storageSettings.StorageConfig.FtpConfig),
                StorageType.SFTP => GetSftpStorage(storageSettings.StorageConfig.SftpConfig),
                StorageType.ASWS3 => GetAwsS3Storage(storageSettings.StorageConfig.AWSS3Config),
                _ => StorageFactory.Blobs.DirectoryFiles(Globals.UserDataPath),
            };
            return storage;
        }

        private IBlobStorage GetLocalStorage(ILocalConfig localConfig)
        {
            IBlobStorage storage;
            storage = StorageFactory.Blobs.DirectoryFiles(localConfig.DirectoryPath);
            return storage;
        }
        private IBlobStorage GetFtpStorage(IFtpConfig ftpConfig)
        {
            IBlobStorage storage;
            var client = new AsyncFtpClient(ftpConfig.Hostname, new NetworkCredential(ftpConfig.Username, ftpConfig.Password), ftpConfig.Port);
            storage = StorageFactory.Blobs.FtpFromFluentFtpClient(client);
            return storage;
        }
        private IBlobStorage GetSftpStorage(ISftpConfig sftpConfig)
        {
            IBlobStorage storage;
            if(string.IsNullOrEmpty(sftpConfig.PrivateKeyFile))
            {
                storage = StorageFactory.Blobs.Sftp(sftpConfig.Hostname, sftpConfig.Port, sftpConfig.Username, sftpConfig.Password);
            }
            else
            {
                storage = StorageFactory.Blobs.Sftp(sftpConfig.Hostname, sftpConfig.Username, new PrivateKeyFile(sftpConfig.PrivateKeyFile));
            }
            return storage;
        }
        private IBlobStorage GetAwsS3Storage(IAWSS3Config awsS3Config)
        {
            IBlobStorage storage;
            storage = StorageFactory.Blobs.AwsS3(awsS3Config.AccessKeyId, awsS3Config.SecretAccessKey, awsS3Config.SessionToken, awsS3Config.BucketName, awsS3Config.RegionEndpoint);
            return storage;
        }
    }
}
