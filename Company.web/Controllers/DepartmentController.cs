using Company.Data.Models;
using Company.Reposatory.Interfaces;
using Company.Servies.Interfaces.services.Dto;
using Company.web.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Company.web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _departmentService;

        public DepartmentController(IDepartmentServices departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var departments = _departmentService.GetAll();
            return View(departments); // تأكد أن View تستقبل DepartmentDto
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentDto departmentDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _departmentService.Add(departmentDto);
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("DepartmentError", "Validation errors");
                return View(departmentDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DepartmentError", ex.Message);
                return View(departmentDto);
            }
        }

        public IActionResult Details(int? id, string ViewName = "Details")
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var department = _departmentService.GetById(id.Value);
            if (department == null)
            {
                return RedirectToAction("Index");
            }

            return View(ViewName, department);
        }

        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");
        }

        [HttpPost]
        public IActionResult Edit(int? id, DepartmentDto departmentDto)
        {
            if (!id.HasValue || departmentDto == null || departmentDto.Id != id.Value)
            {
                return RedirectToAction("Index");
            }

            try
            {
                _departmentService.Update(departmentDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DepartmentError", ex.Message);
                return View(departmentDto);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var department = _departmentService.GetById(id.Value);
            if (department == null)
            {
                return RedirectToAction("Index");
            }

            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = _departmentService.GetById(id);
            if (department == null)
            {
                return RedirectToAction("Index");
            }

            _departmentService.Delete(department);
            return RedirectToAction("Index");
        }
    }
}
