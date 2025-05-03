using Demo.BLL.DTO.DepartmentDtos;

using Demo.BLL.Services.Interfaces;
using Demo.PL.Models;
using Microsoft.AspNetCore.Mvc;

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
        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) { return BadRequest(); }
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null) return NotFound();
            var departmentViewModel = new DepartmentEditViewModel()
            {
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DateOfCreation = department.CreatedOn

            };

            return View(departmentViewModel);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, DepartmentEditViewModel viewModel)
        {
            if (ModelState.IsValid) { return View(viewModel); }
            try
            {
                var updatedDepartment = new UpdatedDepartmentDto()
                {
                    Id = id.Value,
                    Code = viewModel.Code,
                    Name = viewModel.Name,

                    Description = viewModel.Description,
                    DateOfCreation = viewModel.DateOfCreation

                };
                int result = _departmentService.UpdateDepartment(updatedDepartment);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Departmentbcan't be created !!");
                }
            }
            catch (Exception ex)
            {

                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);

                }
                else
                {
                    _logger.LogError(ex.Message);
                }
            }
            return View(viewModel);
        }
        #endregion
        #region Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department == null) return NotFound();
            return View(department);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id==0) return BadRequest();
            try
            {
                bool deleted = _departmentService.DeleteDepartment(id);
                if (deleted) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Department is not deleted ");
                    return RedirectToAction(nameof(Delete), new {id});
                }

            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    _logger.LogError(ex.Message);
                    return View("Error");
                }
            }
        
   
   
        }

        #endregion
    }
}
