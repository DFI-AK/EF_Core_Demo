using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/*
 * This is the Fluent API method, which configure the relation and properties of class as column of table.
 * Line no. 20, describing the one to many relation between two tables, and its delete behavior.
 */

namespace Domain.Persistence.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(75);

            builder.Property(x => x.Salary).HasPrecision(10, 2);

            builder.HasOne(x => x.Department)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
