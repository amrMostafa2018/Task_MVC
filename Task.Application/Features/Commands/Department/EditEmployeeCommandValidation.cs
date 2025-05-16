using Task.Application.Common.Response;
using Task.Application.Features.ViewModels;

namespace Task.Application.Features.Commands.Employee
{
    public class EditDepartmentCommandValidation : AbstractValidator<EditDepartmentCommand>
    {
        public EditDepartmentCommandValidation()
        {
            RuleFor(x => x.departmentRequest.Name).NotNull().NotEmpty()
                       .WithMessage("Name Is Required");

        }
    }

}
