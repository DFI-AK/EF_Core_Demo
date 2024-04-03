using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Domain.Persistence.Data
{
    public class Context : DbContext
    {
        /*
         * NOTE : Create constructor on Agile Project Architecture.
         * Don't use constructor which has no scope to use the Dependency Inject.
         * In this case, I'm not using the constructor.
         * After initializing the entities and configurations of DbContext, run the command down below:
         * CMD: => add-migration "InitializeDb" -outputDir "Persistence/Migrations" -v
         * This command will create the migration file inside the Persistence/Migrations folder, you can check your configuration mapping,
         * If your configuration mapping isn't correct, the re-align the Entity in configuration file,
         * Before you execute the command again, execute this command first, because you already created this migration.
         * CMD :=> remove-migration -v
         * This command work as the stack, it'll pop the top one stack, the top migration, then run again the Add-migration command.
         * If your configuration looks good, then execute the final command, which will create your Database and tables.
         * CMD :=> Update-Database -v
         * 
         * You don't need to execute those command, because its already has the Migrations Folder, if you're creating it from scratch,
         * Then you should perform those commands, otherwise, change the connection string in the UseSqlServer("") method to yours DB.
         */
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Department> Departments => Set<Department>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // You can apply the entity configuration from Assembly, you can either use this or below one.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //    //=========
            //    //modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            //    //modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=pc03;Initial Catalog=Company;User ID=test;Trust Server Certificate=True;pwd=test");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
