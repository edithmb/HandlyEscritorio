using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace handlyAdminScreens.Models
{
    // Contexto de una denuncia: chats o tareas entre las dos partes
    // (la API decide qué llenar según report_origin)
    public class ReportContext
    {
        [JsonPropertyName("report_id")]
        public long ReportId { get; set; }

        [JsonPropertyName("report_origin")]
        public string ReportOrigin { get; set; }

        [JsonPropertyName("chats")]
        public List<ChatInfo> Chats { get; set; } = new List<ChatInfo>();

        [JsonPropertyName("tasks")]
        public List<TaskInfo> Tasks { get; set; } = new List<TaskInfo>();
    }

    public class ChatInfo
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("task_id")]
        public long? TaskId { get; set; }

        [JsonPropertyName("client_id")]
        public long? ClientId { get; set; }

        [JsonPropertyName("professional_id")]
        public long? ProfessionalId { get; set; }

        [JsonPropertyName("messages")]
        public List<MessageInfo> Messages { get; set; } = new List<MessageInfo>();
    }

    public class MessageInfo
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("chat_id")]
        public long ChatId { get; set; }

        [JsonPropertyName("sent_by")]
        public long? SentBy { get; set; }

        [JsonPropertyName("recived_by")]
        public long? RecivedBy { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("message_date")]
        public System.DateTime? MessageDate { get; set; }
    }

    public class TaskInfo
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("task_state_id")]
        public int? TaskStateId { get; set; }

        [JsonPropertyName("task_state_name")]
        public string TaskStateName { get; set; }

        [JsonPropertyName("creation_date")]
        public System.DateTime? CreationDate { get; set; }

        [JsonPropertyName("client_id")]
        public long? ClientId { get; set; }

        [JsonPropertyName("professional_id")]
        public long? ProfessionalId { get; set; }

        [JsonPropertyName("profession_id")]
        public int? ProfessionId { get; set; }
    }
}
