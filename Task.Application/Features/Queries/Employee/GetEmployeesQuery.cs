using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Employee;
using Task.Application.Interfaces;

namespace Task.Application.Features.Queries.Employee
{
    public class GetEmployeesQuery : IRequest<ResponseVM<List<EmployeeModel>>>
    {
    }
    public class GetEmployeesQueryHandler: IRequestHandler<GetEmployeesQuery, ResponseVM<List<EmployeeModel>>>
    {
        private readonly IEmployeeService _EmployeeService;
        public GetEmployeesQueryHandler(IEmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;
        }

        public async Task<ResponseVM<List<EmployeeModel>>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _EmployeeService.GetEmployees();
        }
    }
}
