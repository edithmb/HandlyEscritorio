using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace handlyAdminScreens.Models
{
    // un valor genérico de tabla de catálogo: id + name
    // sirve para account_states, budget_states, report_states, roles, task_states
    public class CatalogItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        public override string ToString() => Name ?? string.Empty;
    }

    // shape devuelto por GET /api/admin/catalogs (data: { ...estos campos... })
    public class CatalogBundle
    {
        [JsonPropertyName("account_states")]
        public List<CatalogItem> AccountStates { get; set; } = new List<CatalogItem>();

        [JsonPropertyName("budget_states")]
        public List<CatalogItem> BudgetStates { get; set; } = new List<CatalogItem>();

        [JsonPropertyName("report_states")]
        public List<CatalogItem> ReportStates { get; set; } = new List<CatalogItem>();

        [JsonPropertyName("roles")]
        public List<CatalogItem> Roles { get; set; } = new List<CatalogItem>();

        [JsonPropertyName("task_states")]
        public List<CatalogItem> TaskStates { get; set; } = new List<CatalogItem>();
    }
}
