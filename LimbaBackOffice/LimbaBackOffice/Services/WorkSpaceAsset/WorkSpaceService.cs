using LimbaBackOffice.ServiceInterfaces;
using LimbaBackOfficeData.DTOs;
using LimbaBackOfficeData.DTOs.ReferencialAsset;
using LimbaBackOfficeData.Models;
using LimbaBackOfficeData.RepositoryInterfaces;
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
                                    IsActive = workSpace.IsActive
                                };

            return workSpaceList.ToList();
        }

        public List<WorkSpaceUserDTO> GetWorkSpaceUsers(int workSpaceId)
        {
            var workSpaceUsers = _respository.GetWorkSpaceUsers(workSpaceId);

            var workSpaceUsersList = from workSpaceUser in workSpaceUsers
                                select new WorkSpaceUserDTO()
                                {
                                    MappedUser = new AppUserDTO()
                                    {
                                        Id = workSpaceUser.MappedUser.Id,
                                        Email = workSpaceUser.MappedUser.Email,
                                        Password = workSpaceUser.MappedUser.Password,
                                        FirstName = workSpaceUser.MappedUser.FirstName,
                                        LastName = workSpaceUser.MappedUser.LastName,
                                        IsActive = workSpaceUser.MappedUser.IsActive,
                                    },
                                    Id = workSpaceUser.Id,
                                    WorkSpaceId = workSpaceUser.WorkSpaceId,
                                    AccessLevel = workSpaceUser.AccessLevel,
                                    Position = workSpaceUser.Position,
                                    Department = new DepartmentDTO()
                                    {
                                        Id = workSpaceUser.Department.Id,
                                        Name = workSpaceUser.Department.Name,
                                        Description = workSpaceUser.Department.Description,
                                        InternalType = workSpaceUser.Department.InternalType,
                                    },
                                };

            return workSpaceUsersList.ToList();
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
                IsActive = workSpace.IsActive
            };

            return appUserDTO;
        }

        public bool Create(WorkSpaceModel seat)
        {
            return _respository.Create(seat);
        }

        public bool Update(WorkSpaceModel seat)
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
