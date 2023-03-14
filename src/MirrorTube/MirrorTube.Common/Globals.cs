using MirrorTube.API.Configuration;

namespace MirrorTube.Common
{
    public static class Globals
    {
        public static string BasePath { get; } = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) ?? "";
        public static string ServerDataPath { get; } = Path.Combine(BasePath, "Data", "ServerData");
        public static string UserDataPath { get; } = Path.Combine(BasePath, "Data", "UserData");
        public static string DbIdentity { get; } = Path.Combine(ServerDataPath, "Identity.db");
        public static string DbHangfire { get; } = Path.Combine(ServerDataPath, "Hangfire.db");
        public static string DbMirrorTube { get; } = Path.Combine(ServerDataPath, "MirrorTube.db");
        public static ISettingsRoot ConfigSettings { get; set; }
    }
}