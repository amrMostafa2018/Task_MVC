using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Employee;
using Task.Application.Interfaces;

namespace Task.Application.Features.Commands.Employee
{
    public class AddEmployeeCommand : IRequest<ResponseVM>
    {
        public EmployeeRequestModel employeeRequest { get; set; }
    }
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, ResponseVM>
    {
        private readonly IEmployeeService _EmployeeService;
        public AddEmployeeCommandHandler(IEmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;
        }
        public async Task<ResponseVM> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await _EmployeeService.AddEmployee(request.employeeRequest);
        }
    }
}
