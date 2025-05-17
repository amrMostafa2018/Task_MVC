using TaskStatus = Task.Domain.Common.Enums.TaskStatus;

namespace Task.Application.Features.ViewModels.Task
{
    public class EmployeeTaskRequestModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.Pending;
        public int AssignedToId { get; set; }
        public int ManagerCreatedById { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<EmployeeTaskRequestModel, Domain.Entities.TaskAssignment>().ReverseMap();
            }
        }
    }
}
