using LimbaBackOfficeData.Models.ReferencialAsset;
using System;
using System.Collections.Generic;
using System.Text;

namespace LimbaBackOfficeData.RepositoryInterfaces.ReferencialAsset
{
    public interface IDepartmentRespository
    {
        List<Department> Get();
        Department Get(int departmentId);
        bool Create(Department ourDepartment);
        bool Update(Department ourDepartment);
        bool Delete(int departmentId);
    }
}
