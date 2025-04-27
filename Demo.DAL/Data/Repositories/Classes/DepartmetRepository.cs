using Demo.DAL.Data.Repositories.Interfaces;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositories.Classes
{
    public class DepartmetRepository(AppDbContext dbContext) : IDepartmentRepository
    {
        private readonly AppDbContext _dbContext = dbContext;

        public int Add(Department Entity)
        {
            _dbContext.Departments.Add(Entity);
           return _dbContext.SaveChanges();
        }

        public int Delete(Department Entity)
        {
            _dbContext.Departments.Remove(Entity);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Department> GetALL(bool withTracking=false)
        {
            if (withTracking)
            {
                return _dbContext.Departments.ToList();
            }else
                return _dbContext.Departments.AsNoTracking().ToList();
        }

        public Department GetById(int id)
        {
            return _dbContext.Departments.Find(id);
        }

        public int Update(Department Entity)
        {
         _dbContext.Departments.Update(Entity);
            return _dbContext.SaveChanges();
        }
    }
}
