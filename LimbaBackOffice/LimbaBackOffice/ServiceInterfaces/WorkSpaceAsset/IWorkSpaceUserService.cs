using LimbaBackOfficeData.DTOs;
using LimbaBackOfficeData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimbaBackOffice.ServiceInterfaces.WorkSpace
{
    public interface IWorkSpaceUserService
    {
        List<WorkSpaceUserDTO> Get(int workSpaceId);
        WorkSpaceUserDTO Get(int workSpaceId, int userId);
        bool Create(WorkSpaceUser spaceUser);
        bool Update(WorkSpaceUser seat);
        bool Delete(int id);
    }
}
