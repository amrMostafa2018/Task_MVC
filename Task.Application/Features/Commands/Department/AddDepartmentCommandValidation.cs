using Task.Application.Common.Response;
using Task.Application.Features.ViewModels;

namespace Task.Application.Features.Commands.Employee
{
    public class AddDepartmentCommandValidation : AbstractValidator<AddDepartmentCommand>
    {
        public AddDepartmentCommandValidation()
        {
            RuleFor(x => x.departmentModel.Name).NotNull().NotEmpty()
                       .WithMessage("Name Is Required");
        }
    }

}
