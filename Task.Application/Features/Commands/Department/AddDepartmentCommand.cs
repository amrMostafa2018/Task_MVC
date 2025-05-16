using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Department;
using Task.Application.Interfaces;

namespace Task.Application.Features.Commands.Employee
{
    public class AddDepartmentCommand : IRequest<ResponseVM>
    {
        public DepartmentModel departmentModel { get; set; }
    }
    public class AddDepartmentCommandHandler : IRequestHandler<AddDepartmentCommand, ResponseVM>
    {
        private readonly IDepartmentService _DepartmentService;
        public AddDepartmentCommandHandler(IDepartmentService DepartmentService)
        {
            _DepartmentService = DepartmentService;
        }
        public async Task<ResponseVM> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await _DepartmentService.AddDepartment(request.departmentModel);
        }
    }
}
