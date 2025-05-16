using Ardalis.Specification;
using Task.Domain.Entities;
namespace Task.Infrastructure.Specifications.CVSpecifications
{
    public class getFilterDepartmentsSpec : Specification<Department>
    {
        public getFilterDepartmentsSpec(string search)
        {
            Query
            .Include(d => d.Employees)
            .Where(d => string.IsNullOrEmpty(search) || d.Name.Contains(search));
        }
    }

}
