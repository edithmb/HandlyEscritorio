using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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

        [JsonIgnore]
        public string TaskCreation => Task?.CreationDate.ToString("dd/MM/yyyy HH:mm") ?? "-";

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

            [JsonIgnore]
            public string TaskStateName
            {
                get
                {
                    switch (TaskStateId)
                    {
                        case 1: return "solicited";
                        case 2: return "negotiating";
                        case 3: return "in process";
                        case 4: return "accepted";
                        case 5: return "finalized";
                        case 6: return "cancelled";
                        case 7: return "expired";
                        default: return "otro";
                    }
                }
            }

            [JsonPropertyName("creation_date")]
            public DateTime CreationDate { get; set; }


            [JsonPropertyName("client")]
            public UserShortData Client { get; set; }

            [JsonPropertyName("professional")]
            public UserShortData Professional { get; set; }
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
            public DateTime PaymentDate { get; set; }

            [JsonPropertyName("professional_revenue")]
            public double ProfessionalRevenue { get; set; }

            [JsonPropertyName("app_comission")]
            public double AppComission { get; set; }
        }
    }
}


/*
 edith tiene que enviar algo asi:

{
  "task": {
    "id": 1050,
    "title": "Fuga de agua en el baño",
    "task_state_id": 5,
    "creation_date": "2026-04-01T10:00:00",
    "client": {
      "id": 45,
      "name": "María",
      "surname": "García"
    },
    "professional": {
      "id": 89,
      "name": "Juan",
      "surname": "Pérez"
    },
    "profession_name": "Fontanero"
  },
  "invoice": {
    "total_payment": 60.50,
    "app_comission": 6.05,
    "payment_method": "tarjeta"
  }
}

 */