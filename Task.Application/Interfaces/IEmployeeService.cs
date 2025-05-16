using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Employee;

namespace Task.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<ResponseVM<List<EmployeeModel>>> GetEmployees();
        Task<ResponseVM<EmployeeModel>> GetEmployeeById(int Id);
        Task<ResponseVM<List<EmployeeModel>>> GetFilterEmployees(string search);
        Task<ResponseVM<List<ManagerModel>>> GetManagers();
        Task<ResponseVM> AddEmployee(EmployeeRequestModel employeeRequest);
        Task<ResponseVM> EditEmployee(EmployeeRequestModel employeeRequest);
        Task<bool> DeleteEmployee(int Id);
    }
}
