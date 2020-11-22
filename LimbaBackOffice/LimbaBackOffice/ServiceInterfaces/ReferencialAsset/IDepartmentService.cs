using LimbaBackOfficeData.DTOs.ReferencialAsset;
using LimbaBackOfficeData.Models.ReferencialAsset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimbaBackOffice.ServiceInterfaces.ReferencialAsset
{
    public interface IDepartmentService
    {
        List<DepartmentDTO> Get();
        DepartmentDTO Get(int departmentId);
        bool Create(Department ourDepartment);
        bool Update(Department ourDepartment);
        bool Delete(int departmentId);
    }
}
