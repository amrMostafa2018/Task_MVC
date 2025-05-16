using Task.Application.Common.Response;
using Task.Application.Interfaces;

namespace Task.Application.Features.Commands.Employee
{
    public class DeleteEmployeeCommand : IRequest<ResponseVM>
    {
        public int Id { get; set; }
    }
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, ResponseVM>
    {
        private readonly IEmployeeService _EmployeeService;
        public DeleteEmployeeCommandHandler(IEmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;
        }
        public async Task<ResponseVM> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return new ResponseVM()
            {
                Data = await _EmployeeService.DeleteEmployee(request.Id)
            };
        }
    }
}
