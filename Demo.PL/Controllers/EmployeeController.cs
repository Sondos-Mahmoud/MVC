using Demo.BLL.DTO.DepartmentDtos;
using Demo.BLL.DTO.EmployeeDto;
using Demo.BLL.Services.Classes;
using Demo.BLL.Services.Interfaces;
using Demo.DAL.Migrations;
using Demo.DAL.Models.EmployeeModel;
using Demo.PL.Models;
using Demo.PL.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class EmployeeController(IEmployeeServices _employeeServices, ILogger<DepartmentController> _logger, IWebHostEnvironment _environment) : Controller
    {
        public IActionResult Index()
        {
            var Emloyees = _employeeServices.GetAllEmployee();
            return View(Emloyees);
        }
        #region create
        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var CreatedEmployee = new CreatedEmployeeDto()
                    {
                        Name = employeeDto.Name,
                        Address = employeeDto.Address,
                        Age = employeeDto.Age,
                        Email = employeeDto.Email,
                        PhoneNumber = employeeDto.PhoneNumber,
                        IsActive = employeeDto.IsActive,
                        HiringDate = employeeDto.HiringDate,
                        Gender = employeeDto.Gender,
                        EmployeeType = employeeDto.EmployeeType

                    };
                    int result = _employeeServices.CreateEmployee(CreatedEmployee);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department can't be created");
                        return View(employeeDto);
                    }

                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        return View(employeeDto);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                        return View(employeeDto);
                    }

                }
            }
            else
            {
                return View(employeeDto);
            }
        }
        #endregion

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) { return BadRequest(); }
            var employee = _employeeServices.GetEmployeeById(id.Value);
            if (employee is null) return NotFound();

            return View(employee);
        }
        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) { return BadRequest(); }
            var employee = _employeeServices.GetEmployeeById(id.Value);
            if (employee is null) return NotFound();
            var employeeDto = new EmployeeViewModel()
            {
                Name = employee.Name,
                Address = employee.Address,
                Age = employee.Age,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                IsActive = employee.IsActive,
                HiringDate = employee.HiringDate,
                Gender = Enum.Parse<Gender>(employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType)

            };

            return View(employeeDto);
        }
        #endregion
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, EmployeeViewModel viewModel)
        {
            if (!ModelState.IsValid)  return View(viewModel); 


            try
            {
                var UpdatedEmployee = new UpdatedEmployeeDto()
                {
                    Name = viewModel.Name,
                    Address = viewModel.Address,
                    Age = viewModel.Age,
                    Email = viewModel.Email,
                    PhoneNumber = viewModel.PhoneNumber,
                    IsActive = viewModel.IsActive,
                    HiringDate = viewModel.HiringDate,
                    Gender = viewModel.Gender,
                    EmployeeType = viewModel.EmployeeType

                };

               int result = _employeeServices.UpdateEmployee(UpdatedEmployee);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee can't be updated !!");
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

        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (!id.HasValue) return BadRequest();
        //    var employee = _employeeServices.GetEmployeeById(id.Value);
        //    if (employee == null) return NotFound();
        //    return View(employee);
        //}
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool deleted = _employeeServices.DeleteEmployee(id);
                if (deleted) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee is not deleted ");
                    return RedirectToAction(nameof(Delete), new { id });
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
    }
}
