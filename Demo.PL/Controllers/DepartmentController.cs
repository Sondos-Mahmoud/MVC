using Demo.BLL.DTO;
using Demo.BLL.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;

namespace Demo.PL.Controllers
{
    public class DepartmentController(IDepartmentService _departmentService ,ILogger<DepartmentController>_logger, IWebHostEnvironment _environment) : Controller
    {
        //private readonly IDepartmentService _departmentService = departmentService;
   
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();

            return View(departments);
        }




        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto departmentDto)
        {
            if (ModelState.IsValid)
            {   
                try
                {
                   int result= _departmentService.AddDepartment(departmentDto);
                    if (result>0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department can't be created");
                        return View(departmentDto);
                    }

                }
                catch (Exception ex)
                {
                    if(_environment.IsDevelopment()) { 
                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(departmentDto);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                        return View(departmentDto);
                    }

                } }
            else
            {
                return View(departmentDto);
            }

        //    return View();
        }
        #endregion



        #region Details of department
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) { return BadRequest(); }
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null) return NotFound();

                return View(department);
        }
        #endregion
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) { return BadRequest(); }
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null) return NotFound();

            return View(department);
        }
        [HttpPost]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) { return BadRequest(); }
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null) return NotFound();

            return View(department);
        }
        public IActionResult Delete()
        {
            return View();
        }

    }
}
