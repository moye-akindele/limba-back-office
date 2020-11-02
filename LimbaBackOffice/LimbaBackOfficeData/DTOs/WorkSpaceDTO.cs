using System.Collections.Generic;

namespace LimbaBackOfficeData.DTOs
{
    public class WorkSpaceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatorId { get; set; }
        public int OwnerId { get; set; }
        public bool IsActive { get; set; }
    }
}
