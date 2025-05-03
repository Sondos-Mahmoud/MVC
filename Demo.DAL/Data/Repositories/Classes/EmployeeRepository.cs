using Demo.DAL.Data.Repositories.Interfaces;
using Demo.DAL.Models; // ✅ افترضيًا أن Employee موجود في Models
using Demo.DAL.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositories.Classes
{
    public class EmployeeRepository(AppDbContext dbContext) : GenaricRepository<Employee>(dbContext), IEmployeeRepository
    {
        
        public IQueryable<Employee> GetEmployeeByAddress(string address)
        {
            throw new NotImplementedException();
        }

        
    }
}
