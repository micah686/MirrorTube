using Acrobit.AcroFS;
using MirrorTube.Common.Models;

namespace MirrorTube.Common.Helpers
{
    public static class FileStorage
    {
        private static readonly string _basePath = $@"{Globals.UserDataPath}\images\";

        public static long StoreData<T>(StoragePath roots, T data)
		{
            var _repository = FileStore.CreateStore($@"{_basePath}{roots}", new StoreConfig() { UseSimplePath = true });
			var id = _repository.Store<T>(data);
			return id;
        }

        public static T? GetData<T>(StoragePath roots, long id)
        {
            var _repository = FileStore.CreateStore($@"{_basePath}{roots}", new StoreConfig() { UseSimplePath = true });
            var data = _repository.Load<T>(id);
            return data;
        }

        public static long StoreStreamData(StoragePath roots, Stream stream)
        {
            var _repository = FileStore.CreateStore($@"{_basePath}{roots}", new StoreConfig() { UseSimplePath = true });
            var id = _repository.Store(stream);
            return id;
        }

        public static Stream? GetStreamData(StoragePath roots, long id)
        {
            var _repository = FileStore.CreateStore($@"{_basePath}{roots}", new StoreConfig() { UseSimplePath = true });
            var data = _repository.Load(id);
            return data;
        }
    }
}
