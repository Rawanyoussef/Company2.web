using Company.Data.Models;
using Company.web.Interfaces;
using Company.web.Interfaces.services;
using Microsoft.AspNetCore.Mvc;

namespace Company.web.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var employees = _employeeService.GetAll(); 
            return View(employees);
        }

       public IActionResult Create()
        {

            return View();

        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeService.Add(employee);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("EmployeeError", "Validation errors occurred.");
                return View(employee);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("EmployeeError", ex.Message);
                return View(employee);
            }
          
        }
        public IActionResult Edit(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee != null)
            {
                _employeeService.Delete(employee);
            }
            return RedirectToAction("Index");
        }




    }
}

