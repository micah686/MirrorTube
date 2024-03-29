﻿global using System.ComponentModel.DataAnnotations.Schema;
global using System.ComponentModel.DataAnnotations;
using MirrorTube.Common.Configuration;

namespace MirrorTube.Common
{
    public static class Globals
    {
        public static string BasePath { get; } = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) ?? "";
        public static string ServerDataPath { get; } = Path.Combine(BasePath, "Data", "ServerData");
        public static string UserDataPath { get; } = Path.Combine(BasePath, "Data", "UserData");
        public static string DbIdentity { get; } = Path.Combine(ServerDataPath, "Identity.db");
        public static ISettingsRoot ConfigSettings { get; set; }
    }
}