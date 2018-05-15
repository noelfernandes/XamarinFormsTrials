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
        private static HttpClient instance;
        private static HttpClient HttpClientInstance => instance ?? (instance = new HttpClient(new NativeMessageHandler() { EnableUntrustedCertificates = true, DisableCaching = true }));
        //new NativeMessageHandler() { Timeout = new TimeSpan(0, 0, 9), EnableUntrustedCertificates = true, DisableCaching = true }
        public async Task<TResult> GetAsync<TResult>(string uri, string token = "")
        {
            setupHttpClient(token);
            HttpResponseMessage response;
            try
            {
                response = await HttpClientInstance.GetAsync(uri);//.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            await HandleResponse(response);
            string responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(responseData));
        }

        private void setupHttpClient(string token = "")
        {
            HttpClientInstance.DefaultRequestHeaders.Accept.Clear();
            HttpClientInstance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrWhiteSpace(token))
            {
                HttpClientInstance.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);
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
