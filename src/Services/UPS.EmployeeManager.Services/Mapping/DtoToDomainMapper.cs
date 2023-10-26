using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPS.EmployeeManager.Domain.Entities;
using UPS.EmployeeManager.Shared.Models;

namespace UPS.EmployeeManager.Services.Mapping
{
    public static class DtoToDomainMapper
    {
        public static Employee ToCustomer(this EmployeeModel employeeDto)
        {
            return new Employee
            {
                id = employeeDto.Id,
                email = employeeDto.Email,
                gender = employeeDto.Gender,
                name = employeeDto.Name,
                status = employeeDto.Status
            };
        }
    }
}
