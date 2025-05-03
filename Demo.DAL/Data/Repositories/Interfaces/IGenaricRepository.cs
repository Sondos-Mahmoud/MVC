using Demo.DAL.Models;
using Demo.DAL.Models.DepartmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Repositories.Interfaces
{
   public interface IGenaricRepository<TEntity>where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetALL(bool withTracking = false);
        TEntity GetById(int id);
        int Update(TEntity Entity);
        int Delete(TEntity Entity);
        int Add(TEntity Entity);

    }
}
