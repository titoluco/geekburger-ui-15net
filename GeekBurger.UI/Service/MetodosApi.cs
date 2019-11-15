using GeekBurger.UI.Polly;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using Polly.Registry;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GeekBurger.UI.Service
{
    public class MetodosApi : IMetodosApi
    {
        private HttpClient client = new HttpClient();
        private readonly IReadOnlyPolicyRegistry<string> _policyRegistry;
        private readonly ILogger _logger;

        public MetodosApi(ILogger<MetodosApi> logger, IReadOnlyPolicyRegistry<string> policyRegistry)
        {
            _logger = logger;
            _policyRegistry = policyRegistry;
        }

        public T retornoGet<T>(string url)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                HttpResponseMessage result = client.SendAsync(request).Result;
                var retorno = result.Content.ReadAsStringAsync().Result;

                if (result.StatusCode != System.Net.HttpStatusCode.OK && result.StatusCode != System.Net.HttpStatusCode.NoContent)
                {
                    throw new Exception(retorno);
                }

                return JsonConvert.DeserializeObject<T>(retorno);


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return default(T);
            }

        }

        //POST SEM POLLY
        public async Task EnvioPost(string url, string json)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"{url}");
            if (!string.IsNullOrWhiteSpace(json))
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                request.Content = content;
            }

            HttpResponseMessage result = client.SendAsync(request).Result;
            var retorno = result.Content.ReadAsStringAsync().Result;

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(retorno);
            }
        }

        //POST COM POLLY
        public async Task<HttpResponseMessage> PostToApi(string url, dynamic data)
        {
            var client = new HttpClient();
            var byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));

            var content = new ByteArrayContent(byteData);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var retryPolicy = _policyRegistry.Get<IAsyncPolicy<HttpResponseMessage>>(PolicyNames.BasicRetry)
                              ?? Policy.NoOpAsync<HttpResponseMessage>();

            var context = new Context($"GetSomeData-{Guid.NewGuid()}", new Dictionary<string, object>
                {
                    { PolicyContextItems.Logger, _logger }, { "url", url }
                });

            var retries = 0;
            // ReSharper disable once AccessToDisposedClosure
            var response = await retryPolicy.ExecuteAsync((ctx) =>
            {
                client.DefaultRequestHeaders.Remove("retries");
                client.DefaultRequestHeaders.Add("retries", new[] { retries++.ToString() });

                return client.PostAsync(url, content);
            }, context);

            content.Dispose();

            return response;

        }
    }
}