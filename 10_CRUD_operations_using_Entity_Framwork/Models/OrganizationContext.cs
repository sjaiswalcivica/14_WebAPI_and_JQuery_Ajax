using System;
using Microsoft.EntityFrameworkCore;

namespace _10_CRUD_operations_using_Entity_Framwork.Models
{
    public class OrganizationContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public OrganizationContext(DbContextOptions<OrganizationContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Employee>().ToTable("Employee");
        }

    }
}