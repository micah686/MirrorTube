namespace MirrorTube.API.Interfaces
{
    public interface IVideoDbWriterService
    {
        public Task SaveInfoToDb(string filepath);
    }
}
