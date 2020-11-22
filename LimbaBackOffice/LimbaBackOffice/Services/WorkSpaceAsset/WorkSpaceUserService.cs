using LimbaBackOffice.ServiceInterfaces;
using LimbaBackOffice.ServiceInterfaces.WorkSpace;
using LimbaBackOfficeData.DTOs;
using LimbaBackOfficeData.DTOs.ReferencialAsset;
using LimbaBackOfficeData.Models;
using LimbaBackOfficeData.RepositoryInterfaces.WorkSpaceAsset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimbaBackOffice.Services.WorkSpaceAsset
{
    public class WorkSpaceUserService : IWorkSpaceUserService
    {
        private readonly IWorkSpaceUserRepository _respository;
        private readonly IAppUserService _userService;
        public WorkSpaceUserService(
            IWorkSpaceUserRepository respository,
            IAppUserService userService
        )
        {
            _respository = respository;
            _userService = userService;
        }

        public List<WorkSpaceUserDTO> Get(int workSpaceId)
        {
            var spaceUsersList = _respository.Get(workSpaceId);

            var selectedSpaceUsersList = from spaceUser in spaceUsersList
                                         select new WorkSpaceUserDTO()
                                         {
                                             MappedUser = new AppUserDTO()
                                             {
                                                 Id = spaceUser.MappedUser.Id,
                                                 Email = spaceUser.MappedUser.Email,
                                                 Password = spaceUser.MappedUser.Password,
                                                 FirstName = spaceUser.MappedUser.FirstName,
                                                 LastName = spaceUser.MappedUser.LastName,
                                                 IsActive = spaceUser.MappedUser.IsActive,
                                             },
                                             Id = spaceUser.Id,
                                             WorkSpaceId = spaceUser.WorkSpaceId,
                                             AccessLevel = spaceUser.AccessLevel,
                                             Position = spaceUser.Position,
                                             Department = new DepartmentDTO()
                                             {
                                                 Id = spaceUser.Department.Id,
                                                 Name = spaceUser.Department.Name,
                                                 Description = spaceUser.Department.Description,
                                                 InternalType = spaceUser.Department.InternalType,
                                             },
                                         };

            return selectedSpaceUsersList.ToList();
        }

        public WorkSpaceUserDTO Get(int id, int userId)
        {
            throw new NotImplementedException();
        }

        public bool Create(WorkSpaceUser spaceUser)
        {
            // Create the AppUser.
            var createdUser = _userService.Create(spaceUser.MappedUser);

            if (createdUser != null)
            {
                // Mapping the created user to the provided work space.
                spaceUser.MappedUser.Id = createdUser.Id;
                var createdMap = _respository.Create(spaceUser);

                if (createdMap != null)
                {
                    return true;
                }
            }

            return false;
        }        

        public bool Update(WorkSpaceUser spaceUser)
        {
            // Update the AppUser.
            var updatedUser = _userService.Update(spaceUser.MappedUser);

            if (updatedUser != null)
            {
                // Mapping the created user to the provided work space.
                spaceUser.MappedUser.Id = updatedUser.Id;
                var createdMap = _respository.Update(spaceUser);

                if (createdMap != null)
                {
                    return true;
                }
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
