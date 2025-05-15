using System;
using System.Collections.Generic;
using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Department;
using Task.Application.Interfaces;

namespace Task.Application.Features.Queries.Department
{
    public class GetDepartmentsQuery : IRequest<ResponseVM<List<DepartmentModel>>>
    {
    }

    public class GetDepartmentsQueryHandler : IRequestHandler<GetDepartmentsQuery, ResponseVM<List<DepartmentModel>>>
    {
        private readonly IDepartmentService _DepartmentService;
        public GetDepartmentsQueryHandler(IDepartmentService DepartmentService)
        {
            _DepartmentService = DepartmentService;
        }

        public async Task<ResponseVM<List<DepartmentModel>>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
        {
            return await _DepartmentService.GetDepartments();
        }
    }
}
