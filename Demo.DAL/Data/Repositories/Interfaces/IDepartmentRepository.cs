using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositories.Interfaces
{
   public interface IDepartmentRepository
    {
        IEnumerable<Department> GetALL(bool withTracking=false);
        Department GetById(int id);
        int Update(Department Entity);
        int Delete(Department Entity);
        int Add(Department Entity);

        
    }
}
