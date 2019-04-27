using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Acesoft.Components;
using Acesoft.Models;
using Acesoft.Util;

namespace Acesoft
{
    public static class HttpClientExtensions
    {
        public static T Get<T>(this HttpClient client, string api, Dictionary<string, string> headers = null)
        {
            var res = client.GetJson<Response<T>>(api, headers);
            if (res.Error == null)
            {
                return res.Value;
            }

            Toast.ShowShortMsg(res.Error);
            return default(T);
        }

        public static async Task<T> GetAsync<T>(this HttpClient client, string api, Dictionary<string, string> headers = null)
        {
            var res = await client.GetJsonAsync<Response<T>>(api, headers).ConfigureAwait(false);
            if (res.Error == null)
            {
                return res.Value;
            }

            Toast.ShowShortMsg(res.Error);
            return default(T);
        }
    }
}
