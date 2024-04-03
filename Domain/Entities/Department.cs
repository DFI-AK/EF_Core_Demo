using System.ComponentModel.DataAnnotations;

/*
 * I've used both method in this demo (Fluent API and Data Annotation).
 * The Fluent API configuration, you'll find it in Persistence/Configuration Folder.
 */


namespace Domain.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string? DepartmentName { get; set; }
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
