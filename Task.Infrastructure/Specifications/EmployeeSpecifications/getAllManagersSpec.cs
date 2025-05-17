using Ardalis.Specification;
using Task.Domain.Entities;
namespace Task.Infrastructure.Specifications.EmployeeSpecifications
{
    public class getAllManagersSpec : Specification<Employee>
    {
        public getAllManagersSpec()
        {
            Query
                .Where(n => n.ManagerId == null);
        }
    }

}
