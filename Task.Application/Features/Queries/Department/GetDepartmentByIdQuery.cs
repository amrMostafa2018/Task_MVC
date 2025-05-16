using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Department;
using Task.Application.Interfaces;

namespace Task.Application.Features.Queries.Employee
{
    public class GetDepartmentByIdQuery : IRequest<ResponseVM<DepartmentModel>>
    {
        public int Id { get; set; }
    }
    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, ResponseVM<DepartmentModel>>
    {
        private readonly IDepartmentService _DepartmentService;
        public GetDepartmentByIdQueryHandler(IDepartmentService DepartmentService)
        {
            _DepartmentService = DepartmentService;
        }

        public async Task<ResponseVM<DepartmentModel>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _DepartmentService.GetDepartmentById(request.Id);
        }
    }
}
