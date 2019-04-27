using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Acesoft.Util
{
    public static class HttpHelper
    {
        public const string ContentTypeJson = "application/json";
        public const string ContentTypeForm = "application/x-www-form-urlencoded";
        public const string ContentTypeFile = "multipart/form-data";

        #region get
        public static async Task<T> GetJsonAsync<T>(this HttpClient client, string url, Dictionary<string, string> headers = null, int timeout = 0)
        {
            var json = await GetAsync(client, url, headers, timeout).ConfigureAwait(false);
            return SerializeHelper.FromJson<T>(json);
        }

        public static T GetJson<T>(this HttpClient client, string url, Dictionary<string, string> headers = null, int timeout = 0)
        {
            var json = Get(client, url, headers, timeout);
            return SerializeHelper.FromJson<T>(json);
        }

        public static async Task<string> GetAsync(this HttpClient client, string url, Dictionary<string, string> headers = null, int timeout = 0)
        {
            SetHttpClient(client, headers, timeout);
            using (var response = await client.GetAsync(url).ConfigureAwait(false))
            {
                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
        }
        public static string Get(this HttpClient client, string url, Dictionary<string, string> headers = null, int timeout = 0)
        {
            SetHttpClient(client, headers, timeout);
            using (var response = client.GetAsync(url).ConfigureAwait(false).GetAwaiter().GetResult())
            {
                return response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            }
        }
        #endregion

        #region post
        public static Task<string> PostStringAsync<T>(this HttpClient client, string url, T postData, Dictionary<string, string> headers = null, string contentType = null, int timeout = 0)
        {
            var json = SerializeHelper.ToJson(postData);
            return PostStringAsync(client, url, json, headers, contentType, timeout);
        }

        public static async Task<string> PostStringAsync(this HttpClient client, string url, string postData, Dictionary<string, string> headers = null, string contentType = "application/x-www-form-urlencoded", int timeout = 0)
        {
            SetHttpClient(client, headers, timeout);

            using (var content = new StringContent(postData))
            {
                if (contentType != null)
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                }
                using (var response = await client.PostAsync(url, content))
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }
        #endregion

        #region download
        public static async Task DownloadAsync(this HttpClient client, string url, string saveFile, Dictionary<string, string> headers = null)
        {
            var bytes = await DownloadAsync(client, url, headers);
            FileHelper.Write(saveFile, bytes);
        }

        public static async Task DownloadAsync(this HttpClient client, string url, Stream stream, Dictionary<string, string> headers = null)
        {
            SetHttpClient(client, headers);
            var data = await client.GetByteArrayAsync(url);
            stream.Write(data, 0, data.Length);
        }

        public static Task<byte[]> DownloadAsync(this HttpClient client, string url, Dictionary<string, string> headers = null)
        {
            SetHttpClient(client, headers);
            return client.GetByteArrayAsync(url);
        }
        #endregion

        #region upload
        public static async Task<string> UploadAsync(this HttpClient client, string url, byte[] fileBytes, string fileName, string postName = "file", Dictionary<string, string> headers = null, string contentType = null, int timeout = 0)
        {
            SetHttpClient(client, headers, timeout);

            var boundary = "----" + DateTime.Now.Ticks.ToString("x");
            using (var content = new MultipartFormDataContent(boundary))
            {
                var fileContent = new ByteArrayContent(fileBytes);
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = $"\"{postName}\"",
                    FileName = $"\"{fileName}\"",
                    Size = fileBytes.Length
                };
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                content.Add(fileContent);

                // 微信里boundary前后不能带""
                content.Headers.ContentType = MediaTypeHeaderValue.Parse($"multipart/form-data; boundary={boundary}");

                using (var response = await client.PostAsync(url, content))
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }

        public static async Task<string> UploadAsync(this HttpClient client, string url, Stream stream, string fileName, string postName = "file", Dictionary<string, string> headers = null, string contentType = null, int timeout = 0)
        {
            SetHttpClient(client, headers, timeout);
            using (var content = new MultipartFormDataContent())
            {
                var fileContent = new StreamContent(stream);
                if (contentType != null)
                {
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                }
                content.Add(fileContent, postName, fileName);

                using (var response = await client.PostAsync(url, content))
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }

        public static Task<string> UploadFileAsync(this HttpClient client, string url, string file, string postName = "file", Dictionary<string, string> headers = null, string contentType = null, int timeout = 0)
        {
            return UploadAsync(client, url, File.OpenRead(file), Path.GetFileName(file), postName, headers, contentType, timeout);
        }
        #endregion

        #region client
        private static void SetHttpClient(HttpClient client, Dictionary<string, string> headers = null, int timeout = 0)
        {
            client.DefaultRequestHeaders.Clear();

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    if (!client.DefaultRequestHeaders.Contains(header.Key))
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }
            }
            
            if (!client.DefaultRequestHeaders.Contains("Accept"))
            {
                client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            }
            if (!client.DefaultRequestHeaders.Contains("User-Agent"))
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.57 Safari/537.36");
            }

            if (timeout > 0)
            {
                client.Timeout = new TimeSpan(0, 0, timeout);
            }
        }
        #endregion
    }
}
