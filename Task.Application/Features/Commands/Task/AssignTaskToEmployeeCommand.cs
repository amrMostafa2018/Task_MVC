using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Task;
using Task.Application.Interfaces;

namespace Task.Application.Features.Commands.Task
{
    public class AssignTaskToEmployeeCommand : IRequest<ResponseVM>
    {
        public EmployeeTaskRequestModel employeeTaskRequest { get; set; }
    }
    public class AssignTaskToEmployeeCommandHandler : IRequestHandler<AssignTaskToEmployeeCommand, ResponseVM>
    {
        private readonly ITaskService _TaskService;
        public AssignTaskToEmployeeCommandHandler(ITaskService TaskService)
        {
            _TaskService = TaskService;
        }
        public async Task<ResponseVM> Handle(AssignTaskToEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await _TaskService.AssignTaskToEmployee(request.employeeTaskRequest);
        }
    }
}
