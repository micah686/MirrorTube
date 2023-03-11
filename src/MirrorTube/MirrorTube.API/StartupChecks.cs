using MirrorTube.Common.Secure;
namespace MirrorTube.API
{
    public static class StartupChecks
    {
        internal static void RunStartupChecks()
        {
            CreateDirectories();
            if (!SecureStore.DoesSecureStoreExist())
            {
                SecureStore.CreateSecureStore();
            }
        }

        private static void CreateDirectories()
        {
            Directory.CreateDirectory(Globals.ServerDataPath);            
        }
    }
}
