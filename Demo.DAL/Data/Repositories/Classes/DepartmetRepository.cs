using Demo.DAL.Data.Repositories.Interfaces;
using Demo.DAL.Models.DepartmentModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositories.Classes
{
    public class DepartmetRepository(AppDbContext dbContext) : GenaricRepository<Department>(dbContext), IDepartmentRepository
    {
        
    }
}
