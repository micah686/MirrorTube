using FluentStorage.Blobs;

namespace MirrorTube.API.Interfaces
{
    public interface IStorageService
    {
        IBlobStorage GetStorageBlob();
    }
}
