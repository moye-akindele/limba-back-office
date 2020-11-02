using LimbaBackOffice.ServiceInterfaces;
using LimbaBackOfficeData.DTOs;
using LimbaBackOfficeData.Models;
using LimbaBackOfficeData.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LimbaBackOffice.Services
{
    public class WorkSpaceService : IWorkSpaceService
    {
        private readonly IWorkSpaceRespository _respository;

        public WorkSpaceService(IWorkSpaceRespository respository)
        {
            _respository = respository;
        }

        public List<WorkSpaceDTO> Get()
        {
            var workSpaces = _respository.Get();

            var workSpaceList = from workSpace in workSpaces
                              select new WorkSpaceDTO()
                              {
                                  Id = workSpace.Id,
                                  Name = workSpace.Name,
                                  Description = workSpace.Description,
                                  CreatorId = workSpace.CreatorId,
                                  OwnerId = workSpace.OwnerId,
                                  IsActive = workSpace.IsActive
                              };

            return workSpaceList.ToList();
        }

        public List<WorkSpaceDTO> GetUserWorkSpaces(int appUserId)
        {
            var workSpaces = _respository.GetUserWorkSpaces(appUserId);

            var workSpaceList = from workSpace in workSpaces
                                select new WorkSpaceDTO()
                                {
                                    Id = workSpace.Id,
                                    Name = workSpace.Name,
                                    Description = workSpace.Description,
                                    CreatorId = workSpace.CreatorId,
                                    OwnerId = workSpace.OwnerId,
                                    IsActive = workSpace.IsActive
                                };

            return workSpaceList.ToList();
        }

        public WorkSpaceDTO Get(int id)
        {
            // check if WorkSpace exists
            var workSpace = _respository.Get(id);
            if (workSpace == null)
            {
                return null;
            }

            // Convert to DTO
            var appUserDTO = new WorkSpaceDTO()
            {
                Id = workSpace.Id,
                Name = workSpace.Name,
                Description = workSpace.Description,
                CreatorId = workSpace.CreatorId,
                OwnerId = workSpace.OwnerId,
                IsActive = workSpace.IsActive
            };

            return appUserDTO;
        }

        public bool Create(WorkSpace seat)
        {
            return _respository.Create(seat);
        }

        public bool Update(WorkSpace seat)
        {
            bool rowsAffected = _respository.Update(seat);

            if (rowsAffected)
            {
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            bool rowsAffected = _respository.Delete(id);

            if (rowsAffected)
            {
                return true;
            }

            return false;
        }
    }
}
