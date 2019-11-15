using GeekBurger.UI.Model;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using GeekBurger.UI.Helper;

namespace GeekBurger.UI.Service
{
    public interface IShowDisplayService : IHostedService
    {
        void SendMessagesAsync(Topics topic);
        void AddMessage(ShowDisplayMessage showDisplayMessage);
    }
}