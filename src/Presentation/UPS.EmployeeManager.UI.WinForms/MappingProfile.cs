using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPS.EmployeeManager.Domain.Entities;
using UPS.EmployeeManager.Shared.Models;

namespace UPS.EmployeeManager.UI.WinForms
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeModel>().ReverseMap();            
         }
    }
}
