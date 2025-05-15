using Task.Application.Common.Interfaces;
using Task.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Task.Infrastructure.Data
{
    public class TaskDbContext : DbContext, ITaskDbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<TaskAssignment> TaskAssignments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>()
            .HasOne(e => e.Manager)
            .WithMany()
            .HasForeignKey(e => e.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<TaskAssignment>()
                .HasOne(t => t.AssignedTo)
                .WithMany(e => e.Tasks)
                .HasForeignKey(t => t.AssignedToId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaskAssignment>()
                .HasOne(t => t.ManagerCreatedBy)
                .WithMany()
                .HasForeignKey(t => t.ManagerCreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
