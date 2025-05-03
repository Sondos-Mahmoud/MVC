using Demo.BLL.DTO.DepartmentDtos;
//using Demo.BLL.DTO.DepartmentDtos.DepartmentDto;

namespace Demo.BLL.Services.Interfaces
{
    public interface IDepartmentService
    {
        int AddDepartment(CreatedDepartmentDto departmentDto);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentDto> GetAllDepartments();
       DepartmentDetailDto? GetDepartmentById(int id);
        int UpdateDepartment(UpdatedDepartmentDto departmentDto);
    }
}