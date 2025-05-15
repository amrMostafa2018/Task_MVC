using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Employee;
using Task.Application.Interfaces;

namespace Task.Application.Features.Queries.Employee
{
    public class GetManagersQuery : IRequest<ResponseVM<List<ManagerModel>>>
    {
    }
    public class GetManagersQueryHandler : IRequestHandler<GetManagersQuery, ResponseVM<List<ManagerModel>>>
    {
        private readonly IEmployeeService _EmployeeService;
        public GetManagersQueryHandler(IEmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;
        }

        public async Task<ResponseVM<List<ManagerModel>>> Handle(GetManagersQuery request, CancellationToken cancellationToken)
        {
            return await _EmployeeService.GetManagers();
        }
    }
}
