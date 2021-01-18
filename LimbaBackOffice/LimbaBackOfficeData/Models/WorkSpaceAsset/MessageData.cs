using System;
using System.Collections.Generic;
using System.Text;

namespace LimbaBackOfficeData.Models.WorkSpaceAsset
{
    public class MessageData
    {
        public DateTime CreatedOn { get; set; }
        public string MessageBody { get; set; }
        public bool IsUnread { get; set; }
    }
}
