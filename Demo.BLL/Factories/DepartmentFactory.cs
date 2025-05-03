using Demo.BLL.DTO.DepartmentDtos;
using Demo.DAL.Models.DepartmentModel;

namespace Demo.BLL.Factories
{
    static public  class DepartmentFactory
    {
        public static DepartmentDto ToDepartmentDto(this Department D)
        {
            return new DepartmentDto()
            {
                Id = D.Id,
                Name = D.Name,
                Description = D.Description,
                Code = D.Code,
                DateOfCeration = DateOnly.FromDateTime(D.CreatedOn.Value)
            };
        }
        public static DepartmentDetailDto ToDepartmentDetailDto(this Department department)
        {
            return new DepartmentDetailDto()
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                Code = department.Code,
                CreatedOn = DateOnly.FromDateTime(department.CreatedOn.Value),
                LastModifiedBy=department.LastModifiedBy,
                CreatedBy=department.CreatedBy,
            };
             

        }
        public static Department ToEntity(this CreatedDepartmentDto departmentDto)
        {
            return new Department()
            {
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.Description,
                CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }
        public static Department ToEntity(this UpdatedDepartmentDto departmentDto)
        {
            return new Department()
            {
                Id=departmentDto.Id, 
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.Description,
                CreatedOn = departmentDto.DateOfCreation.ToDateTime(new TimeOnly())
            };
        }
    }
}
