using LimbaBackOfficeData.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LimbaBackOfficeData.Models.WorkSpaceAsset
{
    public class TaskLog
    {
        public int Id { get; set; }
        public int WorkSpaceUserId { get; set; }
        public string Name { get; set; }
        public TaskType Category { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Note { get; set; }
        public TaskStatus Status { get; set; }
    }
}
