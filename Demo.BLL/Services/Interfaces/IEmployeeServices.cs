using Demo.BLL.DTO.EmployeeDto;
using Demo.DAL.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services.Interfaces
{
 public   interface IEmployeeServices
    {
        IEnumerable<EmployeeDto> GetAllEmployee(bool withTracking=false);
        EmployeeDetailDto? GetEmployeeById(int id);
        int CreateEmployee(CreatedEmployeeDto CreatedEmployee);
        int UpdateEmployee(UpdatedEmployeeDto Employee);
        bool DeleteEmployee(int id);

    }
}
