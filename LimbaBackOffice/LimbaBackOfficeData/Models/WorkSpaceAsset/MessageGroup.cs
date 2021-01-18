using LimbaBackOfficeData.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LimbaBackOfficeData.Models.WorkSpaceAsset
{
    public class MessageGroup
    {
        public int Id { get; set; }
        public IList<WorkSpaceUser> Recipients { get; set; }
        public WorkSpaceUser Sender { get; set; } // Probably null for notifications
        public MessageType Type { get; set; } // Inter workspace Email or System Notification
        public string Subject { get; set; }
        public DateTime StartedOn { get; set; }
        public IList<MessageData> MessageEntries
        { get; set; }
    }
}
