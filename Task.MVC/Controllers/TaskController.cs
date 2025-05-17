using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task.Application.Features.Commands.Task;
using Task.Application.Features.Queries.Employee;
using Task.Application.Features.ViewModels.Task;

namespace Task.MVC.Controllers
{
    public class TaskController : MVCControllerBase
    {
        public TaskController(IMediator mediator) : base(mediator)
        {
        }

        public IActionResult Index(int id)
        {
            ViewBag.managerId = 1;
            return View();
        }

        public async Task<IActionResult> loadEmployeeTasks(int id)
        {
            var response = await _mediator.Send(new GetEmployeeTasksQuery() { managerId = id});
            return PartialView("_EmployeeTasksList", response.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int managerId)
        {
            ViewBag.managerId = 1;
            var employees = await _mediator.Send(new GetEmployeesByManagerIdQuery() { ManagerId = managerId});
            ViewBag.Employees = new SelectList(employees.Data, "Id", "FullName");
            ViewBag.titlePage = "Assign Task";
            return PartialView("_EmployeeTaskForm", new EmployeeTaskRequestModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeTaskRequestModel employeeTaskRequest)
        {
            if (ModelState.IsValid)
            {
                var data = await _mediator.Send(new AssignTaskToEmployeeCommand() { employeeTaskRequest = employeeTaskRequest });
                return Json(new { success = true });
            }

            return PartialView("_EmployeeTaskForm", employeeTaskRequest);
        }
    }
}
