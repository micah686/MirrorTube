using MirrorTube.Common.Models;

namespace MirrorTube.API.Interfaces
{
    public interface IVideoDbWriterService
    {
        public Task SaveInfoToDb(string filepath);

        public abstract HexId GenerateUniqueID(IEnumerable<string> mixValues);
    }
}
