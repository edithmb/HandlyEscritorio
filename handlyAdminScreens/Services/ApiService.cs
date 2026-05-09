using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using handlyAdminScreens;
using handlyAdminScreens.Models;

namespace handlyAdminScreens.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://localhost:8000/api";
        private readonly JsonSerializerOptions _jsonOptions;

        public ApiService()
        {
            _httpClient = new HttpClient();
            _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        // GET: All users
        public async Task<List<User>> GetAllUsersAsync()
        {
            List<User> result = new List<User>();

            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/users");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<List<User>>(json, _jsonOptions) ?? new List<User>();
                }
                else
                {
                    throw new HttpRequestException($"API Error: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                System.Diagnostics.Debug.WriteLine($"HTTP Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                System.Diagnostics.Debug.WriteLine($"JSON Deserialization Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Unexpected Error: {ex.Message}");
            }

            return result;
        }

        // GET: All tasks (admin endpoint)
        public async Task<List<Task>> GetAllTasksAsync()
        {
            List<Task> result = new List<Task>();

            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/admin/tasks");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<List<Task>>(json, _jsonOptions) ?? new List<Task>();
                }
                else
                {
                    throw new HttpRequestException($"API Error: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                System.Diagnostics.Debug.WriteLine($"HTTP Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                System.Diagnostics.Debug.WriteLine($"JSON Deserialization Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Unexpected Error: {ex.Message}");
            }

            return result;
        }

        // GET: All invoices (admin endpoint)
        public async Task<List<Models.Transaction>> GetAllInvoicesAsync()
        {
            List<Models.Transaction> result = new List<Models.Transaction>();

            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/admin/invoices");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<List<Models.Transaction>>(json, _jsonOptions) ?? new List<Models.Transaction>();
                }
                else
                {
                    throw new HttpRequestException($"API Error: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                System.Diagnostics.Debug.WriteLine($"HTTP Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                System.Diagnostics.Debug.WriteLine($"JSON Deserialization Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Unexpected Error: {ex.Message}");
            }

            return result;
        }

        // GET: All professions
        public async Task<List<Profession>> GetAllProfessionsAsync()
        {
            List<Profession> result = new List<Profession>();

            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/professions");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<List<Profession>>(json, _jsonOptions) ?? new List<Profession>();
                }
                else
                {
                    throw new HttpRequestException($"API Error: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                System.Diagnostics.Debug.WriteLine($"HTTP Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                System.Diagnostics.Debug.WriteLine($"JSON Deserialization Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Unexpected Error: {ex.Message}");
            }

            return result;
        }
    }
}
