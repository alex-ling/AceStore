using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using Acesoft.Util;

namespace Acesoft
{
    public static class IUserStoreExtensions
    {
        public static T Get<T>(this IStore store, string key)
        {
            var json = store.GetString(key);
            if (json.HasValue())
            {
                return SerializeHelper.FromJson<T>(json);
            }
            return default(T);
        }

        public static void Set(this IStore store, string key, object value)
        {
            var json = SerializeHelper.ToJson(value);
            store.SetString(key, json);
        }
    }
}
