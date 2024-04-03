using ConsoleApp.Models;
using Domain.Entities;
using Domain.Persistence.Data;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateDepartment(".NET Department");

            /*
             * Change the DepartmentId according to available data in the Department
             */
            AddEmployee(new EmployeeModel { Salary = 23456.63M, FirstName = "Ayush", LastName = "Kumar", Age = 24, DepartmentId = 1 });

            //====== Get list of employees
            var employees = GetEmployees(1);
            foreach (var employee in employees)
            {
                Console.WriteLine($"Employee name = {employee.FirstName}\nSalary = {employee.Salary}");
                Console.WriteLine("//======================");
            }
            Console.ReadKey();
        }

        static void CreateDepartment(string name)
        {
            using var context = new Context();
            var department = new Department
            {
                DepartmentName = name
            };
            context.Add(department);
            context.SaveChanges();
            Console.WriteLine($"Department created, Id => {department.Id}");
        }

        static void AddEmployee(EmployeeModel model)
        {
            var context = new Context();
            var employee = new Employee
            {
                Age = model.Age,
                DepartmentId = model.DepartmentId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Salary = model.Salary,
            };
            context.Add(employee);
            context.SaveChanges();
            Console.WriteLine($"Employee added, Id => {employee.Id}");
        }

        static List<EmployeeModel> GetEmployees(int departmentId)
        {
            using var context = new Context();
            var employees = context.Employees
                .Where(x => x.DepartmentId == departmentId)
                .Select(rec => new EmployeeModel
                {
                    Age = rec.Age,
                    DepartmentId = rec.DepartmentId,
                    FirstName = rec.FirstName,
                    LastName = rec.LastName,
                    Salary = rec.Salary,
                }).ToList();
            return employees;
        }
    }
}
