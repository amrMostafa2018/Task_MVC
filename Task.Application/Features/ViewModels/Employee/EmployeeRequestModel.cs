using System.ComponentModel.DataAnnotations;

namespace Task.Application.Features.ViewModels.Employee
{
    public class EmployeeRequestModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public string? ImagePath { get; set; }
        public int? ManagerId { get; set; }
        public int DepartmentId { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<EmployeeRequestModel, Domain.Entities.Employee>().ReverseMap();
            }
        }
    }
}
