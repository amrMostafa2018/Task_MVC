using TaskStatus = Task.Domain.Common.Enums.TaskStatus;

namespace Task.Application.Features.ViewModels.Task
{
    public class EmployeeTaskItemModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public string EmployeeName { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Domain.Entities.TaskAssignment, EmployeeTaskItemModel>()
                .ForMember(d => d.EmployeeName, opt => opt.MapFrom(s => $"{s.AssignedTo.FullName}"))
                .ReverseMap();
            }
        }
    }
}
