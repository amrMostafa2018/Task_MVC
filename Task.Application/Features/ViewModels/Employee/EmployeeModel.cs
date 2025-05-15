using Task.Application.Features.ViewModels.Employee;
using Task.Domain.Entities;

namespace Task.Application.Features.ViewModels.Employee
{
    public class EmployeeModel : EmployeeRequestModel
    {
        public string FullName { get; set; }
        public string DepartmentName { get; set; }
        public string ManagerName { get; set; }
        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Domain.Entities.Employee, EmployeeModel>()
                .ForMember(d => d.FullName, opt => opt.MapFrom(s => $"{s.FirstName} {s.LastName}"))
                .ForMember(d => d.ManagerName, opt => opt.MapFrom(s => $"{s.Manager.FirstName} {s.Manager.LastName}"))
                .ForMember(d => d.DepartmentName, opt => opt.MapFrom(s => s.Department.Name))
                .ReverseMap();

            }
        }
    }
}
