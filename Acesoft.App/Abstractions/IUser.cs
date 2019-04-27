using System;
using System.Collections.Generic;
using System.Text;

namespace Acesoft
{
    public interface IUser
    {
        long Id { get; set; }
        string Loginname { get; set; }
        string Nickname { get; set; }
        string Mobile { get; set; }
        string Mail { get; set; }
        string Photo { get; set; }
    }
}
