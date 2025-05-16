using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Employee;
using Task.Application.Interfaces;

namespace Task.Application.Features.Commands.Employee
{
    public class EditEmployeeCommand : IRequest<ResponseVM>
    {
        public EmployeeRequestModel employeeRequest { get; set; }
    }
    public class EditEmployeeCommandHandler : IRequestHandler<EditEmployeeCommand, ResponseVM>
    {
        private readonly IEmployeeService _EmployeeService;
        public EditEmployeeCommandHandler(IEmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;
        }
        public async Task<ResponseVM> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await _EmployeeService.EditEmployee(request.employeeRequest);
        }
    }
}
