using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Application.Features.ViewModels.Employee
{
    public  class EmployeesByManagerModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Domain.Entities.Employee, EmployeesByManagerModel>()
                .ReverseMap();

            }
        }
    }
}
