using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPS.EmployeeManager.Domain.Entities;
using UPS.EmployeeManager.Shared.Models;

namespace UPS.EmployeeManager.Services.Mapping
{
    public static class DomainToDtoMapper
    {
        public static EmployeeModel ToEmployeeDto(this Employee employee)
        {
            return new EmployeeModel
            {
                Id = employee.id,
                Email = employee.email,
                Name = employee.name,
                Gender = employee.gender,
                Status = employee.status
            };
        }
    }
}
