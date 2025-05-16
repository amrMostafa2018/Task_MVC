using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task.Application.Features.Commands.Employee;
using Task.Application.Features.Queries.Department;
using Task.Application.Features.Queries.Employee;
using Task.Application.Features.ViewModels.Employee;

namespace Task.MVC.Controllers
{
    public class EmployeeController : MVCControllerBase
    {
        public EmployeeController(IMediator mediator) : base(mediator)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LoadEmployees()
        {
            var response = await _mediator.Send(new GetEmployeesQuery());
            return PartialView("_EmployeeList", response.Data);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var departments = await _mediator.Send(new GetDepartmentsQuery());
            ViewBag.Departments = new SelectList(departments.Data, "Id", "DepartmentName");
            var managers = await _mediator.Send(new GetManagersQuery());
            ViewBag.Managers = new SelectList(managers.Data, "Id", "ManagerName");
            ViewBag.titlePage = "Add Employee";
            return PartialView("_EmployeeForm", new EmployeeRequestModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeRequestModel employeeRequestModel)
        {
            if (ModelState.IsValid)
            {
                var data = await _mediator.Send(new AddEmployeeCommand { employeeRequest = employeeRequestModel });
                return Json(new { success = true });
            }

            return PartialView("_EmployeeForm", employeeRequestModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var departments = await _mediator.Send(new GetDepartmentsQuery());
            ViewBag.Departments = new SelectList(departments.Data, "Id", "DepartmentName");
            var managers = await _mediator.Send(new GetManagersQuery());
            ViewBag.Managers = new SelectList(managers.Data, "Id", "ManagerName");
            ViewBag.titlePage = "Edit Employee";
            var emp = await _mediator.Send(new GetEmployeeByIdQuery() { Id = id });
            return PartialView("_EmployeeForm", emp.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeRequestModel emp)
        {
            if (ModelState.IsValid)
            {
                var data = await _mediator.Send(new EditEmployeeCommand { employeeRequest = emp });
                return Json(new { success = true });
            }

            return PartialView("_EmployeeForm", emp);

            //if (ImageFile != null)
            //{
            //    var path = Path.Combine(_env.WebRootPath, "images", ImageFile.FileName);
            //    using var stream = new FileStream(path, FileMode.Create);
            //    await ImageFile.CopyToAsync(stream);
            //    dbEmp.ImagePath = "/images/" + ImageFile.FileName;
            //}
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _mediator.Send(new DeleteEmployeeCommand { Id =  id });
            return Json(new { success = true });
        }

        public async Task<IActionResult> Search(string searchText)
        {
            var response = await _mediator.Send(new GetFilterEmployeesQuery() { search = searchText });
            return PartialView("_EmployeeList", response.Data);
        }
    }
}
