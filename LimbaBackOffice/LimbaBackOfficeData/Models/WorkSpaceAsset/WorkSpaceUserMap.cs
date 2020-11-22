using LimbaBackOfficeData.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LimbaBackOfficeData.Models
{
    public class WorkSpaceUserMap
    {
        public int Id { get; set; }
        public int WorkSpaceId { get; set; }
        public int AppUserId { get; set; }
        public string Position { get; set; }
        public int DepartmentId { get; set; }
        public AccessLevel AccessLevel { get; set; }
    }
}
