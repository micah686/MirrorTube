namespace MirrorTube.API
{
    public static class StartupChecks
    {
        internal static void RunStartupChecks()
        {
            CreateDirectories();
        }

        private static void CreateDirectories()
        {
            Directory.CreateDirectory(Globals.ServerDataPath);            
        }
    }
}
