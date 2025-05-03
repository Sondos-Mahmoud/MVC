using Demo.DAL.Models.EmployeeModel;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositories.Interfaces
{
   public interface IEmployeeRepository:IGenaricRepository<Employee>
    {
         IQueryable<Employee> GetEmployeeByAddress(string address);
    }
}
