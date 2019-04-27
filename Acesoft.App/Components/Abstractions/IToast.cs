using System;
using System.Collections.Generic;
using System.Text;

namespace Acesoft.Components
{
    public interface IToast
    {
        void Long(string message);
        void Short(string message);
    }
}
