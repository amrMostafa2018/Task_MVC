using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Employee;
using Task.Application.Interfaces;

namespace Task.Application.Features.Queries.Employee
{
    public class GetEmployeeByIdQuery : IRequest<ResponseVM<EmployeeModel>>
    {
        public int Id { get; set; }
    }
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, ResponseVM<EmployeeModel>>
    {
        private readonly IEmployeeService _EmployeeService;
        public GetEmployeeByIdQueryHandler(IEmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;
        }

        public async Task<ResponseVM<EmployeeModel>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _EmployeeService.GetEmployeeById(request.Id);
        }
    }
}
