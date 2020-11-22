using LimbaBackOfficeData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LimbaBackOfficeData.RepositoryInterfaces.WorkSpaceAsset
{
    public interface IWorkSpaceUserRepository
    {
        List<WorkSpaceUser> Get(int workSpaceId);
        WorkSpaceUser Get(int workSpaceId, int userId);
        WorkSpaceUserMap Create(WorkSpaceUser ourWorkSpaceUser);
        WorkSpaceUser Update(WorkSpaceUser ourWorkSpaceUser);
        bool Delete(int workSpaceUserId);
    }
}
