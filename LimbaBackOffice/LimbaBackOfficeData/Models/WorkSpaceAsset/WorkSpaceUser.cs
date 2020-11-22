using LimbaBackOfficeData.Enums;
using LimbaBackOfficeData.Models.ReferencialAsset;
using System;
using System.Collections.Generic;
using System.Text;

namespace LimbaBackOfficeData.Models
{
    public class WorkSpaceUser
    {
        public int Id { get; set; }
        public int WorkSpaceId { get; set; }
        public AccessLevel AccessLevel { get; set; }
        public string Position { get; set; }
        public AppUser MappedUser { get; set; }
        public Department Department { get; set; }
    }
}
