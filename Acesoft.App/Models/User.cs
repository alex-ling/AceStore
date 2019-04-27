using System;
using System.Collections.Generic;
using System.Text;

namespace Acesoft.Models
{
    public class User : IUser
    {
        public long Id { get; set; }
        public string Loginname { get; set; }
        public string Nickname { get; set; }
        public string Mobile { get; set; }
        public string Mail { get; set; }
        public string Photo { get; set; }
    }
}
