using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using handlyAdminScreens;
using handlyAdminScreens.Models;

namespace handlyAdminScreens.Services
{
    // resultado genérico para llamadas API: éxito/fallo + datos + mensaje
    public class ApiResult<T>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
    }

    public class ApiService
    {
        // un único HttpClient para toda la app, así el token vale en todas las pantallas
        private static readonly HttpClient _httpClient = new HttpClient();
        private const string BaseUrl = "http://localhost:8000/api";
        private readonly JsonSerializerOptions _jsonOptions;

        // info del usuario logueado (accesible desde cualquier pantalla)
        public static string AuthToken { get; private set; }
        public static LoginUser CurrentUser { get; private set; }

        public ApiService()
        {
            _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        // -------- AUTENTICACIÓN --------

        public async Task<LoginResult> LoginAsync(string email, string password)
        {
            var result = new LoginResult();

            try
            {
                var payload = new LoginRequest { Email = email, Password = password };
                var json = JsonSerializer.Serialize(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, $"{BaseUrl}/login")
                {
                    Content = content
                };
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.SendAsync(request);
                var body = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    result.ErrorMessage = response.StatusCode == System.Net.HttpStatusCode.Unauthorized
                        ? "Email o contraseña incorrectos."
                        : $"Error del servidor ({(int)response.StatusCode}).";
                    return result;
                }

                var login = JsonSerializer.Deserialize<LoginResponse>(body, _jsonOptions);

                if (login == null || string.IsNullOrEmpty(login.Token) || login.User == null)
                {
                    result.ErrorMessage = "Respuesta inválida del servidor.";
                    return result;
                }

                if (login.User.RoleId != 3 && login.User.RoleId != 4)
                {
                    result.ErrorMessage = "Esta cuenta no tiene permisos de administrador.";
                    return result;
                }

                AuthToken = login.Token;
                CurrentUser = login.User;
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", login.Token);

                result.Success = true;
                result.User = login.User;
                return result;
            }
            catch (HttpRequestException ex)
            {
                result.ErrorMessage = "No se pudo conectar con el servidor. Comprueba que la API esté arrancada.";
                System.Diagnostics.Debug.WriteLine($"HTTP Error: {ex.Message}");
                return result;
            }
            catch (JsonException ex)
            {
                result.ErrorMessage = "Respuesta inesperada del servidor.";
                System.Diagnostics.Debug.WriteLine($"JSON Error: {ex.Message}");
                return result;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = "Error inesperado: " + ex.Message;
                return result;
            }
        }

        public async System.Threading.Tasks.Task LogoutAsync()
        {
            try
            {
                if (!string.IsNullOrEmpty(AuthToken))
                {
                    await _httpClient.PostAsync($"{BaseUrl}/logout", null);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Logout error: {ex.Message}");
            }
            finally
            {
                AuthToken = null;
                CurrentUser = null;
                _httpClient.DefaultRequestHeaders.Authorization = null;
            }
        }

        // -------- HELPERS PRIVADOS --------

        // GET genérico que extrae "data" del envoltorio { status, data, message }
        private async Task<ApiResult<T>> GetEnvelopedAsync<T>(string path) where T : new()
        {
            var result = new ApiResult<T>();
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}{path}");
                var body = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    result.ErrorMessage = ExtractMessage(body, $"Error {(int)response.StatusCode}");
                    result.Data = new T();
                    return result;
                }

                var envelope = JsonSerializer.Deserialize<ApiResponse<T>>(body, _jsonOptions);
                result.Success = true;
                result.Data = envelope != null && envelope.Data != null ? envelope.Data : new T();
                return result;
            }
            catch (HttpRequestException ex)
            {
                result.ErrorMessage = "No se pudo conectar con el servidor.";
                result.Data = new T();
                System.Diagnostics.Debug.WriteLine($"HTTP Error ({path}): {ex.Message}");
                return result;
            }
            catch (JsonException ex)
            {
                result.ErrorMessage = "Respuesta inesperada del servidor.";
                result.Data = new T();
                System.Diagnostics.Debug.WriteLine($"JSON Error ({path}): {ex.Message}");
                return result;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = "Error inesperado: " + ex.Message;
                result.Data = new T();
                return result;
            }
        }

        // PUT/PATCH genérico con cuerpo JSON
        private async Task<ApiResult<bool>> SendJsonAsync(HttpMethod method, string path, object payload)
        {
            var result = new ApiResult<bool> { Data = false };
            try
            {
                var json = JsonSerializer.Serialize(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(method, $"{BaseUrl}{path}") { Content = content };
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.SendAsync(request);
                var body = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    result.ErrorMessage = ExtractMessage(body, $"Error {(int)response.StatusCode}");
                    return result;
                }

                result.Success = true;
                result.Data = true;
                return result;
            }
            catch (HttpRequestException ex)
            {
                result.ErrorMessage = "No se pudo conectar con el servidor.";
                System.Diagnostics.Debug.WriteLine($"HTTP Error ({path}): {ex.Message}");
                return result;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = "Error inesperado: " + ex.Message;
                return result;
            }
        }

        // intenta sacar el campo "message" de un cuerpo JSON; si falla devuelve el fallback
        private string ExtractMessage(string body, string fallback)
        {
            try
            {
                using (var doc = JsonDocument.Parse(body))
                {
                    if (doc.RootElement.TryGetProperty("message", out var msg))
                    {
                        return msg.GetString();
                    }
                }
            }
            catch { /* ignorar parse errors */ }
            return fallback;
        }

        // -------- USUARIOS --------

        // GET /api/users - listado para grid
        public async Task<List<User>> GetAllUsersAsync()
        {
            var r = await GetEnvelopedAsync<List<User>>("/users");
            if (!r.Success && !string.IsNullOrEmpty(r.ErrorMessage))
            {
                System.Diagnostics.Debug.WriteLine($"GetAllUsers error: {r.ErrorMessage}");
            }
            return r.Data ?? new List<User>();
        }

        // GET /api/users/{id} - detalles completos (la API devuelve más datos aquí)
        public async Task<ApiResult<User>> GetUserByIdAsync(long id)
        {
            return await GetEnvelopedAsync<User>($"/users/{id}");
        }

        // PUT /api/clients/{id} - actualiza datos de Users + App_users (vale para clientes y profesionales)
        // (el endpoint /api/users/{id} hace lo mismo en teoría pero su método 'update' aún no existe en la API)
        //
        // IMPORTANTE: la API valida con 'sometimes|required'. Esto significa que si una clave
        // viene en el request debe tener valor, pero si la omitimos completamente la API la ignora.
        // Por eso construimos el payload con un Dictionary y SOLO incluimos los campos no vacíos.
        public async Task<ApiResult<bool>> UpdateUserAsync(User user)
        {
            if (user == null)
            {
                return new ApiResult<bool> { ErrorMessage = "Usuario nulo." };
            }

            var payload = new Dictionary<string, object>();

            if (!string.IsNullOrWhiteSpace(user.Name)) payload["name"] = user.Name;
            if (!string.IsNullOrWhiteSpace(user.LastName)) payload["surname"] = user.LastName;
            if (!string.IsNullOrWhiteSpace(user.MobileNumber)) payload["mobile"] = user.MobileNumber;
            if (!string.IsNullOrWhiteSpace(user.StreetNumber)) payload["street_number"] = user.StreetNumber;
            if (!string.IsNullOrWhiteSpace(user.City)) payload["city"] = user.City;
            if (!string.IsNullOrWhiteSpace(user.Postalcode)) payload["postal_code"] = user.Postalcode;
            if (!string.IsNullOrWhiteSpace(user.Country)) payload["country"] = user.Country;

            if (payload.Count == 0)
            {
                return new ApiResult<bool> { ErrorMessage = "No hay nada que actualizar." };
            }

            return await SendJsonAsync(HttpMethod.Put, $"/clients/{user.Id}", payload);
        }

        // PATCH /api/users/{id}/state - cambia el estado (activo/baneado/etc)
        public async Task<ApiResult<bool>> ChangeUserStateAsync(long userId, int stateId)
        {
            var payload = new { account_state_id = stateId };
            return await SendJsonAsync(new HttpMethod("PATCH"), $"/users/{userId}/state", payload);
        }

        // -------- TRANSACCIONES --------

        // GET /api/admin/transactions - lista completa con tarea + factura
        public async Task<ApiResult<List<Transaction>>> GetAllTransactionsAsync()
        {
            return await GetEnvelopedAsync<List<Transaction>>("/admin/transactions");
        }

        // -------- TAREAS --------

        public async Task<List<Task>> GetAllTasksAsync()
        {
            var r = await GetEnvelopedAsync<List<Task>>("/admin/tasks");
            return r.Data ?? new List<Task>();
        }

        // -------- PROFESIONES --------

        public async Task<List<Profession>> GetAllProfessionsAsync()
        {
            var r = await GetEnvelopedAsync<List<Profession>>("/professions");
            return r.Data ?? new List<Profession>();
        }
    }
}
