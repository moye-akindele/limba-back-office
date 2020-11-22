using System;
using System.Collections.Generic;
using System.Text;

namespace LimbaBackOfficeData.Models.ReferencialAsset
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool InternalType { get; set; }
    }
}
