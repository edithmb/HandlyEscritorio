using System;
using System.Text.Json.Serialization;
using handlyAdminScreens.Services;

namespace handlyAdminScreens.Models
{
    public class Transaction
    {
        [JsonPropertyName("task")]
        public TaskData Task { get; set; }

        [JsonPropertyName("invoice")]
        public InvoiceData Invoice { get; set; }


        [JsonIgnore]
        public long TaskID => Task?.Id ?? 0;


        //TODO crec que es pot treure
        [JsonIgnore]
        public string TaskCreation =>
            (Task != null && Task.CreationDate.HasValue)
                ? Task.CreationDate.Value.ToString("dd/MM/yyyy HH:mm")
                : "-";

        [JsonIgnore]
        public string TaskState => Task?.TaskStateName ?? "Desconocido";

        [JsonIgnore]
        public string ClientName => Task?.Client != null ? $"{Task.Client.Name} {Task.Client.LastName}" : "-";

        [JsonIgnore]
        public string ProfesionalName => Task?.Professional != null ? $"{Task.Professional.Name} {Task.Professional.LastName}" : "-";

        [JsonIgnore]
        public string TaskTitle => Task?.Title ?? "-";

        [JsonIgnore]
        public string TotalPayment => Invoice != null ? $"{Invoice.TotalPayment}€" : "Pendiente";

        public class TaskData
        {
            [JsonPropertyName("id")]
            public long Id { get; set; }

            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonPropertyName("task_state_id")]
            public int TaskStateId { get; set; }

            // nombre del estado de la tarea: lo cogemos del catálogo cargado tras el login
            [JsonIgnore]
            public string TaskStateName
            {
                get
                {
                    string result = "-";
                    var name = Catalogs.TaskStateName(TaskStateId);

                    if (!string.IsNullOrEmpty(name) && name != "-")
                    {
                        result = name.ToLower();
                    }

                    return result;
                }
            }

            [JsonPropertyName("creation_date")]
            public DateTime? CreationDate { get; set; }


            [JsonPropertyName("client")]
            public UserShortData Client { get; set; }

            [JsonPropertyName("professional")]
            public UserShortData Professional { get; set; }

            [JsonPropertyName("photo_1")]
            public string Photo1 { get; set; }

            [JsonPropertyName("photo_2")]
            public string Photo2 { get; set; }
        }

        public class UserShortData
        {
            [JsonPropertyName("id")]
            public long Id { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("surname")]
            public string LastName { get; set; }
        }

        public class InvoiceData
        {
            [JsonPropertyName("id")]
            public long Id { get; set; }

            [JsonPropertyName("total_payment")]
            public double TotalPayment { get; set; }

            [JsonPropertyName("payment_method")]
            public string PaymentMethod { get; set; }

            [JsonPropertyName("payment_date")]
            public DateTime? PaymentDate { get; set; }

            [JsonPropertyName("professional_revenue")]
            public double ProfessionalRevenue { get; set; }

            [JsonPropertyName("app_comission")]
            public double AppComission { get; set; }
        }
    }
}
