using Ardalis.Specification;
using Task.Domain.Entities;
namespace Task.Infrastructure.Specifications.CVSpecifications
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
