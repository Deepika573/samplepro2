using Microsoft.EntityFrameworkCore;
using samplepro2.Entity;

namespace samplepro2.Data
{
    public class samplepro2DbContext : DbContext
    {
        public samplepro2DbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
