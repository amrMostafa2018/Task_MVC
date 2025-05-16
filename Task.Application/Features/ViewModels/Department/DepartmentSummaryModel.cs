using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Application.Features.ViewModels.Department
{
    public class DepartmentSummaryModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int EmployeeCount { get; set; }
        public decimal TotalSalary { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Domain.Entities.Department, DepartmentSummaryModel>()
                     .ForMember(d => d.DepartmentName, opt => opt.MapFrom(s => s.Name))
                     .ForMember(d => d.EmployeeCount, opt => opt.MapFrom(s => s.Employees.Count))
                     .ForMember(d => d.TotalSalary, opt => opt.MapFrom(s => s.Employees.Sum(e => (decimal?)e.Salary) ?? 0))
                .ReverseMap();

            }
        }
    }
}
