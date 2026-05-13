using System;
using System.IO;
using System.Text.Json;

namespace handlyAdminScreens.Helpers
{
    // Guarda y carga listas en JSON en una carpeta "cache/" junto al ejecutable.
    // Si el archivo no existe o está corrupto, devuelve null para que el llamador vaya a la API.
    public static class CacheService
    {
        private static readonly string CacheDir =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cache");

        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
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
    }
}
