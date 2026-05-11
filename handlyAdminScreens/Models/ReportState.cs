using System.Text.Json.Serialization;

namespace handlyAdminScreens
{
    public class ReportState
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        // ToString() para que los ComboBox muestren el nombre directamente
        public override string ToString() => Name ?? string.Empty;
    }
}
