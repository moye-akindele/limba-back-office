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
    }
}
