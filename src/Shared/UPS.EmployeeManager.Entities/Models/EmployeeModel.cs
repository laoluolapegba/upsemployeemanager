using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UPS.EmployeeManager.Shared.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }
        public string Status { get; set; }
    }
}
