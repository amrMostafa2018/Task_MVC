using Task.Application.Common.Response;
using Task.Application.Features.ViewModels;

namespace Task.Application.Features.Commands
{
    public class AddEmployeeCommand : IRequest<ResponseVM>
    {
        public EmployeeRequestModel employeeRequest { get; set; }
    }
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, ResponseVM>
    {
        public async Task<ResponseVM> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
