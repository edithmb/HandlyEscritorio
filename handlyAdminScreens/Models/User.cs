using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using handlyAdminScreens.Services;

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
                string result = "-";
                var name = Catalogs.RoleName(RoleId);

                if (!string.IsNullOrEmpty(name) && name != "-")
                {
                    result = name.ToLower();
                }

                return result;
            }
        }

        [JsonPropertyName("profession")]
        public List<String> Profession { get; set; } = new List<String>();


        [JsonIgnore]
        public string ProfessionSummary
        {
            get
            {
                string result = "-";

                if (Profession != null && Profession.Count > 0)
                {
                    result = string.Join(", ", Profession);
                }

                return result;
            }
        }


        [JsonPropertyName("account_state_id")]
        public int? StateId { get; set; }


        [JsonIgnore]
        public string StateName
        {
            get
            {
                string result = "-";

                if (StateId.HasValue)
                {
                    var name = Catalogs.AccountStateName(StateId);

                    if (!string.IsNullOrEmpty(name))
                    {
                        result = name;
                    }
                }

                return result;
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
        public DateTime? Birthdate { get; set; }

        [JsonPropertyName("mobile")]
        public string MobileNumber { get; set; }

        [JsonPropertyName("last_connection")]
        public DateTime? LastConnection { get; set; }

        [JsonPropertyName("account_creation_date")]
        public DateTime? AccountCreation { get; set; }

        [JsonIgnore]
        public bool IsAppUser { get; set; }

        [JsonPropertyName("selfie")]
        public string Selfie { get; set; }

        [JsonPropertyName("document_front")]
        public string DocumentFront { get; set; }

        [JsonPropertyName("document_back")]
        public string DocumentBack { get; set; }
    }
}
