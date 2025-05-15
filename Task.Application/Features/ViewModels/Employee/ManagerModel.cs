using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Entities;

namespace Task.Application.Features.ViewModels.Employee
{
    public class ManagerModel
    {
        public int Id { get; set; }
        public string ManagerName { get; set; }
        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Domain.Entities.Employee, ManagerModel>()
                .ForMember(d => d.ManagerName, opt => opt.MapFrom(s => $"{s.FirstName} {s.LastName}"))
                .ReverseMap();

            }
        }
    }
}
