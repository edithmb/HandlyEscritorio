using System.Text.Json.Serialization;

namespace handlyAdminScreens.Models
{
    // envoltorio genérico que usa la API: { status, message, data }
    public class ApiResponse<T>
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("data")]
        public T Data { get; set; }
    }

    // body que mandamos al endpoint /api/login
    public class LoginRequest
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }

    // respuesta del endpoint /api/login
    public class LoginResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("user")]
        public LoginUser User { get; set; }
    }

    // usuario simplificado tal y como lo devuelve el login
    public class LoginUser
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("rol_id")]
        public int RoleId { get; set; }
    }

    // resultado que la UI consume tras llamar a LoginAsync
    public class LoginResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public LoginUser User { get; set; }
    }
}
