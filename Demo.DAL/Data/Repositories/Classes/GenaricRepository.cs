using Demo.DAL.Data.Repositories.Interfaces;
using Demo.DAL.Models;
using Demo.DAL.Models.DepartmentModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositories.Classes
{
    public class GenaricRepository<TEntity>(AppDbContext _dbContext) : IGenaricRepository<TEntity> where TEntity : BaseEntity
    {
        public int Add(TEntity Entity)
        {
            _dbContext.Set<TEntity>().Add(Entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(TEntity Entity)
        {
            _dbContext.Set<TEntity>().Remove(Entity);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetALL(bool withTracking = false)
        {
            if (withTracking)
            {
                return _dbContext.Set<TEntity>().ToList();
            }
            else
                return _dbContext.Set<TEntity>().AsNoTracking().ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public int Update(TEntity Entity)
        {
            _dbContext.Set<TEntity>().Update(Entity);
            return _dbContext.SaveChanges();
        }
    }
}
