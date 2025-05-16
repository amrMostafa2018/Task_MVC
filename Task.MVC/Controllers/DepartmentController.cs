using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task.Application.Features.Commands.Employee;
using Task.Application.Features.Queries.Department;
using Task.Application.Features.Queries.Employee;
using Task.Application.Features.ViewModels.Department;

namespace Task.MVC.Controllers
{
    public class DepartmentController : MVCControllerBase
    {
        public DepartmentController(IMediator mediator) : base(mediator)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LoadDepartments()
        {
            var response = await _mediator.Send(new GetDepartmentsQuery());
            return PartialView("_DepartmentList", response.Data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.titlePage = "Add Department";
            return PartialView("_DepartmentForm", new DepartmentModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentModel departmentModelRequest)
        {
            if (ModelState.IsValid)
            {
                var data = await _mediator.Send(new AddDepartmentCommand { departmentModel = departmentModelRequest });
                return Json(new { success = true });
            }
            return PartialView("_DepartmentForm", departmentModelRequest);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.titlePage = "Edit Department";
            var dep = await _mediator.Send(new GetDepartmentByIdQuery() { Id = id });
            return PartialView("_DepartmentForm", dep.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentModel department)
        {
            if (ModelState.IsValid)
            {
                var data = await _mediator.Send(new EditDepartmentCommand { departmentRequest = department });
                return Json(new { success = true });
            }
            return PartialView("_DepartmentForm", department);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _mediator.Send(new DeleteDepartmentCommand { Id =  id });
            return Json(data);
        }

        public async Task<IActionResult> Search(string searchText)
        {
            var response = await _mediator.Send(new GetFilterEmployeesQuery() { search = searchText });
            return PartialView("_EmployeeList", response.Data);
        }
    }
}
