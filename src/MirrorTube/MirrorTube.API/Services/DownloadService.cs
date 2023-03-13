﻿using FluentStorage.Blobs;
using MirrorTube.API.Database.UserData;
using MirrorTube.API.Interfaces;
using YoutubeDLSharp;
using YoutubeDLSharp.Options;

namespace MirrorTube.API.Services
{
    public class DownloadService : IDownloadService
    {

        private readonly string _tempDownloadPath = Path.Combine(Globals.UserDataPath, "temp");
        private readonly IStorageService _storageService;
        private readonly IBlobStorage _storage;
        public DownloadService(IStorageService storageService)
        {
            _storageService = storageService;

            _storage = _storageService.GetStorageBlob();
        }        



        



        private YoutubeDL CreateYtDlpInstance(string randomDirName)
        {
            var ytdl = new YoutubeDL()
            {
                YoutubeDLPath = Path.Combine(Globals.ServerDataPath, Utils.YtDlpBinaryName),
                FFmpegPath = Path.Combine(Globals.ServerDataPath, Utils.FfmpegBinaryName),
                OutputFileTemplate = "%(extractor)s/[%(id)s]_%(upload_date)s_%(title)s.%(ext)s",
                OutputFolder = Path.Combine(_tempDownloadPath, randomDirName)
            };
            return ytdl;
        }

        private OptionSet CreateOptionSetInstance()
        {
            var options = new OptionSet()
            {
                EmbedThumbnail = true,
                EmbedSubs = true,
                EmbedMetadata = true,
                WriteInfoJson = true,
                NoWritePlaylistMetafiles = true,
                RestrictFilenames = true,
            };
            return options;
        }

        Task IDownloadService.DownloadAudio(string url)
        {
            throw new NotImplementedException();
        }

        Task IDownloadService.DownloadAudioPlaylist(string url)
        {
            throw new NotImplementedException();
        }

        public async Task DownloadVideo(string url)
        {
            var randomDirName = Path.GetRandomFileName();
            var ytdl = CreateYtDlpInstance(randomDirName);
            var output = await ytdl.RunVideoDownload(url, overrideOptions:CreateOptionSetInstance());
            var filepath = output.Data;


            var infoJsonPath = Path.ChangeExtension(filepath, "info.json");
            if (File.Exists(infoJsonPath))
            {
                var blobInfoJsonPath = infoJsonPath.Replace($"{Path.Combine(_tempDownloadPath, randomDirName)}\\", string.Empty);
                await _storage.WriteFileAsync(blobInfoJsonPath, infoJsonPath);
            }

            var blobVideoPath = filepath.Replace($"{Path.Combine(_tempDownloadPath, randomDirName)}\\", string.Empty);
            await _storage.WriteFileAsync(blobVideoPath, filepath);
            Directory.Delete(Path.Combine(_tempDownloadPath, randomDirName), true);
        }

        Task IDownloadService.DownloadVideoPlaylist(string url)
        {
            throw new NotImplementedException();
        }
    }
}
