using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace handlyAdminScreens
{
    public class User
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }


        [JsonPropertyName("user_id")]
        public long UserId { get; set; }


        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonPropertyName("surname")]
        public string LastName { get; set; }


        [JsonPropertyName("email")]
        public string Email { get; set; }


        [JsonPropertyName("rol_id")]
        public int RoleId { get; set; }

        [JsonIgnore]
        public string RoleName
        {
            get
            {
                switch (RoleId)
                {
                    case 1:return "cliente";
                    case 2:return "profesional";
                    case 3:return "admin";
                    case 4:return "super admin";
                    default:return "otro";
                }
            }          
        }

        [JsonPropertyName("profession")]
        public List<String> Profession { get; set; } = new List<String>();

        [JsonIgnore]
        public string ProfessionSummary
        {
            get
            {
                if (Profession == null || Profession.Count == 0) return "-";
                return string.Join(", ", Profession);
            }
        }


        // nullable porque admins/superadmins no tienen entrada en App_users
        // (la API hace LEFT JOIN y devuelve null para esos casos)
        [JsonPropertyName("account_state_id")]
        public int? StateId { get; set; }

        [JsonIgnore]
        public string StateName
        {
            get
            {
                if (!StateId.HasValue) return "-";
                switch (StateId.Value)
                {
                    case 1: return "active";
                    case 2: return "banned";
                    case 3: return "pending aprobation";
                    case 4: return "in revision";
                    case 5: return "inactive";
                    case 6: return "deleted";
                    default: return "otro";
                }
            }
        }


        [JsonPropertyName("dni")]
        public string DNI { get; set; }


        [JsonPropertyName("street_number")]
        public string StreetNumber { get; set; }


        [JsonPropertyName("city")]
        public string City { get; set; }


        [JsonPropertyName("postal_code")]
        public string Postalcode { get; set; }


        [JsonPropertyName("country")]
        public string Country { get; set; }


        // todos los campos de fecha son nullable porque la API puede devolver null
        // (ej. usuarios sin App_users entry como admin/superadmin)
        [JsonPropertyName("birthdate")]
        public DateTime? Birthdate { get; set; }


        [JsonPropertyName("mobile")]
        public string MobileNumber { get; set; }


        [JsonPropertyName("last_connection")]
        public DateTime? LastConnection { get; set; }


        [JsonPropertyName("account_creation_date")]
        public DateTime? AccountCreation { get; set; }


        [JsonIgnore]
        public bool IsAppUser { get; set; }

    }
}
