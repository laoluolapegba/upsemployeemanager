using AutoMapper;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UPS.EmployeeManager.Domain.Entities;
using UPS.EmployeeManager.Services;
using UPS.EmployeeManager.Shared.Models;
using System.Threading;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Marvin.StreamExtensions;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using UPS.EmployeeManager.Services.Validation;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using UPS.EmployeeManager.Services.Mapping;
using Microsoft.Extensions.Logging;

namespace UPS.EmployeeManager.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        //private readonly IValidator<EmployeeModel> _validator;

        public EmployeeService(IHttpClientService httpClientService, IMapper mapper)
        {
            _httpClientService = httpClientService;
            _mapper = mapper;
            //_logger = logger;
        }

        public async Task<IEnumerable<EmployeeModel>> GetAllAsync()
        {
            using (var httpClient = _httpClientService.CreateClient("UPSTestEndpoint"))
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync("users", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var stream = await response.Content.ReadAsStreamAsync();
                    var employeesResponse = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Employee>>(stream);

                    //return employeesResponse.Select(x => x.ToEmployeeDto());
                    var employeesList = _mapper.Map<List<Employee>, IEnumerable<EmployeeModel>>(employeesResponse);
                    return employeesList;
                }
                catch (HttpRequestException ex)
                {
                    // Handle HTTP request error
                }
            }

            return null;
        }
        public async Task<EmployeeModel> GetByIdAsync(int employeeId)
        {
            using (var httpClient = _httpClientService.CreateClient("UPSTestEndpoint"))
            {
                // Get the access token from app.config
                string accessToken = ConfigurationManager.AppSettings["API_KEY"];

                // Add the authorization header with the access token
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                try
                {
                    // Send a GET request to get an employee by their ID
                    HttpResponseMessage response = await httpClient.GetAsync($"https://gorest.co.in/public/v2/users/{employeeId}");

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var employee = JsonConvert.DeserializeObject<Employee>(content);
                        return employee.ToEmployeeDto();
                    }
                }
                catch (HttpRequestException ex)
                {
                    // Handle HTTP request error
                }
            }

            return null;
        }

        public async Task<EmployeeModel> CreateAsync(EmployeeModel newEmployee)
        {
            using (var httpClient = _httpClientService.CreateClient("UPSTestEndpoint"))
            {
                try
                {
                    // Get the access token from the configuration
                    string accessToken = ConfigurationManager.AppSettings["API_KEY"];

                    // Add the authorization header with the access token
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                    var employee = newEmployee.ToCustomer(); // _mapper.Map<EmployeeModel, Employee>(newEmployee);

                    var employeeJson = JsonConvert.SerializeObject(employee);
                    var content = new StringContent(employeeJson, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync("https://gorest.co.in/public/v2/users", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        var createdEmployee = JsonConvert.DeserializeObject<Employee>(responseContent);
                        return createdEmployee.ToEmployeeDto();
                    }
                }
                catch (HttpRequestException ex)
                {
                    // Handle HTTP request error
                }
            }

            return null;
        }
        public async Task<IEnumerable<EmployeeModel>> SearchByNameAsync(string name)
        {
            using (var httpClient = _httpClientService.CreateClient("UPSTestEndpoint"))
            {
                // Get the access token from app.config
                string accessToken = ConfigurationManager.AppSettings["API_KEY"];

                // Add the authorization header with the access token
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                try
                {
                    // Send a GET request to search for employees by name
                    // GET /public/v2/users?name=john: list all users with name contains john.
                    HttpResponseMessage response = await httpClient.GetAsync($"https://gorest.co.in/public/v2/users?name={name}");

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var employeesResponse = JsonConvert.DeserializeObject<List<Employee>>(content);

                        var employeesList = _mapper.Map<List<Employee>, IEnumerable<EmployeeModel>>(employeesResponse);
                        return employeesList; // employeesResponse.Select(x => x.ToEmployeeDto());
                    }
                }
                catch (HttpRequestException ex)
                {
                    _logger.LogError(ex.Message, ex.InnerException);
                    // Handle HTTP request error
                }
            }

            return null;
        }

        public async Task<EmployeeModel> UpdateAsync(int employeeId, EmployeeModel updatedEmployee)
        {
            using (var httpClient = _httpClientService.CreateClient("UPSTestEndpoint"))
            {
                // Get the access token from app.config
                string accessToken = ConfigurationManager.AppSettings["API_KEY"];

                // Add the authorization header with the access token
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                try
                {
                    // Convert the updated employee to JSON
                    var updatedEmployeeJson = JsonConvert.SerializeObject(updatedEmployee);
                    var content = new StringContent(updatedEmployeeJson, Encoding.UTF8, "application/json");

                    // Send a PUT request to update the employee
                    HttpResponseMessage response = await httpClient.PutAsync($"https://gorest.co.in/public/v2/users/{employeeId}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        var updatedEmployeeResponse = JsonConvert.DeserializeObject<Employee>(responseContent);
                        return updatedEmployeeResponse.ToEmployeeDto();
                    }
                }
                catch (HttpRequestException ex)
                {
                    // Handle HTTP request error
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int employeeId)
        {
            using (var httpClient = _httpClientService.CreateClient("UPSTestEndpoint"))
            {
                // Get the access token from app.config
                string accessToken = ConfigurationManager.AppSettings["API_KEY"];

                // Add the authorization header with the access token
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                try
                {
                    // Send a DELETE request to delete the employee by their ID
                    HttpResponseMessage response = await httpClient.DeleteAsync($"https://gorest.co.in/public/v2/users/{employeeId}");

                    return response.IsSuccessStatusCode;
                }
                catch (HttpRequestException ex)
                {
                    // Handle HTTP request error
                    return false;
                }
            }
        }

        
        
        /// <summary>
        /// serialize to stream instead of string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="stream"></param>
        public static void SerializeJsonIntoStream(object value, Stream stream)
        {
            using (var sw = new StreamWriter(stream, new UTF8Encoding(false), 1024, true))
            using (var jtw = new JsonTextWriter(sw) { Formatting = Formatting.None })
            {
                var js = new Newtonsoft.Json.JsonSerializer();
                js.Serialize(jtw, value);
                jtw.Flush();
            }
        }
        private static HttpContent CreateHttpContent(object content)
        {
            HttpContent httpContent = null;
            if (content != null)
            {
                var ms = new MemoryStream();
                SerializeJsonIntoStream(content, ms);
                ms.Seek(0, SeekOrigin.Begin);
                httpContent = new StreamContent(ms);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }
            return httpContent;
        }

    }
}
