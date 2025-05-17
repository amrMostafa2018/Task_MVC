using Ardalis.Specification;
using Task.Domain.Entities;
namespace Task.Infrastructure.Specifications.EmployeeSpecifications
{
    public class getEmployeesByManagerIdSpec : Specification<Employee>
    {
        public getEmployeesByManagerIdSpec(int managerId)
        {
            Query.Where(n => n.ManagerId == managerId);
        }
    }

}
