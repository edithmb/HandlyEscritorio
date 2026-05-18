using System;
using System.Text.Json.Serialization;
using handlyAdminScreens.Services;

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
        public int? StateId { get; set; }

        [JsonPropertyName("state_name")]
        public string StateName { get; set; }

        [JsonPropertyName("reporter_id")]
        public long? ReporterId { get; set; }

        [JsonPropertyName("reporter_user_id")]
        public long? ReporterUserId { get; set; }

        [JsonPropertyName("reporter_name")]
        public string ReporterName { get; set; }

        [JsonPropertyName("reporter_surname")]
        public string ReporterSurname { get; set; }

        [JsonPropertyName("reportee_id")]
        public long? ReporteeId { get; set; }

        [JsonPropertyName("reportee_user_id")]
        public long? ReporteeUserId { get; set; }

        [JsonPropertyName("reportee_name")]
        public string ReporteeName { get; set; }

        [JsonPropertyName("reportee_surname")]
        public string ReporteeSurname { get; set; }

        [JsonIgnore]
        public string ReporterFullName
        {
            get
            {
                string result = "-";

                if (!string.IsNullOrWhiteSpace(ReporterName) || !string.IsNullOrWhiteSpace(ReporterSurname))
                {
                    result = $"{ReporterName} {ReporterSurname}".Trim();
                }

                return result;
            }
        }

        [JsonIgnore]
        public string ReporteeFullName
        {
            get
            {
                string result = "-";

                if (!string.IsNullOrWhiteSpace(ReporteeName) || !string.IsNullOrWhiteSpace(ReporteeSurname))
                {
                    result = $"{ReporteeName} {ReporteeSurname}".Trim();
                }

                return result;
            }
        }


        [JsonPropertyName("reporter_rol_id")]
        public int? ReporterRoleId { get; set; }

        [JsonPropertyName("reportee_rol_id")]
        public int? ReporteeRoleId { get; set; }

        [JsonIgnore]
        public string ReporterRoleLabel => RoleLabel(ReporterRoleId);

        [JsonIgnore]
        public string ReporteeRoleLabel => RoleLabel(ReporteeRoleId);
        private static string RoleLabel(int? rolId)
        {
            string result = "";

            if (rolId.HasValue)
            {
                var name = Catalogs.RoleName(rolId);

                if (!string.IsNullOrEmpty(name) && name != "-")
                {
                    name = name.ToLower();
                    result = char.ToUpper(name[0]) + name.Substring(1);
                }
            }

            return result;
        }

        //TODO crec que es pot treure
        [JsonIgnore]
        public string StateDisplay => string.IsNullOrWhiteSpace(StateName) ? "-" : StateName;
    }
}
