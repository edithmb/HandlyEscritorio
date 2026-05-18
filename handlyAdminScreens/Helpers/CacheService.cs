using System;
using System.IO;
using System.Text.Json;

namespace handlyAdminScreens.Helpers
{ 
    public static class CacheService
    {
        private static readonly string CacheDir =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cache");

        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        // ficheros de datos transitorios (se borran al arrancar/cerrar sesión)
        // los catálogos NO están aquí: rara vez cambian y se recargan tras el login
        private static readonly string[] DataCacheFiles = new[]
        {
            "users.json",
            "users_verification.json",
            "transactions.json",
            "reports.json"
        };

        public static void Save<T>(string filename, T data)
        {
            try
            {
                Directory.CreateDirectory(CacheDir);
                var path = Path.Combine(CacheDir, filename);
                File.WriteAllText(path, JsonSerializer.Serialize(data, Options));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"CacheService.Save error ({filename}): {ex.Message}");
            }
        }

        public static T Load<T>(string filename) where T : class
        {
            try
            {
                var path = Path.Combine(CacheDir, filename);
                if (!File.Exists(path)) return null;
                return JsonSerializer.Deserialize<T>(File.ReadAllText(path), Options);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"CacheService.Load error ({filename}): {ex.Message}");
                return null;
            }
        }

        // borra UN fichero de cache
        public static void Delete(string filename)
        {
            try
            {
                var path = Path.Combine(CacheDir, filename);
                if (File.Exists(path)) File.Delete(path);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"CacheService.Delete error ({filename}): {ex.Message}");
            }
        }

        // borra todos los ficheros de datos (usuarios, transacciones, denuncias, verificación).
        // Se llama al arrancar la app y al hacer logout para que el siguiente login
        // muestre datos frescos del API en cada pestaña.
        public static void ClearDataCaches()
        {
            foreach (var f in DataCacheFiles) Delete(f);
        }
    }
}
