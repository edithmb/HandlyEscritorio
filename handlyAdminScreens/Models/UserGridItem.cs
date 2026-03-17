using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace handlyAdminScreens
{
    internal class UserGridItem
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
                    case 1:
                        return "cliente";

                    case 2:
                        return "profesional";

                    case 3:
                        return "admin";

                    case 4:
                        return "super admin";

                    default:
                        return "otro";
                }
            }
        }


        [JsonPropertyName("account_state_id")]
        public int StateId { get; set; }

        [JsonIgnore]
        public string StateName
        {
            get
            {
                switch (StateId)
                {
                    case 1:
                        return "active";

                    case 2:
                        return "banned";

                    case 3:
                        return "pending aprobation";

                    case 4:
                        return "in revision";

                    case 5:
                        return "inactive";

                    case 6:
                        return "deleted";

                    default:
                        return "otro";
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


        [JsonPropertyName("birthdate")]
        public DateTime Birthdate { get; set; }


        [JsonPropertyName("mobile")]
        public string MobileNumber { get; set; }


        [JsonPropertyName("last_connection")]
        public DateTime LastConnection { get; set; }


        [JsonPropertyName("account_creation_date")]
        public DateTime AccountCreation { get; set; }


        [JsonIgnore]
        public bool IsAppUser { get; set; }

    }
}
