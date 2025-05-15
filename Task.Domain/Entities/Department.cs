using System.ComponentModel.DataAnnotations;
using Task.Domain.Common;
using Ardalis.SharedKernel;

namespace Task.Domain.Entities
{
    public class Department : BaseAuditableEntity, IAggregateRoot
    {
        [Required]
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }

}
