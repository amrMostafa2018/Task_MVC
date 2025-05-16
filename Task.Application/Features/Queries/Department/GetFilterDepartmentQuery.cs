using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Department;
using Task.Application.Features.ViewModels.Employee;
using Task.Application.Interfaces;

namespace Task.Application.Features.Queries.Employee
{
    public class GetFilterDepartmentQuery : IRequest<ResponseVM<List<DepartmentModel>>>
    {
        public string search { get; set; }
    }
    public class GetFilterDepartmentQueryHandler : IRequestHandler<GetFilterDepartmentQuery, ResponseVM<List<DepartmentModel>>>
    {
        private readonly IDepartmentService _DepartmentService;
        public GetFilterDepartmentQueryHandler(IDepartmentService DepartmentService)
        {
            _DepartmentService = DepartmentService;
        }

        public async Task<ResponseVM<List<DepartmentModel>>> Handle(GetFilterDepartmentQuery request, CancellationToken cancellationToken)
        {
            return await _DepartmentService.GetFilterDepartment(request.search);
        }
    }
}
