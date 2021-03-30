using EmployeeManager.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Infrastructure.Db
{
    public class DefaultDbContext : DbContext
    {
        public DbSet<EmployeeDb> EmployeeDbs { get; set; }

        public DefaultDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
