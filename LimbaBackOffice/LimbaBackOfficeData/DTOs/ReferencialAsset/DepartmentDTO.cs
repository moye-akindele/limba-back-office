﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LimbaBackOfficeData.DTOs.ReferencialAsset
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool InternalType { get; set; }
    }
}