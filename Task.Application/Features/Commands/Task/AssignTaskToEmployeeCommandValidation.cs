using Task.Application.Features.Commands.Task;

namespace Task.Application.Features.Commands.Task
{
    public class AssignTaskToEmployeeCommandValidation : AbstractValidator<AssignTaskToEmployeeCommand>
    {
        public AssignTaskToEmployeeCommandValidation()
        {
            RuleFor(x => x.employeeTaskRequest.Title).NotNull().NotEmpty()
                       .WithMessage("Title Is Required");

            RuleFor(x => x.employeeTaskRequest.Description).NotNull().NotEmpty()
                       .WithMessage("Description Is Required");

            RuleFor(x => x.employeeTaskRequest.AssignedToId).NotNull().NotEmpty()
                       .WithMessage("Employee AssignedTo Is Required");

            RuleFor(x => x.employeeTaskRequest.ManagerCreatedById).NotNull().NotEmpty()
                       .WithMessage("Manager Created Is Required");

        }
    }

}
