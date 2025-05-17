using Ardalis.Specification;
using Task.Domain.Entities;
namespace Task.Infrastructure.Specifications.EmployeeSpecifications
{
    public class getAllEmployeesSpec : Specification<Employee>
    {
        public getAllEmployeesSpec()
        {
            Query
                .Include(n => n.Manager)
                .Include(d => d.Department);
        }
    }

}
