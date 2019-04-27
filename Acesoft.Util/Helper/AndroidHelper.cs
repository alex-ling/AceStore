using System;
using System.Linq;

namespace Acesoft.Util
{
    public static class AndroidHelper
    {
        public static int GetIdFromName(string name, Type type)
        {
            var value = type.GetFields().FirstOrDefault(p => p.Name == name)?.GetValue(type)
                ?? type.GetProperties().FirstOrDefault(p => p.Name == name)?.GetValue(type);
            if (value is int)
            {
                return (int)value;
            }
            return 0;
        }
    }
}
