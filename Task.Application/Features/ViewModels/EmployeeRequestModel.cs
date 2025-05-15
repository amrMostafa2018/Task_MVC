using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Entities;

namespace Task.Application.Features.ViewModels
{
    public class EmployeeRequestModel
    {
        public int Id { get; set; }
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
                CreateMap<EmployeeRequestModel, Employee>().ReverseMap();
            }
        }
    }
}
