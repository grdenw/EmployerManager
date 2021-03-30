using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager.Core.Models;
using EmployeeManager.Core.Repositories;
using EmployeeManager.Infrastructure.Db;
using EmployeeManager.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DefaultDbContext defaultDbContext;

        public EmployeeRepository(DefaultDbContext defaultDbContext)
        {
            this.defaultDbContext = defaultDbContext;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            var employeeDb = await defaultDbContext.EmployeeDbs.ToListAsync().ConfigureAwait(false);

            return employeeDb.Select(EmployeeMapper.Map);
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            var employeeDb = await defaultDbContext.EmployeeDbs.FindAsync(id).ConfigureAwait(false);

            return EmployeeMapper.Map(employeeDb);
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            var employeeDb = EmployeeMapper.Map(employee);

            await defaultDbContext.EmployeeDbs.AddAsync(employeeDb).ConfigureAwait(false);

            await defaultDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            var employeeDb = EmployeeMapper.Map(employee);

            defaultDbContext.EmployeeDbs.Update(employeeDb);

            await defaultDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employeeDb = await defaultDbContext.EmployeeDbs.FindAsync(id).ConfigureAwait(false);

            defaultDbContext.EmployeeDbs.Remove(employeeDb);

            await defaultDbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
