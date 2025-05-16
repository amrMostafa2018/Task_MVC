using Task.Application.Common.Response;
using Task.Application.Interfaces;

namespace Task.Application.Features.Commands.Employee
{
    public class DeleteDepartmentCommand : IRequest<ResponseVM>
    {
        public int Id { get; set; }
    }
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, ResponseVM>
    {
        private readonly IDepartmentService _DepartmentService;
        public DeleteDepartmentCommandHandler(IDepartmentService DepartmentService)
        {
            _DepartmentService = DepartmentService;
        }
        public async Task<ResponseVM> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            bool res = await _DepartmentService.DeleteDepartment(request.Id);
            return new ResponseVM()
            {
                Data = res,
                Error = !res ? "cannot delete department which has employee assigned to it" : null

            };
        }
    }
}
