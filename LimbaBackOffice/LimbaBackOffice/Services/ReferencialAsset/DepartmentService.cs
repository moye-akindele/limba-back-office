using LimbaBackOffice.ServiceInterfaces.ReferencialAsset;
using LimbaBackOfficeData.DTOs.ReferencialAsset;
using LimbaBackOfficeData.Models.ReferencialAsset;
using LimbaBackOfficeData.RepositoryInterfaces.ReferencialAsset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimbaBackOffice.Services.ReferencialAsset
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRespository _respository;
        public DepartmentService(IDepartmentRespository respository)
        {
            _respository = respository;
        }

        public List<DepartmentDTO> Get()
        {
            var departments = _respository.Get();

            var departmentList = from department in departments
                              select new DepartmentDTO()
                              {
                                  Id = department.Id,
                                  Name = department.Name,
                                  Description = department.Description,
                                  InternalType = department.InternalType,
                              };

            return departmentList.ToList();
        }

        public DepartmentDTO Get(int id)
        {
            // check if item exists.
            var department = _respository.Get(id);
            if (department == null)
            {
                return null;
            }

            // Convert to DTO
            var departmentDTO = new DepartmentDTO()
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                InternalType = department.InternalType,
            };

            return departmentDTO;
        }

        public bool Create(Department department)
        {
            return _respository.Create(department);
        }

        public bool Update(Department department)
        {
            return _respository.Update(department);
        }

        public bool Delete(int departmentId)
        {
            return _respository.Delete(departmentId);
        }
    }
}
