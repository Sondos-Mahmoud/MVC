using AutoMapper;
using Demo.BLL.DTO.EmployeeDto;
using Demo.BLL.Services.Interfaces;
using Demo.DAL.Data.Repositories.Interfaces;
using Demo.DAL.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services.Classes
{
    public class EmployeeServices(IEmployeeRepository _employeeRepository, IMapper _mapper) : IEmployeeServices
    {
        public IEnumerable<EmployeeDto> GetAllEmployee(bool withTracking)
        {
            var Employees = _employeeRepository.GetALL(withTracking);
            var returnedEmployees = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(Employees);





            //var returnedEmployees=Employees.Select(emp=>new EmployeeDto(){ 
            //Id=emp.Id,
            //Name=emp.Name,
            //Age=emp.Age,
            //Email= emp.Email,
            //Salary= emp.Salary,
            //IsActive= emp.IsActive,
            //EmployeeType= emp.EmployeeType.ToString(),
            //Gender= emp.Gender.ToString(),


            //});
            return returnedEmployees;
        }

        public EmployeeDetailDto? GetEmployeeById(int id)
        {
            var Employee = _employeeRepository.GetById(id);
            return Employee is null ? null : _mapper.Map<Employee, EmployeeDetailDto>(Employee);
            //if (Employee == null) return null;
            //else
            //{
            //    var returnedEmployees = new EmployeeDetailDto()
            //    {
            //        Id = Employee.Id,
            //        Name = Employee.Name,
            //        Age = Employee.Age,
            //        Email = Employee.Email,
            //        Salary = Employee.Salary,
            //        IsActive = Employee.IsActive,
            //        EmployeeType = Employee.EmployeeType.ToString(),
            //        Gender = Employee.Gender.ToString(),
            //        PhoneNumber=Employee.PhoneNumber,
            //        HiringDate=DateOnly.FromDateTime(Employee.HiringDate),
            //        CreatedBy=1,
            //        LastModifiedBy=1,
            //    };
            //return returnedEmployees;
            //}

        }

        public int CreateEmployee(CreatedEmployeeDto CreatedEmployee)
        {
            var employee = _mapper.Map<CreatedEmployeeDto, Employee>(CreatedEmployee);
            return _employeeRepository.Add(employee);
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null) return false;
            else
            {
                employee.IsDeleted = true;
                return _employeeRepository.Update (employee)> 0 ? true : false;

            }

        }




        public int UpdateEmployee(UpdatedEmployeeDto Employee)
        {
            return _employeeRepository.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(Employee));
        }
    }
}
