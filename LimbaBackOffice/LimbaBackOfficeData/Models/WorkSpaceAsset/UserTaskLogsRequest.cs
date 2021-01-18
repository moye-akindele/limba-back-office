using System;
using System.Collections.Generic;
using System.Text;

namespace LimbaBackOfficeData.Models.WorkSpaceAsset
{
    public class UserTaskLogsRequest
    {
        public int WorkSpaceUserId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
