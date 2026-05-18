using System.Collections.Generic;
using System.Linq;
using handlyAdminScreens.Helpers;
using handlyAdminScreens.Models;

namespace handlyAdminScreens.Services
{
    // Acceso global a las tablas de catálogo (estados, roles) cargadas del API.
    //
    // Las cargamos UNA vez justo después del login, las guardamos en disco
    // (cache/catalogs.json) y las exponemos por estos getters. Si los valores
    // cambian en la base de datos sólo hay que volver a loguearse para refrescar.
    public static class Catalogs
    {
        private const string CacheFile = "catalogs.json";

        private static CatalogBundle _bundle = new CatalogBundle();

        public static CatalogBundle Current => _bundle;

        // intenta cargar desde el cache local (sin pegar a la API)
        public static bool LoadFromDisk()
        {
            var b = CacheService.Load<CatalogBundle>(CacheFile);
            if (b == null) return false;
            _bundle = b;
            return true;
        }

        // sobrescribe el bundle en memoria + escribe el cache en disco
        public static void Set(CatalogBundle bundle)
        {
            _bundle = bundle ?? new CatalogBundle();
            CacheService.Save(CacheFile, _bundle);
        }

        public static void Clear()
        {
            _bundle = new CatalogBundle();
            CacheService.Delete(CacheFile);
        }

        // ----- helpers de lookup -----
        // (devuelven "-" si el id no existe; nunca lanzan excepción)

        public static string AccountStateName(int? id) => Lookup(_bundle.AccountStates, id);
        public static string BudgetStateName(int? id)  => Lookup(_bundle.BudgetStates, id);
        public static string ReportStateName(int? id)  => Lookup(_bundle.ReportStates, id);
        public static string RoleName(int? id)         => Lookup(_bundle.Roles, id);
        public static string TaskStateName(int? id)    => Lookup(_bundle.TaskStates, id);

        // lista de profesiones para poblar dropdowns sin pegar al API
        public static List<Profession> Professions => _bundle.Professions ?? new List<Profession>();

        private static string Lookup(List<CatalogItem> list, int? id)
        {
            if (list == null || !id.HasValue) return "-";
            var found = list.FirstOrDefault(x => x.Id == id.Value);
            return found != null ? found.Name : "-";
        }
    }
}
