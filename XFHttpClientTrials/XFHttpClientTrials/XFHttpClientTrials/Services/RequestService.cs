using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace XFHttpClientTrials.Services
{
    public class RequestService : IRequestService
    {
        public async Task<TResult> GetAsync<TResult>(string uri, string token = "")
        {
            using (var client = new HttpClient(new NativeMessageHandler() { EnableUntrustedCertificates = true, DisableCaching = true }))
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (!string.IsNullOrWhiteSpace(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);
                }

                HttpResponseMessage response;
                try
                {
                    response = await client.GetAsync(uri);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                await HandleResponse(response);
                string responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(responseData));
            }
        }

        private async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception(content);
                }
                throw new HttpRequestException(content);
            }
        }
    }
}
