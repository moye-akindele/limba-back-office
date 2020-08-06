using LimbaBackOfficeData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LimbaBackOfficeData.RepositoryInterfaces
{
    public interface IWorkSpaceRespository
    {
        List<WorkSpace> Get();
        WorkSpace Get(int workSpaceId);
        bool Create(WorkSpace ourAppUser);
        bool Update(WorkSpace ourAppUser);
        bool Delete(int workSpaceId);
    }
}
