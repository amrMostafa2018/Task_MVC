using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Department;
using Task.Application.Features.ViewModels.Employee;

namespace Task.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<ResponseVM<List<DepartmentModel>>> GetDepartments();
        Task<ResponseVM> AddDepartment(EmployeeRequestModel employeeRequest);
    }
}
