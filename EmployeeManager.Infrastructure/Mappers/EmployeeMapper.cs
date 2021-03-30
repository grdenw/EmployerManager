using EmployeeManager.Core.Models;
using EmployeeManager.Infrastructure.Models;

namespace EmployeeManager.Infrastructure.Mappers
{
    public static class EmployeeMapper
    {
        public static Employee Map(EmployeeDb employeeDb)
        {
            return new Employee
            {
                Id = employeeDb.Id,
                Address = employeeDb.Address,
                Position = employeeDb.Position,
                Description = employeeDb.Description,
                Name = employeeDb.Name,
                PhoneNumber = employeeDb.PhoneNumber,
                Surname = employeeDb.Surname
            };
        }

        public static EmployeeDb Map(Employee employee)
        {
            return new EmployeeDb
            {
                Id = employee.Id,
                Address = employee.Address,
                Position = employee.Position,
                Description = employee.Description,
                Name = employee.Name,
                PhoneNumber = employee.PhoneNumber,
                Surname = employee.Surname
            };
        }
    }
}
