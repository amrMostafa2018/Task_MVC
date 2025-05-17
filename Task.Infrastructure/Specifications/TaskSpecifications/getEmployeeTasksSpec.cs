using Ardalis.Specification;
using Task.Domain.Entities;
namespace Task.Infrastructure.Specifications.TaskSpecifications
{
    public class getEmployeeTasksSpec : Specification<TaskAssignment>
    {
        public getEmployeeTasksSpec(int managerId)
        {
            Query
                .Where(n => n.ManagerCreatedById == managerId)
                .Include(n => n.AssignedTo);
        }
    }

}
