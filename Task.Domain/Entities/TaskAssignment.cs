using Ardalis.SharedKernel;
using System.ComponentModel.DataAnnotations;
using Task.Domain.Common;
using TaskStatus = Task.Domain.Common.Enums.TaskStatus;

namespace Task.Domain.Entities
{
    public class TaskAssignment : IAggregateRoot
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }

        public int AssignedToId { get; set; }
        public Employee AssignedTo { get; set; }

        public int ManagerCreatedById { get; set; }
        public Employee ManagerCreatedBy { get; set; }
    }
}
