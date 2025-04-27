using Demo.BLL.DTO;
using Demo.BLL.Factories;
using Demo.DAL.Data.Repositories.Classes;
using Demo.DAL.Data.Repositories.Interfaces;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services
{
    public class DepartmentService(IDepartmentRepository _departmetRepository) : IDepartmentService
    {
        //private readonly IDepartmentRepository _departmetRepository = departmetRepository;

        //GETALL
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var deprtements = _departmetRepository.GetALL();
            //var departmentToReturn = deprtements.Select(D => new DepartmentDto()
            //{
            //    Id=D.Id,
            //    Name=D.Name,
            //    Description=D.Description,
            //    Code=D.Code,
            //    DateOfCeration=DateOnly.FromDateTime(D.CreatedOn.Value)
            //});
            //return departmentToReturn;
            return deprtements.Select(D => D.ToDepartmentDto());
        }
        public DepartmentDetailDto? GetDepartmentById(int id)
        {

            var deprtement = _departmetRepository.GetById(id);
            //if (deprtement is null) return null;

            //else { 
            //var departmentToReturn =  new DepartmentDetailDto(deprtement)
            //{
            //    //Id = deprtement.Id,
            //    //Name = deprtement.Name,
            //    //Description = deprtement.Description,
            //    //Code = deprtement.Code,
            //    //CreatedOn = DateOnly.FromDateTime(deprtement.CreatedOn.Value)
            //};
            //return departmentToReturn;
            return deprtement is null ? null : deprtement.ToDepartmentDetailDto();
        }

        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();
            return _departmetRepository.Add(department);
        }
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            var department = departmentDto.ToEntity();
            return _departmetRepository.Update(department);
        }
        public bool DeleteDepartment(int id)
        {
            var department = _departmetRepository.GetById(id);
            if (department is null) return false;
            else
            {
                int result = _departmetRepository.Delete(department);
                return result > 0 ? true : false;
            }

        }
    }

}
   
