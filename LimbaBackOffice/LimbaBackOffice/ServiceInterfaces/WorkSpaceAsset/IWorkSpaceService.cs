using LimbaBackOfficeData.DTOs;
using LimbaBackOfficeData.Models;
using System.Collections.Generic;

namespace LimbaBackOffice.ServiceInterfaces
{
    public interface IWorkSpaceService
    {
        List<WorkSpaceDTO> Get();
        List<WorkSpaceDTO> GetUserWorkSpaces(int appUserId);
        List<WorkSpaceUserDTO> GetWorkSpaceUsers(int workSpaceId);
        WorkSpaceDTO Get(int id);
        bool Create(WorkSpaceModel seat);
        bool Update(WorkSpaceModel seat);
        bool Delete(int id);
    }
}
