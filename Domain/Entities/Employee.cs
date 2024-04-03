using System.ComponentModel.DataAnnotations;

/*
 * I've used both method in this demo (Fluent API and Data Annotation).
 * This is Data annotation configuration to configure the Entity,
 * As you can see in single line comment on Phone number property,
 * It has StringLength class in attribute form, that described the length is 10,
 * The Fluent API configuration, you'll find it in Persistence/Configuration Folder.
 */

namespace Domain.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        // ======Data Annotation configuration=====
        [StringLength(10)]
        public string? PhoneNumber { get; set; }

        public int Age { get; set; }
        public string? Address { get; set; }
        public decimal Salary { get; set; }
        public Department Department { get; set; } = null!;
    }
}
