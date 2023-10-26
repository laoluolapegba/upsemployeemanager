using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPS.EmployeeManager.Shared.Models
{
    

    public record EmployeeRequestError
    {
        public IReadOnlyList<string> ErrorMessages { get; }

        public EmployeeRequestError(IReadOnlyList<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}
