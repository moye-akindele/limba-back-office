using System.Collections.Generic;

namespace LimbaBackOfficeData.Models
{
    public class WorkSpace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatorId { get; set; }
        public int OwnerId { get; set; }
        public bool IsActive { get; set; }
    }
}
