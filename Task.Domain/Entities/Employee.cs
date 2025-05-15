using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ardalis.SharedKernel;
using Task.Domain.Common;

namespace Task.Domain.Entities
{
    public class Employee : BaseAuditableEntity, IAggregateRoot
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        public decimal Salary { get; set; }
        public string? ImagePath { get; set; }

        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public  ICollection<TaskAssignment> Tasks { get; set; }
    }
}


