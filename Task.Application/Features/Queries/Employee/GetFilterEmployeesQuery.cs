using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Employee;
using Task.Application.Interfaces;

namespace Task.Application.Features.Queries.Employee
{
    public class GetFilterEmployeesQuery : IRequest<ResponseVM<List<EmployeeModel>>>
    {
        public string search { get; set; }
    }
    public class GetFilterEmployeesQueryHandler : IRequestHandler<GetFilterEmployeesQuery, ResponseVM<List<EmployeeModel>>>
    {
        private readonly IEmployeeService _EmployeeService;
        public GetFilterEmployeesQueryHandler(IEmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;
        }

        public async Task<ResponseVM<List<EmployeeModel>>> Handle(GetFilterEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _EmployeeService.GetFilterEmployees(request.search);
        }
    }
}
