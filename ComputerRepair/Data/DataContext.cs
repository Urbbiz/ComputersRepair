using ComputerRepair.Enteties;
using Microsoft.EntityFrameworkCore;

namespace ComputerRepair.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Computer> Computers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Maitence> Maitences { get; set; }  
    }
}
