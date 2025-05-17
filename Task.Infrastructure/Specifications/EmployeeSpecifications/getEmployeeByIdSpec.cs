using Ardalis.Specification;
using Task.Domain.Entities;
namespace Task.Infrastructure.Specifications.EmployeeSpecifications
{
    public class getEmployeeByIdSpec : Specification<Employee>
    {
        public getEmployeeByIdSpec(int id)
        {
            Query.Where(n => n.Id == id);
        }
    }

}
