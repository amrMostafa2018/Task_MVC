using Task.Application.Common.Response;
using Task.Application.Features.ViewModels;

namespace Task.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<ResponseVM> AddEmployee(EmployeeRequestModel employeeRequest);
    }
}
