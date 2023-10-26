using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Http;

namespace UPS.EmployeeManager.Services
{
    public interface IHttpClientService
    {
        HttpClient CreateClient(string name);
    }
}
