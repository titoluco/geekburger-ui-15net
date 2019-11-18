using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using System.Threading;
using Microsoft.Extensions.Configuration;
using GeekBurger.UI.Configuration;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Linq;
using GeekBurger.UI.Model;
using Newtonsoft.Json;
using GeekBurger.UI.Contract;
using GeekBurger.UI.Helper;
using StoreCatalog.Contract;

namespace GeekBurger.UI.Service
{

    public interface IReceiveMessagesService
    {
        Task HandleStoreCatalogReady(Message message, CancellationToken arg2);

        Task HandleUserRetrieved(Message message, CancellationToken arg2);
    }
}
