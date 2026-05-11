using System;
using System.Text.Json.Serialization;

namespace handlyAdminScreens
{
    public class Report
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("report_origin")]
        public string ReportOrigin { get; set; }

        [JsonPropertyName("cause")]
        public string Cause { get; set; }

        [JsonPropertyName("state_id")]
        public int StateId { get; set; }

        [JsonPropertyName("state_name")]
        public string StateName { get; set; }

        [JsonPropertyName("reporter_id")]
        public long ReporterId { get; set; }

        [JsonPropertyName("reporter_name")]
        public string ReporterName { get; set; }

        [JsonPropertyName("reporter_surname")]
        public string ReporterSurname { get; set; }

        [JsonPropertyName("reportee_id")]
        public long ReporteeId { get; set; }

        [JsonPropertyName("reportee_name")]
        public string ReporteeName { get; set; }

        [JsonPropertyName("reportee_surname")]
        public string ReporteeSurname { get; set; }

        // helpers de solo lectura para mostrar en el grid
        [JsonIgnore]
        public string ReporterFullName => $"{ReporterName} {ReporterSurname}".Trim();

        [JsonIgnore]
        public string ReporteeFullName => $"{ReporteeName} {ReporteeSurname}".Trim();
    }
}
