using System;
using System.Text.Json.Serialization;

namespace handlyAdminScreens
{
    // Una denuncia tal y como la devuelve GET /api/admin/reports
    public class Report
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("report_origin")]
        public string ReportOrigin { get; set; }

        [JsonPropertyName("cause")]
        public string Cause { get; set; }

        // nullable por si el report tiene estado nulo o desconocido
        [JsonPropertyName("state_id")]
        public int? StateId { get; set; }

        [JsonPropertyName("state_name")]
        public string StateName { get; set; }

        [JsonPropertyName("reporter_id")]
        public long? ReporterId { get; set; }

        [JsonPropertyName("reporter_name")]
        public string ReporterName { get; set; }

        [JsonPropertyName("reporter_surname")]
        public string ReporterSurname { get; set; }

        [JsonPropertyName("reportee_id")]
        public long? ReporteeId { get; set; }

        [JsonPropertyName("reportee_name")]
        public string ReporteeName { get; set; }

        [JsonPropertyName("reportee_surname")]
        public string ReporteeSurname { get; set; }

        // helpers para mostrar en el grid en vez del id crudo
        [JsonIgnore]
        public string ReporterFullName =>
            string.IsNullOrWhiteSpace(ReporterName) && string.IsNullOrWhiteSpace(ReporterSurname)
                ? "-"
                : $"{ReporterName} {ReporterSurname}".Trim();

        [JsonIgnore]
        public string ReporteeFullName =>
            string.IsNullOrWhiteSpace(ReporteeName) && string.IsNullOrWhiteSpace(ReporteeSurname)
                ? "-"
                : $"{ReporteeName} {ReporteeSurname}".Trim();

        [JsonIgnore]
        public string StateDisplay => string.IsNullOrWhiteSpace(StateName) ? "-" : StateName;
    }

    // Estado de denuncia (para poblar el filtro)
    public class ReportState
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
