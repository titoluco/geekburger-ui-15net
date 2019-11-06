using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GeekBurger.UI.Service
{
    public static class MetodosApi
    {
        static HttpClient client = new HttpClient();

        //static async Task RunAsync()
        //{
        //    // Update port # in the following line.
        //    client.BaseAddress = new Uri("http://localhost:64195/");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/json"));
        //}

        public static T retornoGet<T>(string url)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage result = client.SendAsync(request).Result;
            var retorno = result.Content.ReadAsStringAsync().Result;

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(retorno);
            }

            return JsonConvert.DeserializeObject<T>(retorno);

        }

        public async static Task EnvioPost(string url, string json)
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
    }
}





//using GeekBurger.UI.Configuration;
//using Microsoft.Extensions.Configuration;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Net.Http;
//using System.Text;
//using Polly;
//using Polly.Registry;
//using System.Threading.Tasks;
//using System.Net.Http.Headers;

//namespace GeekBurger.UI.Service
//{
//    public class MetodosApi
//    {

//        private readonly IReadOnlyPolicyRegistry<string> _policyRegistry;

//        public async Task<HttpResponseMessage> PostToApi(dynamic data, string apiUrl)
//        {
//            /*
//            var client = new HttpClient();
//            var byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));

//            var content = new ByteArrayContent(byteData);

//            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

//            var retryPolicy = _policyRegistry.Get<IAsyncPolicy<HttpResponseMessage>>(PolicyNames.BasicRetry)
//                              ?? Policy.NoOpAsync<HttpResponseMessage>();

//            var context = new Context($"GetSomeData-{Guid.NewGuid()}", new Dictionary<string, object>
//                {
//                    { PolicyContextItems.Logger, _logger }, { "url", apiUrl }
//                });

//            var retries = 0;
//            // ReSharper disable once AccessToDisposedClosure
//            var response = await retryPolicy.ExecuteAsync((ctx) =>
//            {
//                client.DefaultRequestHeaders.Remove("retries");
//                client.DefaultRequestHeaders.Add("retries", new[] { retries++.ToString() });

//                var baseUrl = _baseUri;
//                if (string.IsNullOrWhiteSpace(baseUrl))
//                {
//                    //var uri = Request.GetUri();
//                    var uri = new Uri($"{_uIApiConfiguration.BaseUrl}{_uIApiConfiguration.FaceApi}");
//                    baseUrl = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
//                }

//                var isValid = Uri.IsWellFormedUriString(apiUrl, UriKind.Absolute);

//                return client.PostAsync(isValid ? $"{baseUrl}{apiUrl}" : $"{baseUrl}/api/Face", content);
//            }, context);

//            content.Dispose();

//            return response;
//            */
//            return null;
//        }
//        /*
//        private static Dictionary<string, HttpClient> clients = new Dictionary<string, HttpClient>();
//        private static object _lock = new object();
//        private static UiApiConfiguration _uIApiConfiguration;


//        private static HttpClient ObterConexao(string chaveConexao)
//        {
//            var config = new ConfigurationBuilder()
//                     .SetBasePath(Directory.GetCurrentDirectory())
//                     .AddJsonFile("appsettings.json")
//                     .Build();

//            _uIApiConfiguration = config.GetSection("UIApi").Get<UiApiConfiguration>();

//            if (!clients.ContainsKey(chaveConexao))
//            {
//                lock (_lock)
//                {
//                    if (!clients.ContainsKey(chaveConexao))
//                    {
//                        HttpClient client = new HttpClient();
//                        string url = ConfigurationManager.AppSettings[chaveConexao].ToString();
//                        if (!url.EndsWith("/"))
//                        {
//                            url = string.Concat(url, "/");
//                        }
//                        client.BaseAddress = new Uri(url);
//                        clients.Add(chaveConexao, client);
//                    }
//                }
//            }
//            return clients[chaveConexao];
//        }

//        // Pesquisar contratos                    
//        private string chaveConexao { get; set; }
//        private string retorno { get; set; }

//        public MetodosApi(string chaveConexao)
//        {

//            this.chaveConexao = chaveConexao;
//        }

//        public T retornoGet<T>(string url)
//        {
//            HttpClient client = ObterConexao(chaveConexao);

//            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
//            HttpResponseMessage result = client.SendAsync(request).Result;
//            retorno = result.Content.ReadAsStringAsync().Result;

//            if (result.StatusCode != System.Net.HttpStatusCode.OK)
//            {
//                throw new Exception(retorno);
//            }

//            return JsonConvert.DeserializeObject<T>(retorno);

//        }

//        public dynamic retornoGetDinamico(string url)
//        {
//            HttpClient client = ObterConexao(chaveConexao);

//            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
//            HttpResponseMessage result = client.SendAsync(request).Result;
//            retorno = result.Content.ReadAsStringAsync().Result;

//            if (result.StatusCode != System.Net.HttpStatusCode.OK)
//            {
//                throw new Exception(retorno);
//            }

//            return JsonConvert.DeserializeObject(retorno);
//        }

//        public void envioPost(string url)
//        {
//            envioPost(url, null);
//        }
//        public void envioPost(string url, string json)
//        {
//            HttpClient client = ObterConexao(chaveConexao);

//            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"{url}");
//            if (!string.IsNullOrWhiteSpace(json))
//            {
//                var content = new StringContent(json, Encoding.UTF8, "application/json");
//                request.Content = content;
//            }

//            HttpResponseMessage result = client.SendAsync(request).Result;
//            retorno = result.Content.ReadAsStringAsync().Result;

//            if (result.StatusCode != System.Net.HttpStatusCode.OK)
//            {
//                throw new Exception(retorno);
//            }
//        }
//        */
//    }
//}