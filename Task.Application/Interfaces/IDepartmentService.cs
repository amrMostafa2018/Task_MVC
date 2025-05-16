using Task.Application.Common.Response;
using Task.Application.Features.ViewModels.Department;

namespace Task.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<ResponseVM<List<DepartmentModel>>> GetDepartments();
        Task<ResponseVM<DepartmentModel>> GetDepartmentById(int Id);
        Task<ResponseVM<DepartmentSummaryModel>> GetDepartmentSummaryById(int Id);
        Task<ResponseVM<List<DepartmentModel>>> GetFilterDepartment(string search);
        Task<ResponseVM> AddDepartment(DepartmentModel departmentModel);
        Task<ResponseVM> EditDepartment(DepartmentModel DepartmentModel);
        Task<bool> DeleteDepartment(int Id);
    }
}
