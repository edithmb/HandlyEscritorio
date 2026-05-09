using System;
using System.Collections.Generic;
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

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        // Get all users
        public async Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/users");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var users = JsonSerializer.Deserialize<List<User>>(json, options);
                    return users ?? new List<User>();
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return new List<User>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return new List<User>();
            }
        }

        // Get all tasks (admin endpoint)
        public async Task<List<Task>> GetAllTasksAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/admin/tasks");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var tasks = JsonSerializer.Deserialize<List<Task>>(json, options);
                    return tasks ?? new List<Task>();
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return new List<Task>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return new List<Task>();
            }
        }

        // Get all invoices (admin endpoint)
        public async Task<List<Models.Transaction>> GetAllInvoicesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/admin/invoices");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var invoices = JsonSerializer.Deserialize<List<Models.Transaction>>(json, options);
                    return invoices ?? new List<Models.Transaction>();
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return new List<Models.Transaction>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return new List<Models.Transaction>();
            }
        }

        // Get all professions
        public async Task<List<Profession>> GetAllProfessionsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/professions");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var professions = JsonSerializer.Deserialize<List<Profession>>(json, options);
                    return professions ?? new List<Profession>();
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return new List<Profession>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return new List<Profession>();
            }
        }
    }
}
