using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Task;

namespace Task.Application.Interfaces
{
    public interface ITaskService
    {
        Task<ResponseVM<List<EmployeeTaskItemModel>>> GetEmployeeTasks(int ManagerId);
        Task<ResponseVM> AssignTaskToEmployee(EmployeeTaskRequestModel employeeTaskRequest);
    }
}
