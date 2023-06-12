using NeoSmart.SecureStore;

namespace MirrorTube.Common.Secure
{
    public sealed class SecureStore
    {
        private static readonly string SECURE_DB_STORE = Path.Combine(Globals.ServerDataPath, "secure.json");
        private static readonly string SECURE_DB_KEY = Path.Combine(Globals.ServerDataPath, "secure.key");

        public static void CreateSecureStore()
        {
            if (!DoesSecureStoreExist())
            {
                using var sman = SecretsManager.CreateStore();
                sman.GenerateKey();

                sman.ExportKey(SECURE_DB_KEY);
                sman.SaveStore(SECURE_DB_STORE);
            }
        }

        public static bool DoesSecureStoreExist()
        {
            return File.Exists(SECURE_DB_STORE) && File.Exists(SECURE_DB_KEY);
        }


        public static bool Update(string key, string value)
        {
            return UpdateInternal(key, value);
        }
        public static bool Update<T>(string key, T value)
        {
            return UpdateInternal(key, value);
        }
        private static bool UpdateInternal<T>(string key, T value)
        {
            try
            {
                using (var sman = SecretsManager.LoadStore(SECURE_DB_STORE))
                {
                    sman.LoadKeyFromFile(SECURE_DB_KEY);
                    sman.Set(key, value);
                    sman.SaveStore(SECURE_DB_STORE);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string Decrypt(string key)
        {
            return DecryptInternal<string>(key) ?? string.Empty;
        }
        public static T? Decrypt<T>(string key)
        {
            return DecryptInternal<T>(key);
        }
        private static T? DecryptInternal<T>(string key)
        {
            using (var sman = SecretsManager.LoadStore(SECURE_DB_STORE))
            {
                sman.LoadKeyFromFile(SECURE_DB_KEY);

                if (!sman.TryGetValue(key, out T outValue))
                {
                    return default;
                }
                return outValue;
            }
        }

        public static bool Delete(string key)
        {
            try
            {
                using (var sman = SecretsManager.LoadStore(SECURE_DB_STORE))
                {
                    sman.LoadKeyFromFile(SECURE_DB_KEY);
                    sman.Delete(key);
                    sman.SaveStore(SECURE_DB_STORE);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }        
    }
}
