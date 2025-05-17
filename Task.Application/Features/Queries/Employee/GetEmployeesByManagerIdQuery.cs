using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Employee;
using Task.Application.Interfaces;

namespace Task.Application.Features.Queries.Employee
{
    public class GetEmployeesByManagerIdQuery : IRequest<ResponseVM<List<EmployeesByManagerModel>>>
    {
        public int ManagerId { get; set; }
    }
    public class GetEmployeesByManagerIdQueryHandler : IRequestHandler<GetEmployeesByManagerIdQuery, ResponseVM<List<EmployeesByManagerModel>>>
    {
        private readonly IEmployeeService _EmployeeService;
        public GetEmployeesByManagerIdQueryHandler(IEmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;
        }

        public async Task<ResponseVM<List<EmployeesByManagerModel>>> Handle(GetEmployeesByManagerIdQuery request, CancellationToken cancellationToken)
        {
            return await _EmployeeService.GetEmployeesByManagerId(request.ManagerId);
        }
    }
}
