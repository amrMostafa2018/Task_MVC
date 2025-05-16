using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Department;
using Task.Application.Interfaces;

namespace Task.Application.Features.Commands.Employee
{
    public class EditDepartmentCommand : IRequest<ResponseVM>
    {
        public DepartmentModel departmentRequest { get; set; }
    }
    public class EditDepartmentCommandHandler : IRequestHandler<EditDepartmentCommand, ResponseVM>
    {
        private readonly IDepartmentService _DepartmentService;
        public EditDepartmentCommandHandler(IDepartmentService DepartmentService)
        {
            _DepartmentService = DepartmentService;
        }
        public async Task<ResponseVM> Handle(EditDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await _DepartmentService.EditDepartment(request.departmentRequest);
        }
    }
}
