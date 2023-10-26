using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPS.EmployeeManager.Domain.Entities;
using UPS.EmployeeManager.Shared.Models;

namespace UPS.EmployeeManager.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeModel>> GetAllAsync();
        Task<EmployeeModel> CreateAsync(EmployeeModel newEmployee);
        Task<EmployeeModel> UpdateAsync(int employeeId, EmployeeModel employeeModel);

        Task<IEnumerable<EmployeeModel>> SearchByNameAsync(string name);

        Task<EmployeeModel> GetByIdAsync(int employeeId);

        Task<bool> DeleteAsync(int id);
        void ExportEmployeesToCsv(IEnumerable<EmployeeModel> employees, string filePath);

    }
}
