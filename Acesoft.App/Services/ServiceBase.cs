using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Acesoft.Services
{
    public class ServiceBase
    {
        public HttpClient Client { get; }

        public ServiceBase(string apiUrl)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(apiUrl);
        }
    }
}