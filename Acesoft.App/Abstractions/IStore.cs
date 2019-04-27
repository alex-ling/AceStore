using System;
using System.Collections.Generic;
using System.Text;

namespace Acesoft
{
    public interface IStore
    {
        void SetString(string key, string value);
        string GetString(string key);
        void Delete(string key);
    }
}
