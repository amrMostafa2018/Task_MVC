using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Department;
using Task.Application.Interfaces;

namespace Task.Application.Features.Queries.Employee
{
    public class GetDepartmentSummaryByIdQuery : IRequest<ResponseVM<DepartmentSummaryModel>>
    {
        public int Id { get; set; }
    }
    public class GetDepartmentSummaryByIdQueryHandler : IRequestHandler<GetDepartmentSummaryByIdQuery, ResponseVM<DepartmentSummaryModel>>
    {
        private readonly IDepartmentService _DepartmentService;
        public GetDepartmentSummaryByIdQueryHandler(IDepartmentService DepartmentService)
        {
            _DepartmentService = DepartmentService;
        }

        public async Task<ResponseVM<DepartmentSummaryModel>> Handle(GetDepartmentSummaryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _DepartmentService.GetDepartmentSummaryById(request.Id);
        }
    }
}
