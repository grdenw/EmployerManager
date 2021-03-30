using EmployeeManager.Core.Models;
using EmployeeManager.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeManager.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await employeeRepository.GetAllEmployeesAsync().ConfigureAwait(false);

            return View(employees);
        }

        public async Task<IActionResult> EditEmployee(int id)
        {
            var employee = await employeeRepository.GetEmployeeAsync(id).ConfigureAwait(false);

            if (employee == null)
            {
                return NotFound();
            }

            return View("EditEmployee", employee);
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View(new Employee());
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await employeeRepository.CreateEmployeeAsync(employee).ConfigureAwait(false);

                return RedirectToAction("Index"); 
            }

            return View("CreateEmployee", employee);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await employeeRepository.UpdateEmployeeAsync(employee).ConfigureAwait(false);

                return RedirectToAction("Index"); 
            }

            return View("EditEmployee", employee);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await employeeRepository.DeleteEmployeeAsync(id).ConfigureAwait(false);

            return RedirectToAction("Index");
        }


    }
}
