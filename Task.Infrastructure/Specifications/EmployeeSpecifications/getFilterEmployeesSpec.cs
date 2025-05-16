using Ardalis.Specification;
using Task.Domain.Entities;
namespace Task.Infrastructure.Specifications.CVSpecifications
{
    public class getFilterEmployeesSpec : Specification<Employee>
    {
        public getFilterEmployeesSpec(string search)
        {
            Query
                .Where(e => e.FirstName.Contains(search) || e.LastName.Contains(search)
                     || e.Department.Name.Contains(search) || e.Manager.FirstName.Contains(search)
                     || e.Manager.LastName.Contains(search))
                .Include(n => n.Manager)
                .Include(d => d.Department);
        }
    }

}
