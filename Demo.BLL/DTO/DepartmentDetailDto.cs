using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.DTO
{
   public class DepartmentDetailDto
    {
        //public DepartmentDetailDto(Department department)
        //{
        //    Id = department.Id;
        //    Name = department.Name;
        //    Description = department.Description;
        //    Code = department.Code;
        //    CreatedOn = DateOnly.FromDateTime(department.CreatedOn.Value);

        //}
        public int Id { get; set; }
        public int CreatedBy { get; set; }//userid
        public DateOnly CreatedOn { get; set; }//time of create
        public int LastModifiedBy { get; set; }

        public bool IsDeleted { get; set; }//soft delete
        public string Name { get; set; } =string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
