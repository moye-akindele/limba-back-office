using System;
using System.Collections.Generic;
using System.Text;

namespace LimbaBackOfficeShared.Models
{
    public class ResetPasswordModel
    {
        public string recipientAddress { get; set; }
        public string Password { get; set; }
    }
}
