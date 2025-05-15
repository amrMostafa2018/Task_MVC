using Task.Application.Common.Response;
using Task.Application.Features.ViewModels;

namespace Task.Application.Features.Commands
{
    public class AddEmployeeCommandValidation : AbstractValidator<AddEmployeeCommand>
    {
        public AddEmployeeCommandValidation()
        {
            RuleFor(x => x.employeeRequest.FirstName).NotNull().NotEmpty()
                       .WithMessage("FirstName Is Required");

            RuleFor(x => x.employeeRequest.LastName).NotNull().NotEmpty()
                      .WithMessage("LastName Is Required");

            RuleFor(x => x.employeeRequest.Salary).NotNull().NotEmpty()
                      .WithMessage("Salary Is Required");

        }
    }
   
}
