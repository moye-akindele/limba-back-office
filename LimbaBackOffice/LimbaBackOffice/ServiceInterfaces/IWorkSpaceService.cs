using LimbaBackOfficeData.DTOs;
using LimbaBackOfficeData.Models;
using System.Collections.Generic;

namespace LimbaBackOffice.ServiceInterfaces
{
    public interface IWorkSpaceService
    {
        List<WorkSpaceDTO> Get();
        WorkSpaceDTO Get(int id);
        bool Create(WorkSpace seat);
        bool Update(WorkSpace seat);
        bool Delete(int id);
    }
}
