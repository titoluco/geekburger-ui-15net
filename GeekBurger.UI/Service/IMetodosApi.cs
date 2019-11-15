using System.Net.Http;
using System.Threading.Tasks;

namespace GeekBurger.UI.Service
{
    public interface IMetodosApi
    {
        Task EnvioPost(string url, string json);
        Task<HttpResponseMessage> PostToApi(string url, dynamic data);
        T retornoGet<T>(string url);
    }
}
