using Demo.DAL.Data.Configrations;
using Demo.DAL.Models.DepartmentModel;
using Demo.DAL.Models.EmployeeModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data
{
   public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) :base(options)
        {
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=MVC;Trusted_Connection=true; MultpileActiveResultSet=true");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            ;
            modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigrations());
        }
       public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }



    }
}
