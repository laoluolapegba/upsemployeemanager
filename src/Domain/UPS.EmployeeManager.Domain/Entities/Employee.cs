using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UPS.EmployeeManager.Domain.Entities
{
    /// <summary>
    /// represents an enmployee entity
    /// </summary>
    public class Employee
    {
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("email")]
        public string email { get; set; }
        [JsonPropertyName("gender")]
        public string gender { get; set; }
        [JsonPropertyName("status")]
        public string status { get; set; }
        
    }
}
