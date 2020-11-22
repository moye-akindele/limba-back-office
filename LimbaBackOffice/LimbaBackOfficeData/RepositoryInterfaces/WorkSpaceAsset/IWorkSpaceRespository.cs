using LimbaBackOfficeData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LimbaBackOfficeData.RepositoryInterfaces
{
    public interface IWorkSpaceRespository
    {
        List<WorkSpaceModel> Get();
        List<WorkSpaceModel> GetUserWorkSpaces(int appUserId);
        List<WorkSpaceUser> GetWorkSpaceUsers(int workSpaceId);
        WorkSpaceModel Get(int workSpaceId);
        bool Create(WorkSpaceModel ourAppUser);
        bool Update(WorkSpaceModel ourAppUser);
        bool Delete(int workSpaceId);
    }
}
