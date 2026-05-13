using System;
using System.Text.Json.Serialization;

namespace handlyAdminScreens
{
    public class JobTask
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("client_id")]
        public long ClientId { get; set; }

        [JsonPropertyName("professional_id")]
        public long ProfessionalId { get; set; }

        [JsonPropertyName("profession_id")]
        public int ProfessionId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("task_state_id")]
        public int TaskStateId { get; set; }

        [JsonPropertyName("token_qr")]
        public string TokenQr { get; set; }

        [JsonPropertyName("creation_date")]
        public DateTime CreationDate { get; set; }

        [JsonPropertyName("accorded_date")]
        public DateTime? AccordedDate { get; set; }

        [JsonPropertyName("accorded_time")]
        public TimeSpan? AccordedTime { get; set; }

        [JsonPropertyName("review_to_client")]
        public string ReviewToClient { get; set; }

        [JsonPropertyName("score_to_client")]
        public int? ScoreToClient { get; set; }

        [JsonPropertyName("review_to_professional")]
        public string ReviewToProfessional { get; set; }

        [JsonPropertyName("score_to_professional")]
        public int? ScoreToProfessional { get; set; }
    }
}
