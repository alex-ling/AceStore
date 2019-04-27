using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Acesoft.Models;

namespace Acesoft
{
    public interface IUserService
    {
        bool Login(string userName, string password);
        bool AutoLogin();
        User GetUser();
    }
}
