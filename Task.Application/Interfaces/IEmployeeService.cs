using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Employee;

namespace Task.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<ResponseVM<List<EmployeeModel>>> GetEmployees();
        Task<ResponseVM<List<ManagerModel>>> GetManagers();
        Task<ResponseVM> AddEmployee(EmployeeRequestModel employeeRequest);
    }
}
