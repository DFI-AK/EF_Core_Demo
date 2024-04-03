using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/*
 * This is the Fluent API method, which configure the relation and properties of class as column of table.
 */

namespace Domain.Persistence.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.DepartmentName).IsRequired().HasMaxLength(128);
        }
    }
}
