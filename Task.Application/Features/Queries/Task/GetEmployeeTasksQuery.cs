using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Task;
using Task.Application.Interfaces;

namespace Task.Application.Features.Queries.Employee
{
    public class GetEmployeeTasksQuery : IRequest<ResponseVM<List<EmployeeTaskItemModel>>>
    {
        public int managerId { get; set; }
    }
    public class GetEmployeeTasksQueryHandler : IRequestHandler<GetEmployeeTasksQuery, ResponseVM<List<EmployeeTaskItemModel>>>
    {
        private readonly ITaskService _TaskService;
        public GetEmployeeTasksQueryHandler(ITaskService TaskService)
        {
            _TaskService = TaskService;
        }

        public async Task<ResponseVM<List<EmployeeTaskItemModel>>> Handle(GetEmployeeTasksQuery request, CancellationToken cancellationToken)
        {
            return await _TaskService.GetEmployeeTasks(request.managerId);
        }
    }
}
