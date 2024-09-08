using Company.Data.Models;
using Company.Servies.Interfaces.services.Dto;
using Company.web.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Company.web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentServices _departmentdtoServices;

        public EmployeeController(IEmployeeService employeeService, IDepartmentServices departmentdtoServices)
        {
            _employeeService = employeeService;
            _departmentdtoServices = departmentdtoServices;
        }

        public IActionResult Index(string searchInp)
        {
            var employees = string.IsNullOrEmpty(searchInp)
                ? _employeeService.GetAll()
                : _employeeService.GetEmployeeDtoByName(searchInp);

            return View(employees);
        }

        public IActionResult Create()
        {
            ViewBag.Department = _departmentdtoServices.GetAll();
            return View();
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Create(EmployeeDto employeeDto, IFormFile image)
        {
            try
            {
                if (ModelState.IsValid)

                {
          
                    if (image != null && image.Length > 0)
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", Path.GetFileName(image.FileName));

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            image.CopyTo(stream);
                        }

                        employeeDto.IMG_URL = filePath;
                    }

                    _employeeService.Add(employeeDto);
                    return RedirectToAction("Index");
                }
                else
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    foreach (var error in errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                    ViewBag.Department = _departmentdtoServices.GetAll();
                    return View(employeeDto);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Department = _departmentdtoServices.GetAll();
                ModelState.AddModelError("EmployeeDtoError", ex.Message);
                return View(employeeDto);
            }
        }


        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var employee = _employeeService.GetById(id.Value);
            if (employee == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Department = _departmentdtoServices.GetAll();
            return View(viewName, employee);
        }

        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");
        }

        [HttpPost]
        public IActionResult Edit(int? id, EmployeeDto employeeDto)
        {
            if (!id.HasValue || employeeDto == null || employeeDto.Id != id.Value)
            {
                return RedirectToAction("Index");
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _employeeService.Update(employeeDto);
                    return RedirectToAction("Index");
                }

                ViewBag.Department = _departmentdtoServices.GetAll();
                ModelState.AddModelError("EmployeeDtoError", "Validation errors occurred.");
                return View(employeeDto);
            }
            catch (Exception ex)
            {
                ViewBag.Department = _departmentdtoServices.GetAll();
                ModelState.AddModelError("EmployeeDtoError", ex.Message);
                return View(employeeDto);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var employee = _employeeService.GetById(id.Value);
            if (employee == null)
            {
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return RedirectToAction("Index");
            }

            _employeeService.Delete(employee);
            return RedirectToAction("Index");
        }
    }
}