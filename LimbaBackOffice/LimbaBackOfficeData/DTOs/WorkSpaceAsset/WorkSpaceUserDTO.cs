using LimbaBackOfficeData.DTOs.ReferencialAsset;
using LimbaBackOfficeData.Enums;
using LimbaBackOfficeData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LimbaBackOfficeData.DTOs
{
    public class WorkSpaceUserDTO
    {
        public int Id { get; set; }
        public AppUserDTO MappedUser { get; set; }
        public int WorkSpaceId { get; set; }
        public string Position { get; set; }
        public AccessLevel AccessLevel { get; set; }
        public DepartmentDTO Department { get; set; }
    }
}
