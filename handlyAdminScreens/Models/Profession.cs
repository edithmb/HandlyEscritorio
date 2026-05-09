using System.Text.Json.Serialization;

namespace handlyAdminScreens
{
    public class Profession
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name_profession")]
        public string NameProfession { get; set; }

        [JsonPropertyName("min_price")]
        public double MinPrice { get; set; }
    }
}
